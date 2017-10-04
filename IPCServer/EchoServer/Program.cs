using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:8080/EchoServer");
            var serviceHost = new ServiceHost(typeof(ServiceImpl), baseAddress);

            var webBinding = new WebHttpBinding();
            webBinding.Security.Mode = WebHttpSecurityMode.None;
            serviceHost.AddServiceEndpoint(typeof(IServiceContract), webBinding, "api").EndpointBehaviors.Add(new WebHttpBehavior());

            serviceHost.Open();

            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
