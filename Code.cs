using System;

namespace AsnycDelegateTest2
{
    /// <summary>
    /// .net framework支持异步调用方法，BeginInvoke 和EndInvoke是委托自动生成的方法
    /// 
    /// BeginInvoke启用异步调用,该方法有与异步执行的方法相同的参数，另外还有两个可选参数，
    /// 第一个参数是AsyncCallback委托，该委托引用在异步调用完成时要调用的方法。
    /// 第二个参数是用户自定义的对象，该对象将信息传递给回调方法。
    /// BeginInvoke返回一个IAsyncResult，后者可用于监视异步调用的进度。
    /// 
    /// EndIvoke(IAsyncResult)阻塞调用线程，直到异步调用结束
    /// </summary>

    class Program
    {
        public static int Caculate(int a, int b)
        {
            System.Threading.Thread.Sleep(3000);
            int c = a + b;
            return c;
        }

        //声明委托，绑定委托方法（实例化委托）
        static Func<int, int, int> func = Caculate;

        public static void ShowFolderSize(IAsyncResult result)
        {
            int c = func.EndInvoke(result);//EndInvole 取回方法执行的结果
            var name = (String)result.AsyncState;//获取传递的参数 "henry"
            Console.WriteLine("transfer name is: {0}.", name);
            Console.WriteLine("Finish Caculate,Result:{0}", c);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("-----Application Start-------");

            //BeginInvoke启用异步调用
            //2,3为传递给委托方法Caculate的两个参数
            //ShowFolderSize,Caculate调用结束后调用它
            //“henry”传递给回调方法ShowFolderSize的参数
            IAsyncResult result = func.BeginInvoke(2, 3, ShowFolderSize, "henry");

            Console.WriteLine("Start Caculate----");

            Console.WriteLine("-----Application End-------");

            Console.ReadKey();
        }
    }
}
