# .Net TCP Server and Client Connectivity Check

This application consists of a simple TCP server and a corresponding TCP client. Its primary purpose is to **facilitate testing network connectivity between two machines**, particularly useful for **verifying if firewalls are permitting communication** on a specific port.

Was used to test if port (port forwarding) exposed at my Google Router accessible from my VM at Azure.

The **TcpServer** listens for incoming connections and echoes received messages in uppercase. The **TcpClient** connects to the server, sends a message, and displays the server's response.