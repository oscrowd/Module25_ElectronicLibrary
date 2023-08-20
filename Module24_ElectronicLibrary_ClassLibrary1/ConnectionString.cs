using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module24_ElectronicLibrary_ClassLibrary1
{
        public static class ConnectionString
        {
            public static string MsSqlConnection => @"Server=.\SQLEXPRESS\lolipop;Database=ElectronicLibrary;Trusted_Connection=True;";
        }
    
}