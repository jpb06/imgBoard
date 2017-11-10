using ImgBoard.Models.Base;
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
        #region Generic Async
        Task<int> CreateAsync<TModel>(TModel model) where TModel : BaseModel;
        Task ModifyAsync<TModel>(TModel model) where TModel : BaseModel;
        Task DeleteAsync<TModel>(TModel model) where TModel : BaseModel;

        Task<TModel> GetByIdAsync<TModel>(int id) where TModel : BaseModel;
        Task<List<TModel>> GetAsync<TModel>(
            Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            string includeProperties = "") where TModel : BaseModel;
        #endregion
    }
}
