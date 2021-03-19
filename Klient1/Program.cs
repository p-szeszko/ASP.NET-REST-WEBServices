using Klient1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klient1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSerwisClient client = new WebSerwisClient();
            Console.WriteLine("Działanie serwera");
            int z = client.Silinia(5);
            Console.WriteLine(z);
            Console.ReadLine();
            client.Close();
        }
    }
}
