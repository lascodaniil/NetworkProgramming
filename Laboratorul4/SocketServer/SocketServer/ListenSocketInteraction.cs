using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketServer
{
    public class ListenSocketInteraction
    {
        public Socket listenSocket;
        public IPEndPoint ipPoint;

        public Dictionary<string, Socket> connectedUsers;
        public Dictionary<string, Socket> usersSockets;
        public Dictionary<Socket, string> userLogin;
        public List<string> loginList;

        public string login = "";

        public ListenSocketInteraction()
        {
            ipPoint = new IPEndPoint(IPAddress.Parse(Settings.address), Settings.port);
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            connectedUsers = new Dictionary<string, Socket>();
            usersSockets = new Dictionary<string, Socket>();
            userLogin = new Dictionary<Socket, string>();
            loginList = new List<string>(); 

            try
            {
                listenSocket.Bind(ipPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            listenSocket.Listen(Settings.connectionsAbailable);
        }


        public void requestPending()
        {
            Socket handler = listenSocket.Accept();

            Console.WriteLine("User successfully connected!");

            Thread manager = new Thread(new ThreadStart(() => requestManager(handler)));
            manager.Start();
        }

        public void requestManager(Socket handler)
        {
            try
            {
                while (true)
                {
                    waitingAnswer(handler);
                }
            } catch(Exception)
            {
                closeConnection(handler);
                return;
            }
        }
    

        public void sendMessage(Socket handler, string message)
        {
            Packet packet = new Packet();
            packet = Protocol.ConfigurePacket(Command.TEXT, "Server", Encoding.Unicode.GetBytes(message));

            handler.Send(packet.MetaBytes());
            handler.Send(packet.Response);
        }

        public void waitingAnswer(Socket handler)
        {

            StringBuilder builder = new StringBuilder();
            int bytes = 0; 

            byte[] metaData = new byte[256];
            bytes = handler.Receive(metaData);

            Dictionary<string, string> meta = Protocol.ParseMeta(Encoding.UTF8.GetString(metaData, 0, bytes));

            if (userLogin.ContainsKey(handler) is true) login = userLogin[handler];

            switch (Enum.Parse(typeof(Command), meta["Command"]))
            {
                case Command.LOGIN:

                    loginList.Add(meta["User"]); 
                    login = meta["User"]; 
                    usersSockets[login] = handler; 
                    userLogin[handler] = login; 
                    break;

                case Command.TEXT:

                    Packet packet = new Packet();
                    if (haveConnect(login) == false)
                    {
                        string message = getTextRequest(handler);
                        sendMessage(handler, "You dont have user to connect!");
                        break;
                    }

                    string text = getTextRequest(handler);

   
                    packet = Protocol.ConfigurePacket(Command.TEXT, login, Encoding.Unicode.GetBytes(text));
                    connectedUsers[login].Send(packet.MetaBytes());
                    connectedUsers[login].Send(packet.Response);

                    break;
                case Command.BIN:
                    if (haveConnect(login) == false)
                    {
                        string message = getTextRequest(handler);
                        sendMessage(handler, "You dont have user to connect!");
                        break;
                    }
                    parseBinRequest(handler, meta);
                    break;

                case Command.UTILS:
                    string addData = getTextRequest(handler);

                    parseUtilsRequest(handler, meta["Utils"], addData);
                    break;
            }
            return;
        }

   
        static string getTextRequest(Socket handler)
        {
            StringBuilder builder = new StringBuilder();
            do
            {
                byte[] data = new byte[256];
                int bytes = handler.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (handler.Available > 0);

            return builder.ToString();
        }

        public void parseBinRequest(Socket handler, Dictionary<string, string> meta)
        {
            List<byte[]> list = new List<byte[]>();
            int countOfAllBytes = 0;

            do
            {
                byte[] data = new byte[256];
                countOfAllBytes += handler.Receive(data, data.Length, 0);

                list.Add(data);
            }
            while (handler.Available > 0);

            byte[] allData = list
                            .SelectMany(a => a)
                            .ToArray();

            Packet packet = new Packet();

            if (meta.ContainsKey("Utils") == true) packet = Protocol.ConfigurePacket(Command.BIN, login, meta["Utils"], allData);
            else packet = Protocol.ConfigurePacket(Command.BIN, login, allData);

            connectedUsers[login].Send(packet.MetaBytes());
            connectedUsers[login].Send(packet.Response);

        }

        public void parseUtilsRequest(Socket handler, string utils, string message)
        {
            if (utils.ToLower() == "get")
            {
                string answer = "";
                answer += $"Count of all users = {loginList.Count}\n";

                foreach (var user_name in loginList)
                {
                    if (user_name == login) answer += $"Login: {user_name} <---- It's you\n";
                    else answer += $"Login: {user_name}\n";
                }

                sendMessage(handler, answer);
            }
            if (utils.ToLower() == "connect")
            {
                string user_name = message;
                if (loginList.Contains(user_name) is false)
                {
                    sendMessage(handler, "Wrong login!");
                }
                else
                {
                    sendMessage(handler, "Successful connection");
                    connectedUsers[login] = usersSockets[user_name];
                }
            }
            if (utils.ToLower() == "disconnect")
            {
                connectedUsers.Remove(login);

            }
        }

        public bool haveConnect(string login)
        {
            if (connectedUsers.ContainsKey(login) == false) return false;
            return true;
        }

        public void closeConnection(Socket handler)
        {
            
            loginList.Remove(login);
            connectedUsers[login] = null;
            usersSockets.Remove(login);

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            Console.WriteLine("User disconnected");
        }
    }
}
