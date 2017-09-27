using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCClientMsmq
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new NetMsmqBinding();
            binding.Security.Mode = NetMsmqSecurityMode.None;
            var ep = new EndpointAddress("net.msmq://localhost/private/TestQueue");
            IServiceContract channel = ChannelFactory<IServiceContract>.CreateChannel(binding, ep);

            Console.WriteLine("Client Connected, sending message");

            channel.doSomething("This is fake message");

            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
