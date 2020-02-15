using System;

namespace model.Filters
{
    public class BaseFilter
    {
        public long? Id { get; set; }
        public bool? Active { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
