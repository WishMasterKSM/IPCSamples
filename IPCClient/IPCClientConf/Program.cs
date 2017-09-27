using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCClientConf
{
    class Program
    {
        static void testClient(String endpointConfig)
        {
            try
            {
                ChannelFactory<IServiceContract> factory = new ChannelFactory<IServiceContract>(endpointConfig);
                var channel = factory.CreateChannel();
                Console.WriteLine("Client Connected, sending message");

                channel.doSomething(endpointConfig + " Client Message");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            testClient("pipeServiceEndpoint");
            testClient("localTcpServiceEndpoint");
            testClient("globalTcpServiceEndpoint");

            testClient("linuxTcpServiceEndpoint");

            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
