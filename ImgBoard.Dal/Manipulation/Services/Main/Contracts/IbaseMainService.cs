using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using ImgBoard.Dal.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Services.Main.Contracts
{
    public interface IBaseMainService
    {
        void SetPolicy(DataConflictPolicy policy);

        #region Generic Async
        Task<int> CreateAsync<TModel>(TModel model) where TModel : BaseDbModel;
        Task ModifyAsync<TModel>(TModel model) where TModel : BaseDbModel;
        Task DeleteAsync<TModel>(TModel model) where TModel : BaseDbModel;

        Task<TModel> GetByIdAsync<TModel>(int id) where TModel : BaseDbModel;
        Task<List<TModel>> GetAsync<TModel>(
            Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            string includeProperties = "") where TModel : BaseDbModel;
        #endregion
    }
}
