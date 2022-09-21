using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VTOL
{
    public abstract class PaperTrail_Crutch
    {
        protected IPAddress ip;
        protected int port;
        protected string url;

        public PaperTrail_Crutch(string url, int port)
        {
            IPAddress[] addr = Dns.GetHostAddresses(url);
            ip = addr[0];
            this.url = url;
            this.port = port;
        }

        public abstract void Open();
        public abstract void Close();
        public abstract void Log(string message);
    }

    public class UdpPaperTrailLogger : PaperTrail_Crutch
    {
        protected Socket socket;
        protected IPEndPoint endPoint;

        public UdpPaperTrailLogger(string url, int port)
          : base(url, port)
        {
        }

        public override void Open()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endPoint = new IPEndPoint(ip, port);
        }

        public override void Close()
        {
            socket.Close();
        }

        public override void Log(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            socket.SendTo(buffer, endPoint);
            socket.Close();
        }
    }

    public class TlsPaperTrailLogger : PaperTrail_Crutch
    {
        protected TcpClient client;
        protected SslStream sslStream;

        public TlsPaperTrailLogger(string url, int port)
          : base(url, port)
        {
        }

        public override void Open()
        {
            client = new TcpClient(url, port);
            sslStream = new SslStream(client.GetStream(), false, ValidateServerCertificate, null);
            sslStream.AuthenticateAsClient(url);
        }

        public override void Close()
        {
            sslStream.Close();
            client.Close();
        }

        public override void Log(string message)
        {
            const string CRLF = "\r\n";

            byte[] buffer = Encoding.UTF8.GetBytes(message + CRLF);
            sslStream.Write(buffer);
            sslStream.Flush();
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return sslPolicyErrors == SslPolicyErrors.None;
        }
    }
}