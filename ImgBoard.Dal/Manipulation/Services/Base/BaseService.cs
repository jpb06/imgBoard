using ImgBoard.Dal.Context.Contracts;
using ImgBoard.Dal.Exceptions;
using ImgBoard.Dal.Exceptions.CustomTypes;
using ImgBoard.Dal.Exceptions.CustomTypes.Specific;
using ImgBoard.Dal.Manipulation.Services.Main.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgBoard.Dal.Manipulation.Services.Base
{
    public class BaseService
    {
        protected IDbContext context;
        public DataConflictPolicy policy;

        public BaseService(IDbContext context)
        {
            this.context = context;
            this.policy = DataConflictPolicy.ClientWins;
        }

        protected SaveResult Save(DataConflictPolicy policy)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    int result = this.context.SaveChanges();

                    return new SaveResult { AlteredObjectsCount = result };
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    if (policy == DataConflictPolicy.NoPolicy)
                        throw new DalException(DalErrorType.BaseServiceDataConflictWithNoPolicy,
                            "Data conflict (Optimistic concurrency)");

                    saveFailed = true;

                    DataConflictInfo info = OptimisticConcurrency.ApplyPolicy(policy, exception);
                    if (info != null)
                        throw new DataConflictException(DalErrorType.BaseServiceDataConflictWithAskClientPolicy, info);
                }
                catch (Exception exception)
                {
                    exception.HandleException();
                }

            } while (saveFailed);

            return null;
        }

        protected async Task<SaveResult> SaveAsync(DataConflictPolicy policy)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    int result = await this.context.SaveChangesAsync();

                    return new SaveResult { AlteredObjectsCount = result };
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    if (policy == DataConflictPolicy.NoPolicy)
                        throw new DalException(DalErrorType.BaseServiceDataConflictWithNoPolicy,
                               "Data conflict (Optimistic concurrency)");

                    saveFailed = true;

                    DataConflictInfo info = OptimisticConcurrency.ApplyPolicy(policy, exception);
                    if (info != null)
                        throw new DataConflictException(DalErrorType.BaseServiceDataConflictWithAskClientPolicy, info);
                }
                catch (Exception exception)
                {
                    exception.HandleException();
                }

            } while (saveFailed);

            return null;
        }
    }
}
