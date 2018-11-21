C#异步编程模式

    .net framework支持异步调用方法，BeginInvoke 和EndInvoke是委托自动生成的方法
   
    BeginInvoke启用异步调用,该方法有与异步执行的方法相同的参数，另外还有两个可选参数
    
    第一个参数是AsyncCallback委托，该委托引用在异步调用完成时要调用的方法
    
    第二个参数是用户自定义的对象，该对象将信息传递给回调方法
    
    BeginInvoke返回一个IAsyncResult，后者可用于监视异步调用的进度
    
    EndIvoke(IAsyncResult)阻塞调用线程，直到异步调用结束
    

