using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ManageCategory
    {
        List<Category> categories { get; set; }
        public ManageCategory(List<Category> vcategories) 
        {
            this.categories = vcategories;
        }
    }
}
