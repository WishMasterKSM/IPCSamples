using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCClient
{
    class Program
    {
        static void testNamedPipe()
        {
            try
            {
                var binding = new NetNamedPipeBinding();
                binding.Security.Mode = NetNamedPipeSecurityMode.None;
                var ep = new EndpointAddress("net.pipe://localhost/SampleServer");
                IServiceContract channel = ChannelFactory<IServiceContract>.CreateChannel(binding, ep);

                Console.WriteLine("Client Connected, sending message");

                channel.doSomething("Named Pipe Client Message");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        static void testLocalTcp()
        {
            try
            {
                var binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.None;
                var ep = new EndpointAddress("net.tcp://localhost:8888/SampleServer/local");
                IServiceContract channel = ChannelFactory<IServiceContract>.CreateChannel(binding, ep);

                Console.WriteLine("Client Connected, sending message");

                channel.doSomething("Local Tcp Client Message");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        static void testGlobalTcp()
        {
            try
            {
                var binding = new NetTcpBinding();
                binding.Security.Mode = SecurityMode.None;
                var ep = new EndpointAddress("net.tcp://192.168.88.182:8888/SampleServer");
                IServiceContract channel = ChannelFactory<IServiceContract>.CreateChannel(binding, ep);

                Console.WriteLine("Client Connected, sending message");

                channel.doSomething("Global Tcp Client Message");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            testNamedPipe();
            testLocalTcp();
            testGlobalTcp();

            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
