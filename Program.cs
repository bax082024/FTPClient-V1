using System;
using System.Net.Sockets;
using System.Text;

class FTPClient
{
    static void Main()
    {
        static void Main()
        {
            Console.WriteLine("Connecting to FTP Server...");

            TcpClient client = new TcpClient("127.0.0.1", 2121);
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));

            while (true)
            {
                Console.Write("Enter command (LIST, UPLOAD, DOWNLOAD, QUIT): ");
                string command = Console.ReadLine();

                byte[] data = Encoding.ASCII.GetBytes(command + "\n");
                stream.Write(data, 0, data.Length);

                if (command.ToLower() == "quit") break;

                bytesRead = stream.Read(buffer, 0, buffer.Length);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
            }

            client.Close();
        }


    }


}