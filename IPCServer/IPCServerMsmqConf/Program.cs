using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCServerMsmqConf
{
    class Program
    {
        static void Main(string[] args)
        {
            string queueName = ConfigurationManager.AppSettings["queueName"];

            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            var serviceHost = new ServiceHost(typeof(ServiceImpl));
            serviceHost.Open();

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
