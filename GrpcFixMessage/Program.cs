using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcFixMessage
{
    public class Program
    {
        [STAThread]

        public static void Main(string[] args)
        {
            //load config file
            //string configFile = @"C:\Users\HTRABELSI\source\repos\TradeClientTestTemplate\GrpcFixMessage\Config\tradeclient.cfg";

            //string text = File.ReadAllText(configFile);

            //QuickFix.SessionSettings settings = new QuickFix.SessionSettings(text);
            //TradeClientLogic application = new TradeClientLogic();

            //QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
            //QuickFix.ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
            //QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings, logFactory);


            //*****************************************
            CreateHostBuilder(args).Build().Run();
        }

        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

       

    }
}
