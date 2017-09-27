using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCClientSubst
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChannelFactory<IServiceContract> factory = new ChannelFactory<IServiceContract>("serviceEndpoint");
                var channel = factory.CreateChannel();
                Console.WriteLine("Client Connected, sending message");

                channel.doSomething("Client Message " + factory.Endpoint.Binding.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }

            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
