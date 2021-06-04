using QuickFix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcFixMessage
{
    public class DemoTestingAcceptorSession : MessageCracker, IApplication
    {
        Session _session = null;

        #region IApplication interface overrides

        public void OnCreate(SessionID sessionID)
        {
            _session = Session.LookupSession(sessionID);
        }

        public void OnLogon(SessionID sessionID) 
        {
            throw new NotImplementedException();
        }
        public void OnLogout(SessionID sessionID)
        {
            throw new NotImplementedException();
        }
        public void FromAdmin(QuickFix.Message message, SessionID sessionID)
        {
            throw new NotImplementedException();
        }
        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {
            throw new NotImplementedException();
        }

        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            Console.WriteLine("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void ToApp(QuickFix.Message message, SessionID sessionID)
        {
            try
            {
                bool possDupFlag = false;
                if (message.Header.IsSetField(QuickFix.Fields.Tags.PossDupFlag))
                {
                    possDupFlag = QuickFix.Fields.Converters.BoolConverter.Convert(
                        message.Header.GetString(QuickFix.Fields.Tags.PossDupFlag)); 
                }
                if (possDupFlag)
                    throw new DoNotSend();
            }
            catch (FieldNotFoundException)
            { }

            Console.WriteLine();
            Console.WriteLine("OUT: " + message.ToString());
        }
        
        #endregion

        


    }
}
