using System.Configuration;
using System.Linq;
using api;
using api.Interfaces;
using api.Repositories;
using api.Repositories.ORMLite;
using api.Servises;
using ConsoleAppp.Appconfig;
using model.db;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using ServiceStack.Text;

namespace ConsoleAppp.Config
{
    public class AppConfig
    {
        public static void DefaultConfig(Funq.Container container)
        {

            var provider = MySqlDialectProvider.Instance;

            container.Register<IDbConnectionFactory>(
                new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString
                    , provider)
                {
                    ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
                });
            ;
            container.Register<IUnitOfWorkProvider>(new UnitOfWorkProvider(container.Resolve<IDbConnectionFactory>()));
            container.Register<IConfig>(new ApiConfig(container.Resolve<IDbConnectionFactory>()));

            container.Register<IRepoAddress>(new AddressRepository(container.Resolve<IUnitOfWorkProvider>()));
            container.Register<IAddressService>(new AddressService(container.Resolve<IRepoAddress>()));

            //container.Register<IRepoUsers>(new UsersRepository(container.Resolve<IUnitOfWorkProvider>()));
            //container.Register<IUsersService>(new UsersService(container.Resolve<IRepoUsers>()));

            //ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }


        public static void Initialize(Funq.Container container)
        {
            DefaultConfig(container);

            JsConfig.EmitCamelCaseNames = true;
            JsConfig.DateHandler = ServiceStack.Text.JsonDateHandler.ISO8601;

            var config = container.Resolve<IConfig>();
            config.Configure();

            MapperConfig.Configure();


            using (var db = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
            {
                db.CreateTableIfNotExists(
                    typeof(Address).Assembly.GetTypes()
                        .Where(t => t.IsClass && t.Namespace != null && t.Name != null && t.Namespace.Equals("model.db")).ToArray()
                );
            }
        }
    }
}