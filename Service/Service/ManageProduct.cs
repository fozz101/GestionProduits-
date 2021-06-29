using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ManageProduct
    {
        public List<Product> products { get; set; }
        public delegate void FindProduct(string c);
        public delegate void ScanProduct(Category category);

        public ManageProduct(List<Product> vproducts) 
        {
            this.products = vproducts;
        }
        public List<Product> Get5Chemical(double price)
        {
            var listeProduits =
                (from prod in products
                 where prod is Chemical && prod.Price < price
                 select prod).Take(5).ToList<Product>();

            return listeProduits;        
        }
      
        public double GetAveragePrice()
        {
            return (from prod in products
                    select prod.Price).Average();
        }

        public List<Product> GetProductPrice(double price)
        {
            var listeProduits =
                (from prod in products
                 where prod.Price>price
                 select prod).Skip(2).ToList<Product>();

            return listeProduits;
        }

        public Product GetMaxPrice()
        {
            var MaxPrice =
                (from prod in products
                 select prod.Price).Max();

            var product =
                (from prod in products
                 where prod.Price == MaxPrice
                 select prod).FirstOrDefault();

            return product;
        }

        public int GetCountProduct(string city)
        {
            int nbre = 0;
            var produtis =
                (from prod in products
                 where prod is Chemical
                 select prod).Skip(0).ToList<Product>();

            foreach (Chemical prod in produtis)
            {
                if (prod.City == "city")
                    nbre++;

            }
            return nbre;
        }


        public List<Product> GetChemicalCity()
        {
            var chemicals =
                (from prod in products
                 where prod is Chemical
                 orderby prod.City ascending
                 select prod).Skip(0).ToList<Product>();

            return chemicals;
        }

 









    }
}
