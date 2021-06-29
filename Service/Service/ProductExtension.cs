using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ProductExtension
    {
        public static void UpperName(Product product)
        {
            product.Name.ToUpper();
        }

        public static Boolean InCategory(Product product, Category category)
        {
            
            if (product.category == category)
                return true;
            return false;
        }


    }
}
