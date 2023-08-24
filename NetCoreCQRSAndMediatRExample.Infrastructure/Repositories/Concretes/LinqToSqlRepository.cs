using NetCoreCQRSAndMediatRExample.Infrastructure.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreCQRSAndMediatRExample.Infrastructure.Repositories.Concretes
{
    public class LinqToSqlRepository<T> : RepositoryBase<T> where T : class
    {
        public LinqToSqlRepository(NetCoreCQRSAndMediatRExampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
