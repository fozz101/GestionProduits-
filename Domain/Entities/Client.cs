using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
      
        public DateTime DateNaissance { get; set; }

        [Key]
        public int Cin { get; set; }
        public string Email { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        public virtual ICollection<Facture> factures { get; set; }
    }
}
