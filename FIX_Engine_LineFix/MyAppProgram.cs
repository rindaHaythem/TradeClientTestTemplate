using QuickFix;
using QuickFix.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIX_Engine_LineFix
{
    public static class MyAppProgram
    {
       static void Main(string[] args)
            {
                SessionSettings settings = new SessionSettings(args[0]);

                IApplication myAppProgram = new FixLineApp();

                //IMessageFactory keeps a record of all outgoing messages
                //for FIX session level messaging.
                //We could implement our own store by implementing
                //the MessageStoreFactory interface.
                IMessageStoreFactory storeFactory = new FileStoreFactory(settings);

                ILogFactory logFactory = new FileLogFactory(settings);

                SocketInitiator Initiator = new SocketInitiator(
                    myAppProgram,
                    storeFactory,
                    settings,
                    logFactory);

                Initiator.Start();
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                Initiator.Stop();
            }
        
    }
}
