using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server;


class Server {

    static List<Room> roomsList = new List<Room>();

    static List<TcpClient> clientsList = new List<TcpClient>();

    static void Main(string[] args) {
        roomsList.Add(new Room("General", "none"));


        IPAddress ip = IPAddress.Parse("127.0.0.1");
        int port = 3000;
                
        System.Console.WriteLine(ip.ToString());
        TcpListener server = new TcpListener(ip, port);
        server.Start();
        Console.WriteLine("Server started on " + ip.ToString() + ":" + port.ToString());

        while(true) {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client connected...");

            Task.Run(() => HandleClient(client));
        }
    }


    static void HandleClient(TcpClient client) 
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1048576];
        string username = "";
        string roomName = "";
        string roomPassword = "";

        while(true) {
            try 
            {
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytes);

                if(message == "exit") {
                    Console.WriteLine(username + " left the chat");
                    try
                    {
                        Room room = Room.getRoomByName(roomsList, roomName);
                        room.BroadcastMessage("Server", username + " left the chat", client);
                        room.removeUser(client);
                        if(room.getRoomName() != "General" && room.getUsersRoomListLength() <= 0) {
                            roomsList.Remove(room);
                        }
                    }
                    catch(Exception ex) 
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                    break;
                }
                else if(username == "") {
                    username = message.Split("|")[0];
                    roomName = message.Split("|")[1];
                    roomPassword = message.Split("|")[2];
                    
                    try
                    {
                        Room room = Room.getRoomByName(roomsList, roomName);

                        if(room.addUser(client, roomPassword)) {
                            SendMessage("ok", client);
                            room.BroadcastMessage("Server", username + " joined the chat", client);
                        }
                        else {
                            SendMessage("err", client);
                            username = "";
                            roomName = "";
                            roomPassword = "";
                        }
                    }
                    catch(Exception ex) 
                    {
                        try {
                            if(message.Split("|")[3] == "new") {

                                roomsList.Add(new Room(roomName, roomPassword));
                                Room room = Room.getRoomByName(roomsList, roomName);

                                if(room.addUser(client, roomPassword)) {
                                    SendMessage("ok", client);
                                    room.BroadcastMessage("Server", username + " joined the chat", client);
                                }
                                else {
                                    SendMessage("err", client);
                                    username = "";
                                    roomName = "";
                                    roomPassword = "";
                                }

                            }
                        }
                        catch {
                            SendMessage("err", client);
                            username = "";
                            roomName = "";
                            roomPassword = "";
                            System.Console.WriteLine(ex.ToString());
                        }
                        
                    }
                }
                else if(message == "img") {
                    byte[] imageSizeBytes = new byte[4];
                    stream.Read(imageSizeBytes, 0, imageSizeBytes.Length);
                    int imageSize = BitConverter.ToInt32(imageSizeBytes, 0);
                    System.Console.WriteLine(imageSize);

                    byte[] imageData = new byte[imageSize];
                    stream.Read(imageData, 0, imageData.Length);

                    try
                    {
                        Room room = Room.getRoomByName(roomsList, roomName);
                        room.lastImageData = imageData;
                        room.BroadcastMessage(username, "img", client);
                        Console.WriteLine(username + ": image.");
                    }
                    catch(Exception ex) 
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                }
                else if(message.Length <= 100) {
                    
                    Console.WriteLine(username + ": " + message);
                    try
                    {
                        Room room = Room.getRoomByName(roomsList, roomName);
                        room.BroadcastMessage(username, message, client);
                    }
                    catch(Exception ex) 
                    {
                        System.Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch 
            {
                break;
            }
            Thread.Sleep(100);
        }
    }


    static void SendMessage(string message, TcpClient client) 
    {
        try 
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }
        catch 
        {
            System.Console.WriteLine("Error");
        }
    }

}