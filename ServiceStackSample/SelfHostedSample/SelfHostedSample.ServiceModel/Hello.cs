using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace SelfHostedSample.ServiceModel
{
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
    }

    [Route("/math")]
    public class Math : IReturn<MathResponse>
    {
        public MathOperation Operation { get; set; }
        public double arg1 { get; set; }
        public double arg2 { get; set; }
    }

    public enum MathOperation
    {
        Add = 0,
        Sub,
        Mul,
        Div
    }

    public class MathResponse
    {
        public double Result { get; set; }
    }
}