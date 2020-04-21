using SocketUser;
using System;
using System.Threading;

namespace SocketUser2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    SocketInteraction socketInteraction = new SocketInteraction();

                    socketInteraction.Connect();

                    socketInteraction.Login();

                    Thread acceptMessageManager = new Thread(new ThreadStart(() =>
                    {
                        while (true)
                            socketInteraction.getAnswer();
                    }));

                    acceptMessageManager.Start();

                    while (true)
                    {

                        socketInteraction.sendMessage();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
