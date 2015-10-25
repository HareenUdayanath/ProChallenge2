using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankClient
{
    class Communicator
    {
        private static Communicator comm = new Communicator();
        

        private Communicator()
        {
        }

        public static Communicator GetInstance()
        {
            return comm;
        }
        
        public String receiveData()
        {
            TcpListener listner = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);
            string reply = null;
            listner.Start();
            Socket s = listner.AcceptSocket();
            if (s.Connected)
            {
                NetworkStream stream = new NetworkStream(s);
                List<Byte> inputStr = new List<byte>();
                //Console.WriteLine("connected to server");
                int asw = 0;
                while (asw != -1)
                {
                    asw = stream.ReadByte();
                    inputStr.Add((Byte)asw);
                }

                reply = Encoding.UTF8.GetString(inputStr.ToArray());
                //Console.WriteLine(reply);
                stream.Close();
                s.Close();
                listner.Stop();
            }
            return reply;
        }

        public void readAndSetData(Form1 form)
        {
            DecodeOperations dec = DecodeOperations.GetInstance();
            while (true)
            {
                try
                {
                    String msg = receiveData();
                    if (Constants.PLAYERSFULL.Equals(msg))
                    {
                        form.display(msg);                        
                    }
                    else if (Constants.ALREADYADDED.Equals(msg))
                    {
                        form.display(msg);                        
                    }
                    else if (Constants.GAMESTARTED.Equals(msg))
                    {
                        form.display(msg);                        
                    }
                   
                    dec.setMap(msg);
                    form.displayMap(dec.getMap());
                    form.displayBrickStates(dec.BrickList);
                    form.displayPlayers(dec.PlayerList);
                    
                    
                }catch(Exception e){
                    Console.WriteLine(e.Data);
                }
            }

        }
       
        /*
        public void getAndSend()
        {
            while (true)
            {
                Console.WriteLine("Data: ");
                String msg = Console.ReadLine();
                sendData(msg);
            }
        }*/
        public void sendData(String msgS)
        {

            TcpClient socket = new TcpClient();
            socket.Connect("127.0.0.1", 6000);
            if (socket.Connected)
            {
                NetworkStream stream = socket.GetStream();
                BinaryWriter writer = new BinaryWriter(stream);
                Byte[] msg = Encoding.ASCII.GetBytes(msgS);
                writer.Write(msg);
                Console.WriteLine("Request Sent");
                writer.Close();
                stream.Close();
                socket.Close();
            }
        }
    }

}
