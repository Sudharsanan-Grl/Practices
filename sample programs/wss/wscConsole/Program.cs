using System.Net.WebSockets;
using System.Text;

namespace wscConsole
{
    public class Public
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            using(ClientWebSocket  client =  new ClientWebSocket())
            {
                Uri serviceUri = new Uri("ws://localhost:5240/Send");
                var cTs = new CancellationTokenSource();
                cTs.CancelAfter(TimeSpan.FromSeconds(120));
                try
                {
                    await client.ConnectAsync(serviceUri, cTs.Token);
                    var number = 0;
                    while (client.State == WebSocketState.Open)
                    {
                        Console.WriteLine("Enter message to server");
                        string message = Console.ReadLine();
                        if(!string.IsNullOrEmpty(message))
                        {
                            ArraySegment<byte> byteToSend =new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
                            await client.SendAsync(byteToSend, WebSocketMessageType.Text, true, cTs.Token);
                            var responseBuffer = new byte[1024];
                            var offset = 0;
                            var packet = 1024;
                            string responseMessage = string.Empty;

                            while (true)
                            {
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
                    Console.WriteLine(ex);

                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Connection timed out.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            Console.ReadLine();
        }

    }
}