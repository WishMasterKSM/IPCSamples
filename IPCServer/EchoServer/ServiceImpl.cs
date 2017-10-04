using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class ServiceImpl : IServiceContract
    {
        public string echo(string message)
        {
            return Client.echo(message);
        }
    }
}
