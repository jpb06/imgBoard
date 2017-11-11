using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Manipulation.Repositories;
using ImgBoard.Dal.Manipulation.Services.Base;
using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using ImgBoard.Dal.Manipulation.Services.Main.Contracts;
using ImgBoard.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Services.Main.Base
{
    public class BaseMainService : BaseService, IBaseMainService
    {
        internal RepositoriesSet repositoriesSet;

        public BaseMainService(IImgBoardContext context) : base(context)
        {
            base.context = context;
            base.policy = DataConflictPolicy.ClientWins;
            this.repositoriesSet = new RepositoriesSet();
        }

        public void SetPolicy(DataConflictPolicy policy)
        {
            base.policy = policy;
        }

        #region Generic alteration async
        public async Task<int> CreateAsync<TDBaseModel>(TDBaseModel model)
            where TDBaseModel : BaseModel
        {
            var repository = this.repositoriesSet.GetGeneric<TDBaseModel>();
            repository.Insert(model);

            SaveResult result = await base.SaveAsync(policy);
            result.AlteredIds = new int[] { model.Id };

            result.Validate(1, this.policy);

            return result.AlteredIds[0];
        }

        public async Task ModifyAsync<TDBaseModel>(TDBaseModel model)
            where TDBaseModel : BaseModel
        {
            var repository = this.repositoriesSet.GetGeneric<TDBaseModel>();
            repository.Update(model);

            SaveResult result = await this.SaveAsync(policy);
            result.AlteredIds = new int[] { model.Id };

            result.Validate(1, this.policy);
        }

        public async Task DeleteAsync<TDBaseModel>(TDBaseModel model)
            where TDBaseModel : BaseModel
        {
            var repository = this.repositoriesSet.GetGeneric<TDBaseModel>();
            repository.Delete(model);

            SaveResult result = await this.SaveAsync(policy);
            result.AlteredIds = new int[] { model.Id };

            result.Validate(1, this.policy);
        }
        #endregion

        #region Data retrieval
        public async Task<TDBaseModel> GetByIdAsync<TDBaseModel>(int id)
            where TDBaseModel : BaseModel
        {
            var repository = this.repositoriesSet.GetGeneric<TDBaseModel>();
            TDBaseModel model = await repository.GetByIdAsync(id);

            return model;
        }

        public async Task<List<TDBaseModel>> GetAsync<TDBaseModel>(
            Expression<Func<TDBaseModel, bool>> filter = null,
            Func<IQueryable<TDBaseModel>, IOrderedQueryable<TDBaseModel>> orderBy = null,
            string includeProperties = "") where TDBaseModel : BaseModel
        {
            var repository = this.repositoriesSet.GetGeneric<TDBaseModel>();
            IEnumerable<TDBaseModel> result = await repository.GetAsync(filter, orderBy, includeProperties);

            return result.ToList();
        }
        #endregion


    }
}
