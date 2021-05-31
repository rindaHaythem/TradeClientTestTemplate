using QuickFix;
using QuickFix.FIX42;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFix.Fields;


namespace fixMessageConstructor
{
    class SendFIXMessage : MessageCracker, IApplication 
    {
        Session _session = null;

        #region IAPPLICATION INTERFACE OVERRIDES
        public void OnCreate(SessionID sessionID)
        {
            _session = Session.LookupSession(sessionID);
        }
        public void OnLogon(SessionID sessionID) { Console.WriteLine("Logon - " + sessionID.ToString()); }
        public void OnLogout(SessionID sessionID) { Console.WriteLine("Logout - " + sessionID.ToString()); }

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
                Console.WriteLine("==Cracker exception==");
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
                        message.Header.GetString(QuickFix.Fields.Tags.PossDupFlag)); /// FIXME
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

        #region MessageCracker handlers
        public void OnMessage(QuickFix.FIX42.ExecutionReport m, SessionID s)
        {
            Console.WriteLine("Received execution report");
        }

        public void OnMessage(QuickFix.FIX42.OrderCancelReject m, SessionID s)
        {
            Console.WriteLine("Received order cancel reject");
        }
        #endregion

        public NewOrderSingle NewOrderSingleConstructor(
                    string clOrdID,
                    string symbol,
                    char side,
                    DateTime transactTime,
                    char ordType
            )
        {

            NewOrderSingle msg = QueryNewOrderSingle42(clOrdID, symbol, side, transactTime, ordType);
            return msg;
        }

        private void SendMessage(QuickFix.Message m)
        {
            if (_session != null)
                _session.Send(m);
            else
            {
                Console.WriteLine("Can't send message: session not created.");
            }
        }


        #region Message creation
        private NewOrderSingle QueryNewOrderSingle42(
                    string clOrdID,
                    string symbol,
                    char side,
                    DateTime transactTime,
                    char ordType
                    )
        {
            OrdType orrdType = null;

            NewOrderSingle newOrderSingle = new NewOrderSingle(
                QueryClOrdID(clOrdID),
                QuerySymbol(symbol),
                QuerySide(side),
                new TransactTime(DateTime.Now),
                QueryOrdType(ordType));

            newOrderSingle.Set(new HandlInst('1'));
            newOrderSingle.Set(QueryOrderQty());
            newOrderSingle.Set(QueryTimeInForce());
            if (ordType.getValue() == OrdType.LIMIT || ordType.getValue() == OrdType.STOP_LIMIT)
                newOrderSingle.Set(QueryPrice());
            if (ordType.getValue() == OrdType.STOP || ordType.getValue() == OrdType.STOP_LIMIT)
                newOrderSingle.Set(QueryStopPx());

            return newOrderSingle;
        }
        #endregion

        #region field query private methods
        private ClOrdID QueryClOrdID(string id)
        {
            return new ClOrdID(id);
        }

        private OrigClOrdID QueryOrigClOrdID()
        {
            return new OrigClOrdID();
        }

        private Symbol QuerySymbol(string s)
        {
            return new Symbol(s);
        }

        private Side QuerySide(char c)
        {
            return new Side(c);
        }

        private OrdType QueryOrdType()
        {
            return new OrdType(c);
        }

        private OrderQty QueryOrderQty(char c)
        {
            return new OrderQty(Convert.ToDecimal(c));
        }

        private TimeInForce QueryTimeInForce(char tif)
        {
            return new TimeInForce(tif);
        }

        private Price QueryPrice(string lmtPrice)
        {
            return new Price(Convert.ToDecimal(lmtPrice));
        }

        private StopPx QueryStopPx(string stpPrice)
        {;
            return new StopPx(Convert.ToDecimal(stpPrice));
        }

        #endregion
    }
}
