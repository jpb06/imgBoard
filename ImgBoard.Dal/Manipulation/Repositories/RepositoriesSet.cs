﻿using ImgBoard.Dal.Manipulation.Repositories.Contracts;
using ImgBoard.Models.Base;
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
            where TModel : BaseModel
            where TRepository : class, IGenericRepository<TModel>
        {
            this.repositories.Add(typeof(TModel), instance);
        }

        public IGenericRepository<TModel> GetGeneric<TModel>()
            where TModel : BaseModel
        {
            object repository;
            this.repositories.TryGetValue(typeof(TModel), out repository);

            this.CheckRepository<TModel>(repository);

            return (IGenericRepository<TModel>)repository;
        }

        public TSpecific GetSpecific<TModel, TSpecific>()
            where TModel : BaseModel
            where TSpecific : class, IGenericRepository<TModel>
        {
            object repository;
            this.repositories.TryGetValue(typeof(TModel), out repository);

            this.CheckRepository<TModel>(repository);

            return (TSpecific)repository;
        }

        private void CheckRepository<TModel>(object repository)
            where TModel : BaseModel
        {
            if (repository == null)
            {
                string message = string.Format("Instance is missing for {0}", typeof(TModel).FullName);

                // TODO : apply proper exceptions segregation & logging
                throw new Exception("RepositoriesSetMissingMapping");
            }
        }
    }
}
