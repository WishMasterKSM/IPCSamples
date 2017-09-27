using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using SelfHostedSample.ServiceModel;

namespace SelfHostedSample.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = "Hello, {0}!".Fmt(request.Name) };
        }

        public object Post(ServiceModel.Math request)
        {
            double result = 0;
            switch(request.Operation)
            {
                case MathOperation.Add:
                    result = request.arg1 + request.arg2;
                    break;
                case MathOperation.Sub:
                    result = request.arg1 - request.arg2;
                    break;
                case MathOperation.Mul:
                    result = request.arg1 * request.arg2;
                    break;
                case MathOperation.Div:
                    if (request.arg2 == 0.0)
                        throw new ArgumentNullException("arg2");
                    result = request.arg1 / request.arg2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Operation");
            }

            return new MathResponse { Result = result };
        }
    }
}