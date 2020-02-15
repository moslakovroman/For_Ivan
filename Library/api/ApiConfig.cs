using System.Linq;
using api.Interfaces;
using model.db;
using ServiceStack.OrmLite;

namespace api
{
    public class ApiConfig : IConfig
    {
        private IDbConnectionFactory _factory;


        public ApiConfig(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public void Configure()
        {
            InitDatabase();
            
        }

        private void InitDatabase()
        {

            using (var db = _factory.OpenDbConnection())
            {
                db.CreateTableIfNotExists(
                    typeof(Address).Assembly.GetTypes()
                        .Where(t => t.IsClass && t.Namespace != null && t.Name != null && t.Namespace.Equals("model.db")).ToArray()
                    );
            }
        }
    }
}
