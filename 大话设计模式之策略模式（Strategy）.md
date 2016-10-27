大话设计模式之策略模式（Strategy）
===================
##体现在商场收银系统的Demo：

###1. 定义
策略是为达到某一目的而采取的收单或方法，比如超市购物会有很多促销活动，但是都是为了获得要支付的金额。模式的目的在于将目标和结果分离开来，。毕竟客户只关注最后要支付多少钱。


###2. 使用频率
   中高

###简单工厂模式结构   
   ![此处输入图片的描述][1]

简单工厂模式参与者：
<i class="icon-male"></i>Strategy：定义所支持的算法的公共接口，Context使用这个接口来调用某个ConcreteStrategy定义的算法
```
    class CashSuper
    {
        public virtual double acceptCash(double money);
    }
```
<i class="icon-male"></i>ConcreteStrategy :具体策略，实现Strategy的具体方法
```
     class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;
        public CashRebate(string moneyRebate)
        {
            this.moneyRebate = Convert.ToDouble(moneyRebate);
        }
        public override double acceptCash(double money)
        {
            return money * moneyRebate;
        }

    }

    class CashReturn : CashSuper
    {
        private double moneyCondition = 0.0d;
        private double moneyReturn = 0.0d;
        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this.moneyCondition = Convert.ToDouble(moneyCondition);
            this.moneyReturn = Convert.ToDouble(moneyReturn);
        }
        public override double acceptCash(double money)
        {
            double result = money;
            if (money >= moneyCondition)
            {
                result = money - moneyReturn;
            }
            return money;
        }
    }
```
<i class="icon-male"></i>Context ：

 1. 写一个构造方法，参数为父类抽象出来的（Strategy）类的对象
 2. 写一个普通方法，来调用Stragety中抽象出来的方法（即最终的结果）
 3. 最后在客户端去实例化Context的构造方法，通过动态绑定的方式将具体策略当作参数传给Context的对象
```
    class CashContext
    {
        private CashSuper cs;
        public CashSuper(CashSuper csuper)
        {
        this.cs = csuper;
        }
        public double GerResult(double money)
        {
        return cs.acceptCash(money);
        }
    }
```

###3策略模式应用分析
策略模式适用情形：

 - 如果在一个系统里有许多类，即有许多的方法去完成最终所要达到的要求，他们的区别仅仅区别在于他们的行为
 - 一个系统需要动态的在几种算法中选择一种。这些具体算法类均有统一的接口。
 - 一个系统算法使用的数据不可以让客户端知道
 - 如果一个对象有很多的行为方法，如果不用策略模式，必然会进行多重的条件语句来实现。

优点

 1. 使用继承把公共的代码移到父类里面，从而避免重复的代码
 2. 避免多重条件判断语句

缺点

 1. 客户端必须知道所有的策略类，并自行决定使用哪一个策略类。所以它只适用于客户端知道所有的算法或行为的情况。
 2. 策略模式造成了很多的策略类。
 
  [1]: http://images.cnblogs.com/cnblogs_com/QinBaoBei/WindowsLiveWriter/798b306f9119_AA49/image_10.png