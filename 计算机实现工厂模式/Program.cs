using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算机实现工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input first number");
            string strNumberA = Console.ReadLine();
            Console.WriteLine("please input +、-、*、/");
            string operation = Console.ReadLine();
            Console.WriteLine("please input second number");
            string strNumberB = Console.ReadLine();
            Operation oper = null;
            oper = SimplyFactory.createOperate(operation);
            oper.numberA = Convert.ToDouble(strNumberA);
            oper.numberB = Convert.ToDouble(strNumberB);            
            Console.WriteLine("结果是:{0}",oper.GetResult().ToString());
            Console.ReadLine();
        }
    }
}
