using UdpFun;

var serverThread = new Thread(_ => UdpServer.ListenForIncoming());
serverThread.Start();

Thread.Sleep(100);

UdpClient.SendAndReceive();