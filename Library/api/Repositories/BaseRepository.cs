using System;
using System.Collections.Generic;
using api.Repositories.ORMLite;
using model;
using model.Filters;
using ServiceStack.OrmLite;

namespace api.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel, new ()
    {
        private IUnitOfWorkProvider UnitOfWorkProvider { get; set; }

        public List<T> GetByFilter(BaseFilter filter)
        {
            using (var unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                var builder = new JoinSqlBuilder<T,T>();


                AddFilterOption(builder);

                return unitOfWork.DB.Select<T>(builder.ToSql());
            }
        }

        protected virtual void AddFilterOption(JoinSqlBuilder<T,T> builder)
        {

        }
        


        protected BaseRepository(IUnitOfWorkProvider provider)
        {
            UnitOfWorkProvider = provider;
        }

        public virtual T Save(T item)
        {
            using (var unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                return Save(item, unitOfWork);
            }
        }

        public T Get(long id)
        {
            using (var unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                return Get(id, unitOfWork);
            }
        }

        public void Delete(T item)
        {
            using (var unitOfWork = UnitOfWorkProvider.GetUnitOfWork())
            {
                var dbItem = Get(item.Id, unitOfWork);
                Save(dbItem, unitOfWork);
            }
        }

        #region private methods

        private T Get(long id, IUnitOfWork unitOfWork)
        {
            return unitOfWork.DB.GetByIdOrDefault<T>(id);
        }

        private T Save(T item, IUnitOfWork unitOfWork)
        {
           
            if (item.Id != 0)
            {
                unitOfWork.DB.Update(item);
            }
            else
            {
                unitOfWork.DB.Insert(item);
                item.Id = unitOfWork.DB.GetLastInsertId();
            }
            unitOfWork.Save();
            return Get(item.Id);
        }

        #endregion
    }
}
