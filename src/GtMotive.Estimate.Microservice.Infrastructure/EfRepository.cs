using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Contexts;

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T>
        where T : class, IAggregateRoot
    {
        protected GtMotiveFleetContext _gtMotiveFleetContext;
        public EfRepository(GtMotiveFleetContext dbContext)
            : base(dbContext)
        {
            _gtMotiveFleetContext = dbContext;  
        }
    }
}
