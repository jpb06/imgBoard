using ImgBoard.Dal.Exceptions;
using ImgBoard.Dal.Exceptions.CustomTypes;
using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Dal.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Repositories
{
    internal class RepositoriesSet
    {
        private Dictionary<Type, object> repositories;

        public RepositoriesSet()
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public void Register<TModel, TRepository>(TRepository instance)
            where TModel : BaseDbModel
            where TRepository : class, IGenericRepository<TModel>
        {
            this.repositories.Add(typeof(TModel), instance);
        }

        public IGenericRepository<TModel> GetGeneric<TModel>()
            where TModel : BaseDbModel
        {
            object repository;
            this.repositories.TryGetValue(typeof(TModel), out repository);

            this.CheckRepository<TModel>(repository);

            return (IGenericRepository<TModel>)repository;
        }

        public TSpecific GetSpecific<TModel, TSpecific>()
            where TModel : BaseDbModel
            where TSpecific : class, IGenericRepository<TModel>
        {
            object repository;
            this.repositories.TryGetValue(typeof(TModel), out repository);

            this.CheckRepository<TModel>(repository);

            return (TSpecific)repository;
        }

        private void CheckRepository<TModel>(object repository)
            where TModel : BaseDbModel
        {
            if (repository == null)
            {
                string message = string.Format("Instance is missing for {0}", typeof(TModel).FullName);
                throw new DalException(DalErrorType.RepositoriesSetMissingMapping, message);
            }
        }
    }
}
