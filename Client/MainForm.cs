namespace Client;


using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;

public partial class MainForm : Form
{

    // private Thread receiveThread;
    // private Thread checkThread;
    // private bool stopThreads = false;
    private string username = "";
    private string room = "";
    private string message = "";
    private string imagePath;

    // private byte[][] imageArray;

    public MainForm()
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
        if(this.username == "" || this.room == "")
        {
            Application.Exit();
            Environment.Exit(0);
                    
        }
        else
        {
            this.message = "exit";
        }
    }

    private void Btn_SetName(object sender, EventArgs e)
    {
        SetName();
    }

    private void Btn_ConnectGeneral(object sender, EventArgs e)
    {
        Connect("General", "");
    }

    private void Btn_Connect(object sender, EventArgs e)
    {
        string roomName = roomsPanel.getTbRoomNameValue();
        string roomPassword = roomsPanel.getTbRoomPasswordValue();
        Connect(roomName, roomPassword);
    }

    private void Btn_Send(object sender, EventArgs e)
    {
        if(this.username != "") 
        {
            this.message = chatPanel.getInputField().Text;
        }
    }
    

    private void btnLoadImage_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files (*.png, *.jpg)|*.png;*.jpg";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            imagePath = openFileDialog.FileName;
        }
    }
    private void btnSend_Click(object sender, EventArgs e)
    {
        if (imagePath != null)
        {
            this.message = "img";
        }
        else
        {
            MessageBox.Show("Choose image first!");
        }
    }



    private void SetName()
    {
        try 
        {
            this.username = namePanel.getTbNameValue();

            if(username == "") {
                throw new Exception("Incorrect entered name!");
            }

            this.Controls.Remove(namePanel);
            namePanel.Dispose();

            this.Controls.Add(roomsPanel);
            roomsPanel.setTitleText(roomsPanel.getTitleText() + " : " + username);
        }
        catch(Exception ex)
        {
            MessageBox.Show("Name error: " + ex.Message);
        }
    }


    private void Connect(string roomName, string roomPassword)
    {
        try 
        {
            if(this.username != "") {
                if(roomName == "")  {
                    throw new Exception("Incorrect room name!");
                }
                if(roomPassword == "") {
                    roomPassword = "none";
                }

                TcpClient client = new TcpClient("127.0.0.1", 3000);
                

                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(username + "|" + roomName + "|" + roomPassword);
                stream.Write(buffer, 0, buffer.Length);

                try
                {
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                    if(message == "err") {
                        throw new Exception("Incorrect data");
                    }
                    else {
                        MessageBox.Show("Connection established...");
                        room = roomName;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    roomsPanel.setTbRoomNameValue("");
                    roomsPanel.setTbRoomPasswordValue("");
                    return;
                }

                Thread receiveThread = new Thread(() => ReceiveMessages(client));
                receiveThread.Start();

                Thread checkThread = new Thread(() => SendMessage(client));
                checkThread.Start();
            }

            chatPanel.setTitleText(roomsPanel.getTitleText() + ". Room : " + roomName);

            this.Controls.Remove(roomsPanel);
            roomsPanel.Dispose();

            this.Controls.Add(chatPanel);
            this.Size = new Size(940, 475);

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler((object sender, KeyEventArgs e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    if(this.username != "") 
                    {
                        this.message = chatPanel.getInputField().Text;
                    }
                }
            });

        }
        catch(Exception ex)
        {
            MessageBox.Show("Room connection error: " + ex.Message);
        }
    }


    private void CreateRoom(string name, string password) 
    {
        this.message = "room|" + name + "|" + password;
    }


    private void ReceiveMessages(TcpClient client) 
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1048576];

        while(true) 
        {
            try
            {
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                if(message == "img") {
                    chatPanel.getLastImageBox().Refresh();
                    byte[] imageSizeBytes = new byte[4];
                    stream.Read(imageSizeBytes, 0, imageSizeBytes.Length);
                    int imageSize = BitConverter.ToInt32(imageSizeBytes, 0);
                    byte[] imageData = new byte[imageSize];
                    stream.Read(imageData, 0, imageData.Length);

                    try {
                        using (MemoryStream memoryStream = new MemoryStream(imageData))
                        {
                            Bitmap bitmap = new Bitmap(memoryStream);

                            chatPanel.getLastImageBox().BringToFront();
                            chatPanel.getLastImageBox().Image = bitmap;
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                    this.message = "";
                }
                else {
                    try 
                    {
                        if(message.Split(":")[1] == " sent an image!") {
                            chatPanel.setImageSenderName(message.Split(":")[0]);
                            chatPanel.getMessages().Items.Add(message);
                        }
                        else {
                            chatPanel.getMessages().Items.Add(message);
                        }
                    }
                    catch
                    {
                        this.message = "";
                    }
                }
            }
            catch(Exception ex)
            {
                this.message = "";
                MessageBox.Show(ex.Message);
            }
            Thread.Sleep(100);
        }  
    }

    private void SendMessage(TcpClient client) 
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1048576];

        while(true) 
        {
            if(this.message != "") 
            {
                try 
                {
                    if(this.message == "img") {
                        
                        buffer = Encoding.UTF8.GetBytes(message);
                        stream.Write(buffer, 0, buffer.Length);

                        byte[] imageData = File.ReadAllBytes(imagePath);

                        byte[] imageSizeBytes = BitConverter.GetBytes(imageData.Length);
                        stream.Write(imageSizeBytes, 0, imageSizeBytes.Length);

                        stream.Write(imageData, 0, imageData.Length);

                        this.imagePath = null;

                        Thread.Sleep(1000);
                    }
                    else {
                        buffer = Encoding.UTF8.GetBytes(message);
                        stream.Write(buffer, 0, buffer.Length);
                    }
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
                        chatPanel.getInputField().Text = "";
                    }
                }

                this.message = "";
            }
            Thread.Sleep(100);
        }
    }



    private Image ByteArrayToImage(byte[] imageData)
    {
        using (MemoryStream ms = new MemoryStream(imageData))
        {
            Image image = Image.FromStream(ms);
            return image;
        }
    }
}


