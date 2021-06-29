using Data;
using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Provider P1 = new Provider()
            {
                Password = "12345",
                ConfirmPassword = "12345",
                Username = "test",
                Email = "test@gmail.com"
            };
            Category cat1 = new Category() { Name = "CAT1" };
            Category cat2 = new Category() { Name = "CAT2" };
            Category cat3 = new Category() { Name = "CAT3" };
            Provider prov1 = new Provider() { Username = "PROV1" };
            Provider prov2 = new Provider() { Username = "PROV2" };
            Provider prov3 = new Provider() { Username = "PROV3" };
            Provider prov4 = new Provider() { Username = "PROV4" };
            Provider prov5 = new Provider() { Username = "PROV5" };*/
            Product prod1 = new Product() { Name = "PROD12", Price=420, DateProd=DateTime.Now, Quantity=2};
            /*Product prod2 = new Product() { Name = "PROD2", category = cat1, providers = new List<Provider>() { prov1 } };
            Product prod3 = new Product() { Name = "PROD4", providers = new List<Provider>() { prov3, prov4, prov5 } };
            cat1.products = new List<Product>() { prod1, prod2 };

            prov1.products = new List<Product>() { prod1, prod2 };
            prov2.products = new List<Product>() { prod1 };
            prov3.products = new List<Product>() { prod3 };


            List<Product> produiyets = new List<Product>();
            produiyets.Add(prod1);
            produiyets.Add(prod2);
            produiyets.Add(prod3);
            */
            /*
          foreach(Product pr in produiyets)
           {
               pr.GetDetails();
           }
           produiyets.RemoveAt(1);
           System.Console.WriteLine("apres suppression \n");
           foreach (Product pr in produiyets)
           {
               pr.GetDetails();
           }
           */
            /*
            prod1.GetMyType();
            prod2.GetMyType();
            prod3.GetMyType();
            prod4.GetMyType();
            */

            /*
            bool result= P1.Login("test", "12345");
            System.Console.WriteLine("Result authentification= " + result);
            */

            /*
            Provider.SetIsApproved(P1.Password, P1.ConfirmPassword, P1.IsApproved);
            System.Console.WriteLine("Passage par valeur, isApproved = " + P1.IsApproved);
            System.Console.ReadKey();
            Provider.SetIsApproved(P1);
            System.Console.WriteLine("Passage par reference, isApproved = " + P1.IsApproved);
            System.Console.ReadKey();
            */

            /*
            prov1.GetDetails();
            prov2.GetDetails();
            */

            /* prov1.GetProducts("Quantity", "0");
             System.Console.ReadKey();*/
            //prov2.GetProducts("ProductId", "0");

            /*** Donnees d'initialisation **/
            //Categories
            /*
            Category fruit = new Category() { Name = "Fruit" };
            Category Alimentaire = new Category() { Name = "Alimentaire" };

            //Products
            Product acide = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "ACIDE CITRIQUE",
                Description = "Monohydrate - E330 - USP32",
                category = Alimentaire,
                Price = 90,
                Quantity = 30,
                City = "Sousse"
            };
            Product cacao = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "POUDRE DE CACAO NATURELLE",
                Description = "10% -12%",
                category = Alimentaire,
                Price = 419,
                Quantity = 80,
                City = "Sfax"
            };

            Product dioxyde = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "DIOXYDE DE TITANE",
                Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique.",
                category = Alimentaire,
                Price = 200,
                Quantity = 50,
                City = "Tunis"
            };
            Product amidon = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "AMIDON DE MAÏS",
                Description = "Amidon de maïs natif",
                category = Alimentaire,
                Price = 70,
                Quantity = 30,
                City = "Tunis"
            };
            Product blackberry = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Blackberry",
                Description = "",
                category = fruit,
                Price = 60,
                ProductId = 0,
                Quantity = 0

            };

            Product apple = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = "",
                category = fruit,
                Name = "Apple",
                Price = 100,
                ProductId = 0,
                Quantity = 100

            };

            Product avocado = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = "",
                category = fruit,
                Name = "Avocado",
                Price = 100,
                ProductId = 0,
                Quantity = 100

            };

            List<Product> products = new List<Product>() { acide, cacao, dioxyde, amidon, blackberry, apple, avocado };
            ManageProduct manageProduct = new ManageProduct(products);

            Provider sater = new Provider() { Id = 1, Username = "Medical Provider" };
            Provider sudMedical = new Provider() { Id = 2, Username = "Fruit-SA Provider" };
            Provider palliserSa = new Provider() { Id = 3, Username = "Fruit-CP  Provider" };
            Provider prov4 = new Provider() { Id = 4, Username = "Chemical Med-Provider" };
            Provider prov5 = new Provider() { Id = 5, Username = "Bio Provider" };
            List<Provider> providers = new List<Provider>() { sater, sudMedical, palliserSa, prov4, prov5 };
            ManageProvider manageProvider = new ManageProvider(providers);


            ManageProduct.FindProduct fp = delegate (string c)
            {
                foreach(Product pr in products)
                {
                    if (pr.Name.ToUpper().StartsWith(c.ToUpper()))
                        System.Console.WriteLine(pr);
                }
            };
            ManageProduct.ScanProduct sp = delegate (Category category){
                foreach (Product pr in products)
                {
                    //if (pr.category.ToString().Equals(category.ToString()))
                    if (pr.category.Name.ToUpper().Equals(category.Name.ToUpper()))
                        System.Console.WriteLine(pr);
                }
            };

            //fp("a");
            sp(Alimentaire);
            System.Console.WriteLine();
            sp(fruit);

            */


            
            /*GetProduitsContext context = new GetProduitsContext();
            context.Products.Add(prod1);
            context.SaveChanges();*/

            System.Console.ReadKey();

        }
    }
}
