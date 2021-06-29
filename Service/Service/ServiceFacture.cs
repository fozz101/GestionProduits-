using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceFacture : EntityService<Facture>
    {
        public ServiceFacture() : base() { }

        public Facture getFactureById (int productId, int clientId, DateTime dateAchat)
        {
            return this.GetAll().Where(a => a.ProductId == productId && a.ClientId == clientId && a.DateAchat == dateAchat).FirstOrDefault();
        }

    }
}
