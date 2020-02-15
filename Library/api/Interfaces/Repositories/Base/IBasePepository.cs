using System.Collections.Generic;
using model.Filters;

namespace api.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        T Save(T item);
        T Get(long id);
        void Delete(T item);
        List<T> GetByFilter(BaseFilter filterObject);
    }
}