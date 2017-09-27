using System;
using System.ServiceModel;

namespace IPCTestServer
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ServiceImpl : IServiceContract
	{
		public string getMessage()
		{
			return "Hello, world!";
		}

		public void doSomething(String message)
		{
			Console.WriteLine("Message received:");
			Console.WriteLine(message);
		}
	}
}

