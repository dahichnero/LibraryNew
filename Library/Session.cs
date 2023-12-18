using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Session
    {
        private Session()
        {
            context = new WellLibraryContext();
        }
        private static Session? instance;
        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }
        private WellLibraryContext context;
        public WellLibraryContext Context => context;
    }
}
