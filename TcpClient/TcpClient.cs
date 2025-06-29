using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClient
{
    class TcpClient
    {
        static void Main(string[] args)
        {
            try
            {
                // Parse the port number from the second command-line argument.
                var port = int.Parse(args[1]); 
                // Get the message to send from the third command-line argument.
                var message = args[2]; 
                // Create a new TCP client and connect to the server specified by IP/hostname (args[0]) and port (args[1]).
                var client = new System.Net.Sockets.TcpClient(args[0], port); 
                // Convert the message string to ASCII bytes.
                var data = Encoding.ASCII.GetBytes(message); 
                // Get the network stream for writing to and reading from the server.
                var stream = client.GetStream(); 
                // Send the message bytes to the server.
                stream.Write(data, 0, data.Length); 
                Console.WriteLine("Sent: {0}", message); 
                // Buffer to store data received from the server.
                data = new Byte[256]; 
                var responseData = String.Empty; 
                // Read the response from the server.
                var bytes = stream.Read(data, 0, data.Length); 
                // Convert the received bytes to an ASCII string.
                responseData = Encoding.ASCII.GetString(data, 0, bytes); 
                Console.WriteLine("Received: {0}", responseData); 
                // Close the client connection.
                client.Close(); 
            }
            catch (ArgumentNullException e)
            {
                // Catch and print any ArgumentNullException (e.g., if arguments are missing).
                Console.WriteLine("ArgumentNullException: {0}", e); 
            }
            catch (SocketException e)
            {
                // Catch and print any SocketException (e.g., connection refused, network issues).
                Console.WriteLine("SocketException: {0}", e); 
            }

            Console.WriteLine("\n Press Enter to continue..."); 
            Console.Read(); 
        }
    }
}