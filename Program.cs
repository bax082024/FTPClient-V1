using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

class FTPClient
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("Connecting to FTP Server...");

        TcpClient client = new TcpClient("127.0.0.1", 2121);
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));

        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        stream.Write(Encoding.ASCII.GetBytes(username + "\n"), 0, username.Length + 1);

        bytesRead = stream.Read(buffer, 0, buffer.Length);
        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));

        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        stream.Write(Encoding.ASCII.GetBytes(password + "\n"), 0, password.Length + 1);

        bytesRead = stream.Read(buffer, 0, buffer.Length);
        string serverResponse = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine(serverResponse);

        if (!serverResponse.Contains("successful"))
        {
            Console.WriteLine("Login failed. Exiting...");
            client.Close();
            return;
        }

        while (true)
        {
            Console.Write("Enter command (LIST, UPLOAD, DOWNLOAD, QUIT): ");
            string command = Console.ReadLine();

            if (command.ToLower().StartsWith("upload"))
            {
                Console.Write("Enter path to file for upload: ");
                string filePath = Console.ReadLine();
                if (File.Exists(filePath)) UploadFile(stream, filePath);
                else Console.WriteLine("File not found.");
                continue;
            }

            if (command.ToLower().StartsWith("download"))
            {
                Console.Write("Enter file name to download: ");
                string fileName = Console.ReadLine();
                Console.Write("Enter destination folder: ");
                string folder = Console.ReadLine();
                if (Directory.Exists(folder)) DownloadFile(stream, fileName, folder);
                else Console.WriteLine("Invalid folder path.");
                continue;
            }

            stream.Write(Encoding.ASCII.GetBytes(command + "\n"), 0, command.Length + 1);
            if (command.ToLower() == "quit") break;

            bytesRead = stream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
        }

        client.Close();
    }

    static void UploadFile(NetworkStream stream, string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        stream.Write(Encoding.ASCII.GetBytes($"upload {fileName}\n"), 0, ($"upload {fileName}\n").Length);
        byte[] fileData = File.ReadAllBytes(filePath);
        stream.Write(fileData, 0, fileData.Length);
        Console.WriteLine($"Uploaded {fileName}");
    }

    static void DownloadFile(NetworkStream stream, string fileName, string folder)
    {
        stream.Write(Encoding.ASCII.GetBytes($"download {fileName}\n"), 0, ($"download {fileName}\n").Length);
        string filePath = Path.Combine(folder, fileName);
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, bytesRead);
                if (bytesRead < buffer.Length) break;
            }
        }
        Console.WriteLine($"Downloaded {fileName} to {folder}");
    }
}
