using ServiceStack.DataAnnotations;

namespace model.db
{
    [Alias("tbladdress")]
    public class Address : BaseModel
    {
        public string zc { get; set; }
        public string cn { get; set; }
        public  string ds { get; set; }
        public string sn { get; set; }
        public string[] hn { get; set; }
    }
}