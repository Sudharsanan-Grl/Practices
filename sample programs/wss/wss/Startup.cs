
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace wss
{
    public class Startup
    {
        // Constructor with IConfiguration parameter (optional)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Property to access configuration (optional)
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here
            services.AddControllersWithViews(); // Example: Add MVC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configure error handling middleware for production environment
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Configure other middleware components (e.g., static files, routing, authentication, etc.)
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            var wsOptions = new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(120) };
            app.UseWebSockets(wsOptions);
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/Send")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
                        {
                            await Send(context, webSocket);
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    await next();
                }
            });


           
        }

        private async Task Send(HttpContext context,WebSocket webSocket)
        {
            var buffer = new byte[1024 *4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer),System.Threading.CancellationToken.None);
            if(result != null)
            {
                while (!result.CloseStatus.HasValue)
                {
                    string message = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer,0,result.Count));
                    Console.WriteLine($"Received message from client { message}");
                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes($"Server : {DateTime.UtcNow:f} ")), result.MessageType, result.EndOfMessage,System.Threading.CancellationToken.None);
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
                 //   Console.WriteLine(result);

                }
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);
        }
    }
}


