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