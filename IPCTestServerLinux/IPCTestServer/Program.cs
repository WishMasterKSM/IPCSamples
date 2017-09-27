using System;

using System.ServiceModel;

namespace IPCTestServer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var baseAddress = new Uri("net.tcp://192.168.88.176:8000/IPCTestServer");
			var serviceHost = new ServiceHost(typeof(ServiceImpl), baseAddress);

			var binding = new NetTcpBinding();
			binding.Security.Mode = SecurityMode.None;
			serviceHost.AddServiceEndpoint(typeof(IServiceContract), binding, "tcp");
			serviceHost.Open();
				
			Console.WriteLine("The service is ready at {0}", baseAddress.AbsoluteUri);
			Console.WriteLine("Press <ENTER> to terminate service.");
			Console.WriteLine();
			Console.ReadLine();

			serviceHost.Close();
		}
	}
}
