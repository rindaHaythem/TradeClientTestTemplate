using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX42;
using QuickFix.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fixMessageConstructor
{
    class main
    {
        [STAThread]
        static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.WriteLine("usage: TradeClient.exe CONFIG_FILENAME");
                Environment.Exit(2);
            }

            string file = args[0];

            try
            {
                SessionSettings settings = new SessionSettings(file);
                TradeClientApp application = new TradeClientApp();
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
                ILogFactory logFactory = new ScreenLogFactory(settings);
                SocketInitiator initiator = new SocketInitiator(application, storeFactory, settings, logFactory);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Environment.Exit(1);
        }
    }
}
