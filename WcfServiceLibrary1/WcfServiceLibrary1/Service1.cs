using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        double IService1.avg(double[] num)
        {

            double result = num.Average();
            return result;
        }


        int IService1.divide(int num1, int num2)
        {
            int result = num1 / num2;
            Console.WriteLine(result);
            return result;
        }

        string IService1.GetData(int value)
        {
            string result = value.ToString();
            return result;
        }

        CompositeType IService1.GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        Tuple<string, int> IService1.max(double[] num)
        {
            throw new NotImplementedException();
        }

        /* Tuple<string, int> IService1.max(double[] num)
         {
             double myMaxValue = num.Max();

             return myMaxValue;
         }*/

        int IService1.multiply(int num1, int num2)
        {
            int result = num1 * num2;
            Console.WriteLine(result);
            return result;
        }

        int IService1.substract(int num1, int num2)
        {
            int result = num1 - num2;
            Console.WriteLine(result);
            return result;
        }

        int IService1.sum(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine(result);
            return result;
        }

        int IService1.totalsum(int[] num)
        {
            int total = 0;
            int result = 0;

            for (int i = 0; i < num.Length; i++)
            {
                total += num[i];
            }

            Console.WriteLine(total);
            return total;
        }
    }
}
