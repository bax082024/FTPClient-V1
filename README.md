# FTP Server and Client Project

This project is a simple **FTP Server and Client** built with **C# (.NET 8)**, supporting file transfers over a network.

---

## **Features**
- **FTP Server**:
  - Handles multiple client connections simultaneously.
  - User authentication with a simple username/password system.
  - Supports `LIST`, `UPLOAD`, `DOWNLOAD`, and `QUIT` commands.
  - Stores files in a `ServerFiles` folder.

- **FTP Client**:
  - Connects to the FTP server and handles authentication.
  - Allows users to upload files from any location.
  - Lets users download files to a chosen destination folder.
  - Handles user input for various commands with clear prompts.

---

## **How to Run the Project**

### **FTP Server**

1. Clone the Repository :
	- https://github.com/bax082024/FTPServer-V1.git
2. cd FTPServer-V1
3. dotnet run
4. The server will start and wait for incoming client connections.

### **FTP Client**

1. Clone the Repository :
	- https://github.com/bax082024/FTPClient-V1.git
2. cd FTPClient-V1
3. dotnet run
4. Follow the prompts for username/password and commands.

---