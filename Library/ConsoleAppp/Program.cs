using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using api.Interfaces;
using api.Repositories;
using api.Servises;
using model.db;
using ServiceStack.Text;
using ConsoleAppp.Config;
using api.Servises;
using model.ViewModels;
using System.Web;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;


namespace ConsoleAppp
{
    //public class SomeController
    //{
    //    private readonly IAddressService _addressService;

    //    public SomeController(IAddressService addressService)
    //    {
    //        _addressService = addressService;
    //    }

    //    public Address GetAddress(Address model)
    //    {
    //        return _addressService.DbAddress(model);
    //    }

    //}

    class Program
    {
        static void Main(string[] args)
        {

            var container = new Funq.Container();
            AppConfig.Initialize(container);


            IAddressService _addressService = container.Resolve<IAddressService>();


            
            //WebRequest reqGET = WebRequest.Create($@"https://www.telekom.de/autocomplete/v1/streets?zipcode=01067");
            //WebResponse resp = reqGET.GetResponse();
            //Stream stream = resp.GetResponseStream();
            //StreamReader sr = new StreamReader(stream);
            //string s = sr.ReadToEnd();
            //var models = s.FromJson<List<AddressViewModel>>();

            int zipcodeStartvalue = 01067;

            IEnumerable<Address> itemm;

            for (int i = 1067; i < 99998; i++)
            {

                string ChangeZipCode(int zipcode)
                {
                    string zipCodeInString = Convert.ToString(zipcodeStartvalue.ToString("00000"));
                    //Console.WriteLine(zipCodeInString.GetType());
                    return $@"https://www.telekom.de/autocomplete/v1/streets?zipcode={zipCodeInString}";
                }

                WebRequest chGET = WebRequest.Create(ChangeZipCode(zipcodeStartvalue));
                WebResponse resp1 = chGET.GetResponse();
                Stream stream1 = resp1.GetResponseStream();
                StreamReader sr1 = new StreamReader(stream1);
                string s1 = sr1.ReadToEnd();
                var models1 = s1.FromJson<List<AddressViewModel>>();

                 itemm = from add in models1


                    select new Address()
                    {
                        Id = add.Id,
                        zc = add.ZipCode,
                        cn = add.City,
                        ds = add.District,
                        sn = add.Street,
                        hn = add.HouseNumber
                    };

                AddAddress();
                zipcodeStartvalue++;


            }

            Console.WriteLine("complete");
            






            void AddAddress()
            {
                foreach (var VARIABLE in itemm)
                {

                    _addressService.DbAddress(VARIABLE);
                }
            }

            //AddAddress();







            //WebRequest reqGETHh = WebRequest.Create(@"https://www.telekom.de/autocomplete/v1/housenumbers?zipcode=01067&city=Dresden&street=Alfred-Althus-Str.");
            //WebResponse respHh = reqGETHh.GetResponse();
            //Stream streamHh = respHh.GetResponseStream();
            //StreamReader srHh = new StreamReader(streamHh);
            //string sHh = srHh.ReadToEnd();
            //var modelsHh = sHh.FromJson<List<HhViewModel>>();


            //var item = from addHouses in modelsHh

            //    select new Address()
            //    {
            //        Id = addHouses.Id,


            //        hn = addHouses.HouseNumber 
            //    };

            //var complex = from com in models
            //    join address in modelsHh on com.Id equals address.Id
            //    select new Address()
            //    {
            //        Id = com.Id,
            //        zc = com.ZipCode,
            //        cn = com.City,
            //        ds = com.District,
            //        sn = com.Street,
            //        hn = address.HouseNumber
            //    };

            ////void AddHousesNumber(long id)
            ////{
            ////    var itemadd = from str in modelsHh
            ////        where (str.Id == id)
            ////        select new Address()
            ////        {
            ////            hn = str.HouseNumber
            ////        };
            ////    AddAddress();
            ////}


            //void AddHouse()
            //{
            //    foreach (var VARIABLE in item)
            //    {
            //        _addressService.DbAddress(VARIABLE);
            //    }
            //}

            //AddHouse();






















            //void InsertData()
            //{
            //    DataTable dataTable = new DataTable();
            //    SqlConnectionStringBuilder mySql = new SqlConnectionStringBuilder();
            //    mySql.DataSource = "localhost";
            //    //mySql.InitialCatalog = "dboaddress";
            //    mySql.UserID = "root";
            //    mySql.Password = "root";

            //    string query = ("Insert into dboaddress" +
            //                    "(Active, Created, Updated, ZipCode, City, Street) Values" +
            //                    "(@Active, @Created, @Updated, @Zipcode, @City, @Street)");

            //    SqlConnection con = new SqlConnection();
            //    con.ConnectionString = mySql.ConnectionString;

            //    SqlCommand command = new SqlCommand(query,con);

            //    command.Connection.Open();
            //    SqlDataReader dataReader = command.ExecuteReader();

            //    while (dataReader.Read())
            //    {
            //        foreach (Address VARIABLE in itemm)
            //        {
            //            command.Parameters.Add(new SqlParameter("@Active", VARIABLE.Active));
            //            command.Parameters.Add(new SqlParameter("@Created", VARIABLE.Created));
            //            command.Parameters.Add(new SqlParameter("@Updated", VARIABLE.Updated));
            //            command.Parameters.Add(new SqlParameter("@ZipCode", VARIABLE.ZipCode));
            //            command.Parameters.Add(new SqlParameter("@City", VARIABLE.City));
            //            command.Parameters.Add(new SqlParameter("@Street", VARIABLE.Street));

            //            //opop.DbAddress(VARIABLE);
            //            Console.WriteLine(VARIABLE.ZipCode + " " + VARIABLE.City + " " + VARIABLE.Street + " " + VARIABLE.Id);
            //        }
            //    }

            //    dataReader.Close();

            //    //string connect = "Server=localhost;Database=dboadresses;User Id=root;Password=root";

            //    //SqlConnection dbo = new SqlConnection(connect);
            //    ////dbo.ConnectionString = "Server = localhost; Database = dboaddress; User Id = root; Password = root";


            //    //string query = ("Insert into dboaddress" +
            //    //                "(Active, Created, Updated, ZipCode, City, Street) Values" +
            //    //                "(@Active, @Created, @Updated, @Zipcode, @City, @Street)");

            //    //SqlCommand mod = new SqlCommand(query, dbo);
            //    //dbo.Open();


            //    //foreach (Address VARIABLE in itemm)
            //    //{



            //    //    mod.Parameters.Add(new SqlParameter("@Active", VARIABLE.Active));
            //    //    mod.Parameters.Add(new SqlParameter("@Created", VARIABLE.Created));
            //    //    mod.Parameters.Add(new SqlParameter("@Updated", VARIABLE.Updated));
            //    //    mod.Parameters.Add(new SqlParameter("@ZipCode", VARIABLE.ZipCode));
            //    //    mod.Parameters.Add(new SqlParameter("@City", VARIABLE.City));
            //    //    mod.Parameters.Add(new SqlParameter("@Street", VARIABLE.Street));

            //    //    //opop.DbAddress(VARIABLE);
            //    //    Console.WriteLine(VARIABLE.ZipCode + " " + VARIABLE.City + " " + VARIABLE.Street + " " + VARIABLE.Id);
            //    //}

            //    command.Connection.Close();


            //}

            //InsertData();

            //        "https://www.telekom.de/autocomplete/v1/housenumbers?zipcode=10967&city=Berlin&street=Sch%C3%B6nleinstr.";


        }
    }
}
