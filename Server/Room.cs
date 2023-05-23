using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server;


class Room
{
    private List<TcpClient> clientsList = new List<TcpClient>();

    public byte[] lastImageData;

    private string name;
    private string password;


    public Room(string name)
    {
        if(name.Length != 0) {
            this.name = name;
            this.password = "";
        }
    }

    public Room(string name, string password) 
    {
        if(name.Length != 0 && password.Length != 0) {
            this.name = name;
            this.password = password;
        }
    }




    public string getRoomName()
    {
        return this.name;
    }
    public string getRoomPassword()
    {
        return this.password;
    }
    public bool addUser(TcpClient user, string password) {
        if(this.password == password) {
            clientsList.Add(user);
            return true;
        }
        else {
            return false;
        }
    }

    public void removeUser(TcpClient user) {
        clientsList.Remove(user);
    }

    public int getUsersRoomListLength() {
        int iter = 0;
        foreach(TcpClient client in clientsList) {
            iter++;
        }
        return iter;
    }


    public void BroadcastMessage(string username, string message, TcpClient excludeClient) 
    {
        foreach(TcpClient client in clientsList) {
            try 
            {
                string msg;
                if(client != excludeClient) {
                    msg = username + ": " + message;
                }
                else 
                {
                    msg = "Me: " + message;
                }

                if(message == "img") {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    stream.Write(buffer, 0, buffer.Length);

                    if(lastImageData != null) {
                        byte[] imageSizeBytes = BitConverter.GetBytes(lastImageData.Length);
                        stream.Write(imageSizeBytes, 0, imageSizeBytes.Length);

                        stream.Write(lastImageData, 0, lastImageData.Length);
                        // lastImageData = null;
                    }

                    buffer = Encoding.UTF8.GetBytes(username + ": sent an image!");
                    stream.Write(buffer, 0, buffer.Length);
                }
                else {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = Encoding.UTF8.GetBytes(msg);
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch 
            {
                System.Console.WriteLine("User Error");
            }
        }
    }


    public static Room getRoomByName(List<Room> rooms, string roomName) 
    {
        Room foundRoom = null;

        foreach (Room room in rooms) {
            if(room.getRoomName() == roomName) {
                foundRoom = room;
                break;
            }
        }

        if(foundRoom == null) {
            throw new Exception("Incorrect room name!");
        }
        else {
            return foundRoom;
        }
    }
}