using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void TestFibonacci()
        {

            double resultat = mywebservice.MyMethods.Fibonacci(-1);
            resultat = mywebservice.MyMethods.Fibonacci(0);
            resultat = mywebservice.MyMethods.Fibonacci(10);
            resultat = mywebservice.MyMethods.Fibonacci(99);
            resultat = mywebservice.MyMethods.Fibonacci(100);
            resultat = mywebservice.MyMethods.Fibonacci(101);

        }

        [TestMethod]
        public void Testjson()
        {
            string resultat = mywebservice.MyMethods.XmlToJson("<foo>bar</foo>");
            resultat = mywebservice.MyMethods.XmlToJson("<foo>hello</ba>");
        }
    }
}
