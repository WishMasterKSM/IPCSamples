using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCClientMsmq
{
    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract(IsOneWay = true)]
        void doSomething(String message);
    }
}
