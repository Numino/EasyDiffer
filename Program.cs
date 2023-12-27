using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using JsonDiffer.Infrastructure;
using JsonDiffer.System;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Photino.Blazor;
using PhotinoNET;

namespace JsonDiffer
{
    class Program
    {
        private const string LocalHostUrl = "http://localhost:27275/";

        [STAThread]
        static void Main(string[] args)
        {
            var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);
            appBuilder.Services.AddLogging();
            appBuilder.RootComponents.Add<App>("app");
            appBuilder.Services.AddMudServices();

            var app = appBuilder.Build();
            app.MainWindow.SetGrantBrowserPermissions(true);
            app.MainWindow.SetTitle("JsonDiffer");
            app.MainWindow.SetUseOsDefaultSize(false);
            Task.Run(() => RunHttpServer(app));
            var settings = Settings.Get();
            if (settings.FirstTimeSetup)
            {
                settings.FirstTimeSetup = false;
                Settings.Save(settings);
                Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    app.MainWindow.SetLocation(new Point(0, 0));
                    app.MainWindow.SetSize(app.MainWindow.MainMonitor.WorkArea.Width,
                        app.MainWindow.MainMonitor.WorkArea.Height);
                });
            }
            else
            {
                app.MainWindow.SetLocation(new Point(settings.WindowLocationX, settings.WindowLocationY));
                app.MainWindow.SetSize(settings.WindowSizeHeight, settings.WindowSizeLength);
            }

            app.MainWindow.WindowLocationChanged += (sender, point) =>
            {
                settings.WindowLocationX = point.X;
                settings.WindowLocationY = point.Y;
                Settings.Save(settings);
            };

            app.MainWindow.WindowSizeChanged += (sender, size) =>
            {
                settings.WindowSizeHeight = size.Width;
                settings.WindowSizeLength = size.Height;
                Settings.Save(settings);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
                app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
            };

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                OsxMenu.CreateEditMenu();
            
            app.Run();
        }

        private static async Task RunHttpServer(PhotinoBlazorApp app)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(LocalHostUrl);
            listener.Start();

            while (true)
            {
                var context = await listener.GetContextAsync();
                var request = context.Request;
                var response = context.Response;
                var scheme = request.Url.Scheme;
                var url = request.Url.ToString().Replace(LocalHostUrl, PhotinoWebViewManager.AppBaseUri);
                var contentStream = app.HandleWebRequest((object) null, scheme, url, out var contentType);
                if (contentStream != null)
                {
                    response.ContentType = contentType;
                    await contentStream.CopyToAsync(response.OutputStream);
                }
                else
                {
                    response.StatusCode = 404;
                    byte[] content = Encoding.UTF8.GetBytes("File not found");
                    response.OutputStream.Write(content, 0, content.Length);
                }

                response.OutputStream.Close();
            }
        }
    }
}

//npx tailwindcss -i wwwroot/css/app.css -o wwwroot/css/app.min.css --watch
//var fieldInfo = typeof(PhotinoWindow).GetField("_nativeInstance", BindingFlags.NonPublic | BindingFlags.Instance);
//IntPtr pointer = (IntPtr)fieldInfo.GetValue(app.MainWindow);


//Should probably call release after each alloc but will be taken care of when you quit the app :)