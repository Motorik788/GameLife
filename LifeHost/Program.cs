using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Service;
using Core;
using System.ServiceModel;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;

namespace LifeHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Dns.Resolve(Dns.GetHostName()).AddressList[0]);

            //Console.ReadKey();
            GameManager.Load();
            ServiceHost host = new ServiceHost(typeof(Service));
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri adrr = new Uri("http://192.168.1.50:4000/LifeService");
            Type contract = typeof(IService);
            host.AddServiceEndpoint(contract, binding, adrr);
            host.Open();
            Console.WriteLine("Opened");
            Console.WriteLine("Press Any key for close and Save All Games");
            Console.ReadKey();
            GameManager.Save();
            host.Close();
        }
    }
}
