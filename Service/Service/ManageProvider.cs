using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ManageProvider
    {
        public List<Provider> providers { get; set; }
        public ManageProvider(List<Provider> vproviders)
        {
            this.providers = vproviders;
        }
    }
    /*
    public List<Provider> GetProviderByName(string name)
    {

        var provs =
            (from prov in providers
             where prov.Username.Contains(name)
             select prov).ToList<Provider>();
        return provs;
    }

    public Provider GetFirstProviderByName(string name)
    {
        var provider =
            (from prov in providers
             where prov.Username.Contains(name)
             select prov).FirstOrDefault();

        return provider;
    }


    public Provider GetProviderById(int id)
    {
        var provider =
            (from prov in providers
             where prov.Id == id
             select prov).FirstOrDefault();

        return provider;
    }
    */

}
