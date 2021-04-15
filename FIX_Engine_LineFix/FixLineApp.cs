using QuickFix;
using QuickFix.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIX_Engine_LineFix
{
    class FixLineApp : IApplication
    {
        //For orders, executions, security definitions, and market data
        public void FromApp(Message msg, SessionID sessionID) 
        {

        }

        //For heartbeats, logons, and logouts.
        public void FromAdmin(Message msg, SessionID sessionID) 
        { 

        }

        //All outbound admin level messages pass through this callback.
        public void ToAdmin(Message msg, SessionID sessionID) 
        {

        }

        // All outbound application level messages pass through this callback before they are sent.
        //If a tag needs to be added to every outgoing message, this is a good place to do that.
        public void ToApp(Message msg, SessionID sessionID) 
        { 

        }

        // Called whenever a new session is created.
        public void OnCreate(SessionID sessionID) 
        {

        }

        // Notifies when a session is off-line.
        //(either from an exchange of logout messages or network connectivity loss)
        public void OnLogout(SessionID sessionID) 
        { 

        }

        // Notifies when a successful logon has completed.
        public void OnLogon(SessionID sessionID) 
        { 

        }

    }
}
