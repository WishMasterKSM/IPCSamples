using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCServerConf
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(ServiceImpl));
            serviceHost.Open();

            Console.WriteLine("The service is ready");
            foreach (System.ServiceModel.Description.ServiceEndpoint addr in serviceHost.Description.Endpoints)
            {
                Console.WriteLine(String.Format("Endpoint {0} : {1}", addr.Name, addr.ListenUri.ToString()));
            }
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
