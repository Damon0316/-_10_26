using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算机实现工厂模式
{

    class Operation
    {
         public double numberA { get; set; }
         public double numberB { get; set; }
        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }

    class operationAdd : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = numberA + numberB;
            return result;
        }
    }

    class operationSub : Operation
    {
        public double GetResult()
        {
            return numberA - numberB;
        }
    }

    class operationMul : Operation
    {
        public double GetResult()
        {
            return numberA * numberB;
        }
    }

    class operationDiv : Operation
    {
        public double GetResult()
        {
            return numberA / numberB;
        }
    }

    class SimplyFactory
    {
        public static Operation createOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    {
                        oper = new operationAdd();
                        break;
                    }
                case "-":
                    {
                        oper = new operationSub();
                        break;
                    }
                case "*":
                    {
                        oper = new operationAdd();
                        break;
                    }
                case "/":
                    {
                        oper = new operationSub();
                        break;
                    }
            }
            return oper;
        }
    }
}
