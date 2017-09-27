﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCServer
{
    class ServiceImpl : IServiceContract
    {
        public String getMessage()
        {
            return "Hello, World!";
        }

        public void doSomething(String message)
        {
            Console.WriteLine("Message received:");
            Console.WriteLine(message);
        }
    }
}
