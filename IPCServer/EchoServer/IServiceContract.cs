using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        [WebGet]
        string echo(string message);
    }
}
