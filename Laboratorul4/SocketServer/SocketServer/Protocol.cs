﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace SocketServer
{

    enum Command { LOGIN, TEXT, BIN, UTILS };

    struct Packet
    {
        public Dictionary<string, string> Meta;
        public byte[] Response;
        public override string ToString()
        {
            string result = Encoding.UTF8.GetString(this.MetaBytes());
            result += Encoding.UTF8.GetString(this.Response);
            return result;
        }

        public byte[] MetaBytes()
        {
            string result = "";
            foreach (KeyValuePair<string, string> pair in this.Meta)
            {
                result += pair.Key;
                result += ": ";
                result += pair.Value;
                result += "\n";
            }
            result += "\n";
            return Encoding.UTF8.GetBytes(result);
        }
    };

   

    class Protocol
    {
       
        string[] AllowedHeaders = { "Command", "User", "Utils" };

       
        public static Packet ConfigurePacket(Command command, string username, byte[] message)
        {
            Dictionary<string, string> format = new Dictionary<string, string>();
            format.Add("Command", command.ToString());
            format.Add("User", username);

            Packet packet = new Packet();
            packet.Meta = format;
            packet.Response = message;
            return packet;
        }

        public static Packet ConfigurePacket(Command command, string username, string utils, byte[] message)
        {
            Dictionary<string, string> format = new Dictionary<string, string>();
            format.Add("Command", command.ToString());
            format.Add("User", username);
            format.Add("Utils", utils);

            Packet packet = new Packet();
            packet.Meta = format;
            packet.Response = message;
            return packet;
        }
        public static Dictionary<string, string> ParseMeta(string buffer)
        {

            Regex metaParser = new Regex("([A-Za-z 0-9]+): +(.+)"); 
            Match match = metaParser.Match(buffer);

            Dictionary<string, string> meta = new Dictionary<string, string>();

            while (match.Success) 
            {
                string header = match.Groups[1].Value; 
                string value = match.Groups[2].Value; 

                meta.Add(header, value);
                match = match.NextMatch(); 
            }
            return meta;
        }
    }
}
