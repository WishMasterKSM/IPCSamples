﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPCClient
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
