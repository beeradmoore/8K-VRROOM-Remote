using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace VRROOMRemote;

public class TelnetConnection
{
    TcpClient tcpSocket;

    public TelnetConnection(string hostname, int port)
    {
        tcpSocket = new TcpClient();
        tcpSocket.Connect(hostname, port);
        var connected = tcpSocket.Connected;

        var opmode = GetOpmode();
        Console.WriteLine($"opmode: {opmode}");
        //tcpSocket.Connect(hostname, port);
    }

    int GetOpmode()
    {
        if (tcpSocket.Connected == false)
        {
            return -1;
        }

        // If there is stuff to be read, clear it all.
        if (tcpSocket.Available > 0)
        {
        }

        var buffer = System.Text.ASCIIEncoding.ASCII.GetBytes("get opmode\n");
        tcpSocket.GetStream().Write(buffer, 0, buffer.Length);

        return 1;
    }

    void Write()
    {
        var buffer = System.Text.ASCIIEncoding.ASCII.GetBytes("get opmode\n");
        tcpSocket.GetStream().Write(buffer, 0, buffer.Length);
    }

    void Read()
    {
        if (tcpSocket.Connected && tcpSocket.Available > 0)
        {
            var toRead = tcpSocket.Available;
            var buffer = new byte[tcpSocket.ReceiveBufferSize];
            var bytesRead = tcpSocket.GetStream().Read(buffer, 0, buffer.Length);

            Console.WriteLine($"toRead: {toRead}");
            Console.WriteLine($"bytesRead: {bytesRead}");

            var str = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"str: {str}");

            Debugger.Break();
        }
    }
}

