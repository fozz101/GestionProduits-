using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private GetProduitsContext dataContext;
        public GetProduitsContext DataContext { get { return dataContext; } }

        public GetProduitsContext Get()
        {
            if (DataContext != null) return DataContext;
            return dataContext = new GetProduitsContext();
        }

        // Constructor: create new instance of GestionProduitsContext
        public DatabaseFactory()
        {
            dataContext = new GetProduitsContext();
        }

        //Implement DisposeCore to free ressource allocated to DataContext
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


}
