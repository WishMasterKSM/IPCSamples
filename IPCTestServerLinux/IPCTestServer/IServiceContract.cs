using System;

using System.ServiceModel;

namespace IPCTestServer
{
	[ServiceContract]
	public interface IServiceContract
	{
		[OperationContract]
		String getMessage();

		[OperationContract(IsOneWay = true)]
		void doSomething(String message);
	}
}

