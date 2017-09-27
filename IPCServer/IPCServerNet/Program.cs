using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("net.tcp://localhost:8888/SampleServer");
            var serviceHost = new ServiceHost(typeof(ServiceImpl), baseAddress);

            var pipeBinding = new NetNamedPipeBinding();
            pipeBinding.Security.Mode = NetNamedPipeSecurityMode.None;
            serviceHost.AddServiceEndpoint(typeof(IServiceContract), pipeBinding, "net.pipe://localhost/SampleServer");

            var tcpLocalBinding = new NetTcpBinding();
            tcpLocalBinding.Security.Mode = SecurityMode.None;
            serviceHost.AddServiceEndpoint(typeof(IServiceContract), tcpLocalBinding, "local");

            var tcpGlobalBinding = new NetTcpBinding();
            tcpGlobalBinding.Security.Mode = SecurityMode.None;
            serviceHost.AddServiceEndpoint(typeof(IServiceContract), tcpGlobalBinding, String.Format("net.tcp://{0}:8888/SampleServer", ConfigurationManager.AppSettings["tcpHostAddress"]));

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
