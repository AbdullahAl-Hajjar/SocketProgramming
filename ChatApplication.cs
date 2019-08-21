using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace ChatApplication
{
    class ChatApplication
    {
        static void Main(string[] args)
        {

            TcpListener server = new TcpListener(IPAddress.Any, 8088);
            TcpClient client = default(TcpClient);

     

            try
            {
                server.Start();
                Console.WriteLine("Server Strating!");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Read();
            }

            while(true)
            {
                client= server.AcceptTcpClient();

                byte[] unit = new byte[500];
                NetworkStream stream = client.GetStream();

                stream.Read(unit, 0, unit.Length);
                string msg = null;
                foreach (byte b in unit)
                {
                    if (b != 0)
                        msg += Convert.ToChar(b);
                }

                Console.WriteLine(msg);
                


            }
        }
    }
}
