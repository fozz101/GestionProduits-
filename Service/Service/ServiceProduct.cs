using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;
namespace Service
{
    public class ServiceProduct: EntityService<Product>
    {
        public ServiceProduct() : base() { }

    }
}
