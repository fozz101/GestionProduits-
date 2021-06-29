using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provider
    {
        private string password;
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20)
                    password = value;
                else
                {
                    System.Console.WriteLine("Le password doit avoir une taille entre[5,20]");
                }
            }
        }
        
        private string confirmPassword;
        [Required]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword 
        {
           get { return confirmPassword; }
            set
            {
                if (Password == value)
                {
                    confirmPassword = value;
                }
                else
                {
                    Console.WriteLine("La confiramtion du password est differente du password initial");
                }
            }
         }
        public DateTime DateCreated { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Key]
        public int Id { get; set; }

        public bool IsApproved { get; set; }
        
        
        public string Username { get; set; }

        public virtual ICollection<Product> products { get; set; }

        /*public override void GetDetails()
        {
            string s = "";
            foreach (Product prod in products)
                s +="\n" + "Product id: " + prod.ProductId + ", Name: " + prod.Name + ", Description: " + prod.Description + ", Price: " + prod.Price + ", Quantity: " + prod.Quantity + "\n";
            Console.WriteLine("Id: " + Id + ", UserName: " + Username + ", Email: " + Email + ", DateCreated: " + DateCreated + ", Produits = " + s );
        }*/
        public static void SetIsApproved(Provider P)
        {
            if (String.Compare(P.Password, P.ConfirmPassword) != 0)
            {
                P.IsApproved = false;

            }
            else
            {
                P.IsApproved = true;
            }
        }

        public static void SetIsApproved(string password,string confirmPassword,bool isApproved)
        {
            isApproved = String.Compare(password, confirmPassword)==0;
        }

        public bool Login(string userName,string password)
        {
            return String.Compare(userName, Username) == 0 && String.Compare(Password, password) == 0;
        }

        public bool Login(string userName, string password,string email)
        {
            return String.Compare(userName, Username) == 0 && String.Compare(Password, password) == 0 && String.Compare(email, Email) == 0;
        }

        /*public void GetProducts(string filterType, string filterValue)
        {
            foreach(Product prod in products)
            {
                switch (filterType)
                {
                    case "DateProd":
                        if (prod.DateProd.ToString() == filterValue)
                            prod.GetDetails();
                        break;
                    case "Name":
                        if (prod.Name == filterValue)
                            prod.GetDetails();
                        break;
                    case "Price":
                        if (prod.Price == float.Parse(filterValue))
                            prod.GetDetails();
                        break;
                    case "ProductId":
                        if (prod.ProductId == Int32.Parse(filterValue))
                            prod.GetDetails();
                        break;
                    case "Quantity":
                        if (prod.Quantity == Int32.Parse(filterValue))
                            prod.GetDetails();
                        break;
                    case "category":
                        if (prod.category.ToString() == filterValue)
                            prod.GetDetails();
                        break;

                    default:
                        break;
                }
            }
        }*/


    }
}
