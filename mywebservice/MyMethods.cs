using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using log4net;

namespace mywebservice
{
    public class MyMethods
    {
        [WebMethod]
        public static double Fibonacci(int n)
        {
            // la valeur de retour doit être un double car les grandes valeurs retournées dépassent la valeur maxint
            double returnValue;

            // booléen à définir pour choisir la méthode à utiliser
            // TRUE = Suite de fibonacci pré définie dans le code
            // FALSE = Suite de fibonacci recalculée à chaque appel
            bool bNoCalculation = true;

            if (bNoCalculation)
            {
                // méthode sans calcul (car la suite de fibonacci commençant par 1 et 1 ne changera jamais)
                const string fibonacciString = "-1,1,1,2,3,5,8,13,21,34,55,89,144, 233, 377, 610, 987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,514229,832040,1346269,2178309,3524578,5702887,9227465,14930352,24157817,39088169,63245986,102334155,165580141,267914296,433494437,701408733,1134903170,1836311903,2971215073,4807526976,7778742049,12586269025,20365011074,32951280099,53316291173,86267571272,139583862445,225851433717,365435296162,591286729879,956722026041,1548008755920,2504730781961,4052739537881,6557470319842,10610209857723,17167680177565,27777890035288,44945570212853,72723460248141,117669030460994,190392490709135,308061521170129,498454011879264,806515533049393,1304969544928657,2111485077978050,3416454622906707,5527939700884757,8944394323791464,14472334024676221,23416728348467685,37889062373143906,61305790721611591,99194853094755497,160500643816367088,259695496911122585,420196140727489673,679891637638612258,1100087778366101931,1779979416004714189,2880067194370816120,4660046610375530309,7540113804746346429,12200160415121876738,19740274219868223167,31940434634990099905,51680708854858323072,83621143489848422977,135301852344706746049,218922995834555169026,354224848179261915075";
                string[] fibonacciArray = fibonacciString.Split(",".ToCharArray());
                returnValue = double.Parse(fibonacciArray[((n >= 1) && (n <= 100)) ? n : 0]);
            }
            else
            {
                // méthode avec calcul de la valeur demandée 
                double[] fiboArray = new double[((n >= 1) && (n <= 100)) ? n + 1 : 2];
                fiboArray[0] = 0;
                fiboArray[1] = 1;
                if ((n > 1) && (n < 101))
                {
                    for (int i = 2; i <= n; i++)
                        fiboArray[i] = fiboArray[i - 1] + fiboArray[i - 2];
                }
                fiboArray[0] = -1;

                returnValue = fiboArray[((n >= 1) && (n <= 100)) ? n : 0];
            }

            return returnValue;
        }

        [WebMethod]
        public static string XmlToJson(string xml)
        {
            const string msgErreur = "Bad Xml format";
            string returnValue;
            if (Log.For(xml) != null)
            {
                Log.For(xml).Info("texte xml : " + xml);
            }
                

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                
                returnValue = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
                if (Log.For(returnValue) != null)
                {
                    Log.For(returnValue).Info(returnValue);
                }
            }
            catch (XmlException)
            {
                returnValue = msgErreur;
                if (Log.For(returnValue) != null)
                {
                    Log.For(returnValue).Error(returnValue);
                }

            }

            return returnValue;
        }
    }
}