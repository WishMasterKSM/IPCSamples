using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EchoServer
{
    class Client
    {
        public const int MAX_RECV_SIZE = 65536;
        public static String echo(String message)
        {
            String result = null;
            try
            {
                TcpClient cl = new TcpClient();
                cl.Connect("localhost", 8888);

                NetworkStream stream = cl.GetStream();
                byte[] message_bytes = Encoding.Default.GetBytes(message);
                stream.Write(message_bytes, 0, message_bytes.Length);
                stream.Flush();

                byte[] received = new byte[MAX_RECV_SIZE];
                stream.Read(received, 0, MAX_RECV_SIZE);
                result = Encoding.Default.GetString(received).Replace("\0", String.Empty);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
    }
}
