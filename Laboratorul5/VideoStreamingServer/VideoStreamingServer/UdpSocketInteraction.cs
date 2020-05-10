using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VideoStreamingServer
{  
        public class UdpSocketInteraction
        {
            private Socket udpSocket;
            private EndPoint remotePoint;

            private int PacketId;

            private int OnePacketSize = 240;

            public UdpSocketInteraction()
            {
                udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                remotePoint = new IPEndPoint(IPAddress.Parse(Settings.address), Settings.port);

                PacketId = 0;
            }

            public void SendData(byte[] data)
            {
                int countOfPackages = (data.Length + OnePacketSize - 1) / OnePacketSize;

                int currentPackage = 0;
                int sendedBytes = 0;

                while(currentPackage != countOfPackages)
                {
                    byte[] subsetData = data.Skip(sendedBytes).Take(OnePacketSize).ToArray();
                    
                    byte[] PacketIdByte = BitConverter.GetBytes(PacketId); 
                    byte[] CurrentPackageByte = BitConverter.GetBytes(currentPackage);
                    byte[] CountOfPackagesByte = BitConverter.GetBytes(countOfPackages);

                    byte[] DataForSend = PacketIdByte.Concat(CurrentPackageByte).Concat(CountOfPackagesByte).Concat(subsetData).ToArray();

                    udpSocket.SendTo(DataForSend, remotePoint);

                    sendedBytes += OnePacketSize;
                    currentPackage += 1;
                }

                PacketId += 1;
            }
        }
}
