using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpFun;

public static class UdpServer
{
    public static void ListenForIncoming()
    {
        using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(IPEndPoint.Parse("127.0.0.1:10020"));
        var bytes = new byte[1000];

        var flags = SocketFlags.None;
        EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
        var size = socket.ReceiveMessageFrom(bytes, ref flags, ref remoteEP, out var packetInformation);

        Console.WriteLine($"SERVER RECEIVED: {Encoding.ASCII.GetString(bytes[..size])}");

        socket.SendTo(bytes, 0, size, SocketFlags.None, remoteEP);
    }
}