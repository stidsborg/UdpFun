using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpFun;

public static class UdpClient
{
    public static void SendAndReceive()
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress serverAddr = IPAddress.Parse("127.0.0.1");
        IPEndPoint endPoint = new IPEndPoint(serverAddr, 10020);

        var receiveBuffer = new byte[1000];
        string text = "Hello World";
        byte[] send_buffer = Encoding.ASCII.GetBytes(text);

        sock.SendTo(send_buffer, endPoint);
        var flags = SocketFlags.None;
        EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
        var size = sock.ReceiveMessageFrom(receiveBuffer, ref flags, ref remoteEP, out var packetInformation);

        Console.WriteLine($"CLIENT RECEIVED: {Encoding.ASCII.GetString(receiveBuffer[..size])}");
    }
}