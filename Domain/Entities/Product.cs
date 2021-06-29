using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Display(Name="Production Date")]
        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "champs obligatoire")]
        [StringLength(25, ErrorMessage ="Taille maximale 25 caractère")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public int ProductId { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        public string ImageName { get; set; }
        public string City { get; set; }
       
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category category { get; set; }

        public virtual ICollection<Provider> providers { get; set; }
        public virtual ICollection<Facture> factures { get; set; }


        /*public override void GetDetails()
        {
            Console.WriteLine("Product id: " + ProductId + ", Name: " + Name + ", Description: " + Description + ", Price: " + Price + ", Quantity: " + Quantity);
        }*/

        public virtual void GetMyType()
        {
            Console.WriteLine("UNKNOWN");
        }
        public override string ToString()
        {
            return "Product id: " + ProductId.ToString() + ", Name: " + Name.ToString() + ", Description: " + Description.ToString() + ", Price: " + Price.ToString() + ", Quantity: " + Quantity.ToString();
        }
    }
}
