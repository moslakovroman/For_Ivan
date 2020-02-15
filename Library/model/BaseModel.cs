using System;
using model.Interfaces;
using ServiceStack.DataAnnotations;

namespace model
{
    public class BaseModel : IBaseModel
    {
        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }
    }
}
