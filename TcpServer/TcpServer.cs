using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    class TcpServer
    {
        static void Main(string[] args)
        {
            try
            {
                // Parse the IP address from the first command-line argument.
                var localAddr = IPAddress.Parse(args[0]);
                // Parse the port number from the second command-line argument.
                var port = int.Parse(args[1]);
                // Create a TcpListener to listen for incoming client connection requests.
                var server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                server.Start();
                // Buffer to store data received from the client.
                var bytes = new Byte[256];

                // Infinite loop to continuously listen for and handle client connections.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    // Accept a pending client connection. This call blocks until a client connects.
                    var client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    // Get the network stream for reading from and writing to the connected client.
                    var stream = client.GetStream();
                    int i;
                    // Loop to read data from the client until there is no more data (i.e., client disconnects).
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Convert the received bytes to an ASCII string.
                        var data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine($"Received: {data}");
                        // Convert the received string to uppercase.
                        data = data.ToUpper();
                        // Convert the uppercase string back to bytes.
                        var msg = Encoding.ASCII.GetBytes(data);
                        // Send the uppercase data back to the client.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine($"Sent: {data}");
                    }
                    // Close the client connection.
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                // Catch and print any SocketException that occurs.
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}