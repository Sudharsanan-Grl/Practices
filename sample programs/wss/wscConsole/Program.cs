using System.Net.WebSockets;
using System.Text;

namespace wscConsole
{
    public class Public
    {
        static async Task Main(string[] args)
        {
            // Prompt the user to continue
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            // Create a new WebSocket client
            using (ClientWebSocket  client =  new ClientWebSocket())
            {
                // Specify the WebSocket server URI
                Uri serviceUri = new Uri("ws://localhost:5240/Send");

                // Create a cancellation token source with timeout
                var cTs = new CancellationTokenSource();
                cTs.CancelAfter(TimeSpan.FromSeconds(120));
                try
                {
                    // Connect to the WebSocket server
                    await client.ConnectAsync(serviceUri, cTs.Token);
                    var number = 0;
                    while (client.State == WebSocketState.Open)
                    {
                        // Prompt the user to enter a message

                        Console.WriteLine("Enter message to server");

                        string message = Console.ReadLine();
                        if(!string.IsNullOrEmpty(message))
                        {
                            // Convert the message to bytes
                            ArraySegment<byte> byteToSend =new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
                           
                            // Send the message to the server
                            await client.SendAsync(byteToSend, WebSocketMessageType.Text, true, cTs.Token);
                            var responseBuffer = new byte[1024];
                            var offset = 0;
                            var packet = 1024;
                            string responseMessage = string.Empty;

                            while (true)
                            {
                                // Receive the response from the server

                                ArraySegment<byte> byteRecieved = new ArraySegment<byte>(responseBuffer, offset, packet);
                                WebSocketReceiveResult response = await client.ReceiveAsync(byteRecieved, cTs.Token);
                                offset += response.Count;
                                responseMessage += Encoding.UTF8.GetString(responseBuffer, 0, response.Count);
                                Console.WriteLine(responseMessage);
                                if(response.EndOfMessage)
                                    break;
                            }
                        }

                    }
                }
                catch (WebSocketException ex)
                {
                    // Handle WebSocket exception

                    Console.WriteLine(ex);

                }
                catch (OperationCanceledException)
                {
                    // Handle operation cancellation (timeout)

                    Console.WriteLine("Connection timed out.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            // Wait for user input to exit

            Console.ReadLine();
        }

    }
}