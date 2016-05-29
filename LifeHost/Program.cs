using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Core;
using System.ServiceModel;

namespace LifeHost
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager.Load();
            ServiceHost host = new ServiceHost(typeof(Service));
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri adrr = new Uri("http://localhost:4000/LifeService");
            Type contract = typeof(IService);
            host.AddServiceEndpoint(contract, binding, adrr);
            host.Open();
            Console.WriteLine("Opened");
            Console.WriteLine("Press Any key for close");
            Console.ReadKey();
            GameManager.Save();
            host.Close();
        }
    }
}
