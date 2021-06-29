using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;

namespace Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        private DatabaseFactory Dbfactory = new DatabaseFactory();

        public ProductRepository(DatabaseFactory Db) : base(Db)
        {
            Dbfactory = Db;
        }
    }
}
