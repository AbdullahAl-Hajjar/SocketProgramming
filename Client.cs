using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        IPAddress ip = IPAddress.Parse("127.0.0.1");
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            client.Connect(ip, 8088);
            NetworkStream server = client.GetStream();
            int count = Encoding.ASCII.GetByteCount(message.Text);
            byte[] outStream = new byte[count];
            outStream = System.Text.Encoding.ASCII.GetBytes(message.Text);
            server.Write(outStream, 0, outStream.Length);
            server.Flush();
            server.Close();

        }

    }
}
