using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ABPMVCTest.EntityFramework.Repositories
{
    public abstract class ABPMVCTestRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ABPMVCTestDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ABPMVCTestRepositoryBase(IDbContextProvider<ABPMVCTestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ABPMVCTestRepositoryBase<TEntity> : ABPMVCTestRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ABPMVCTestRepositoryBase(IDbContextProvider<ABPMVCTestDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
