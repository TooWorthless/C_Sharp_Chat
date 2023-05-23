namespace Client;


using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;

public partial class Form1 : Form
{

    // private Thread receiveThread;
    // private Thread checkThread;
    // private bool stopThreads = false;
    private string username = "";
    private string message = "";

    public Form1()
    {
        InitializeComponent();
    }

    // private void Form_Closing(object sender, FormClosingEventArgs e)
    // {
    //     // this.stopThreads = true;
    //     // Application.Exit();
    //     Environment.Exit(0);
    // }

    private void Form_Closing()
    {
        // this.stopThreads = true;
        if(this.username == "")
        {
            Application.Exit();
            Environment.Exit(0);
                    
        }
        else
        {
            this.message = "exit";
        }
    }

    private void Btn_Connect(object sender, EventArgs e)
    {
        Connect();
    }

    private void Btn_Send(object sender, EventArgs e)
    {
        if(this.username != "") 
        {
            this.message = this.tbMessage.Text;
        }
    }


    private void Connect()
    {
        try {
            this.username = this.tbName.Text;

            if(username == "") 
            {
                throw new Exception("Name Error");
            }

            TcpClient client = new TcpClient("127.0.0.1", 80);
            MessageBox.Show("Connection established...");

            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(username);
            stream.Write(buffer, 0, buffer.Length);

            // reader = new StreamReader(client.GetStream());
            Thread receiveThread = new Thread(() => ReceiveMessages(client));
            receiveThread.Start();

            Thread checkThread = new Thread(() => SendMessage(client));
            checkThread.Start();


            this.Controls.Remove(this.tbName);

            this.tbName.Dispose();
            // Удаляем кнопку из родительского контейнера
            this.Controls.Remove(this.btnConnect);

            // Освобождаем ресурсы кнопки
            this.btnConnect.Dispose();

            this.enterNameLabel.Text = "Your nickname - "+username;
            this.enterNameLabel.Font = new Font("Arial", 13, FontStyle.Regular);
            this.enterNameLabel.Size = new System.Drawing.Size(388, 30);
            this.enterNameLabel.Location = new System.Drawing.Point(16, 65);
        }
        catch(Exception ex)
        {
            MessageBox.Show("Connection error: " + ex.Message);
        }
    }


    private void ReceiveMessages(TcpClient client) 
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[256];

        while(true) 
        {
            try
            {
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                this.lbMessages.Items.Add(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Thread.Sleep(100);
        }  
    }

    private void SendMessage(TcpClient client) 
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[256];

        while(true) 
        {
            if(this.message != "") 
            {
                try 
                {
                    buffer = Encoding.UTF8.GetBytes(message);
                    stream.Write(buffer, 0, buffer.Length);
                }
                finally
                {
                    if(this.message == "exit")
                    {
                        Application.Exit();
                        Environment.Exit(0);
                    }
                    else
                    {
                        this.message = "";
                        this.tbMessage.Text = "";
                    }
                }

                this.message = "";
            }
            Thread.Sleep(100);
        }
    }

}
