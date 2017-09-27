using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCServerMsmqConf
{
    class ServiceImpl : IServiceContract
    {
        public void doSomething(String message)
        {
            Console.WriteLine("Message received:");
            Console.WriteLine(message);
        }
    }
}
