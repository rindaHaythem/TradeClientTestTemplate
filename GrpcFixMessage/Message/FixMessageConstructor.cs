using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcFixMessage
{
    public class FixMessageConstructor
    {
        public enum SessionMessageType
        {
            Logon,
            Logout,
            Heartbeat,
            TestRequest,
            Resend,
            Reject,
            SequenceReset
        }
        public enum ApplicationMessageType
        {
            NewOrderSingle,
            OrderStatusRequest,
            ExecutionReport,
            BusinessMessageReject,
        }

        public enum SessionQualifier
        {
            QUOTE,
            TRADE
        }
        private string _host;
        private string _username;
        private string _password;
        private string _senderCompID;
        private string _senderSubID;
        private string _targetCompID;

        public FixMessageConstructor(string host, string username, string password, string senderCompID, string senderSubID, string targetCompID)
        {
            _host = host;
            _username = username;
            _password = password;
            _senderCompID = senderCompID;
            _senderSubID = senderSubID;
            _targetCompID = targetCompID;
        }
        #region Message logon
        //Message Logon: 
        // qualifier: The session qualifier
        // messageSequenceNumber: The message sequence number
        // heartBeatSeconds: The heart beat seconds
        // resetSeqNum: All sides of FIX session should have sequence numbers reset (Y)

        public string LogonMessage(SessionQualifier qualifier, int messageSequenceNumber,
            int heartBeatSeconds, bool resetSeqNum)
        {
            var body = new StringBuilder();
            //Defines a message encryption scheme.Currently, only transportlevel security is supported.Valid value is "0"(zero) = NONE_OTHER
            body.Append("98=0|");
            body.Append("108=" + heartBeatSeconds + "|");
            
            if (resetSeqNum)
                body.Append("141=Y|");
            
            body.Append("553=" + _username + "|");
            
            body.Append("554=" + _password + "|");

            var header = ConstructHeader(qualifier, SessionMessageCode(SessionMessageType.Logon),
                messageSequenceNumber, body.ToString());
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }

        public string HeartbeatMessage(SessionQualifier qualifier, int messageSequenceNumber)
        {
            var header = ConstructHeader(qualifier, SessionMessageCode(SessionMessageType.Heartbeat), messageSequenceNumber, string.Empty);
            var trailer = ConstructTrailer(header);
            var headerAndMessageAndTrailer = header + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }

        public string TestRequestMessage(SessionQualifier qualifier, int messageSequenceNumber, int testRequestID)
        {
            var body = new StringBuilder();
            //Heartbeat message ID (TestReqID should be incremental)
            body.Append("112=" + testRequestID + "|");
            var header = ConstructHeader(qualifier, SessionMessageCode(SessionMessageType.TestRequest), messageSequenceNumber, body.ToString());
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }

        public string LogoutMessage(SessionQualifier qualifier, int messageSequenceNumber)
        {
            var header = ConstructHeader(qualifier, SessionMessageCode(SessionMessageType.Logout), messageSequenceNumber, string.Empty);
            var trailer = ConstructTrailer(header);
            var headerAndMessageAndTrailer = header + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }
        #endregion
        #region Message Resend
        public string ResendMessage(SessionQualifier qualifier, int messageSequenceNumber, int endSequenceNo)
        {
            var body = new StringBuilder();
            //Message sequence number of last record in range to be resent.
            body.Append("16=" + endSequenceNo + "|");
            var header = ConstructHeader(qualifier, SessionMessageCode(SessionMessageType.Resend), messageSequenceNumber, body.ToString());
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }

        public string RejectMessage(SessionQualifier qualifier, int messageSequenceNumber, int rejectSequenceNumber)
        {
            var body = new StringBuilder();
            //Referenced message sequence number.
            body.Append("45=" + rejectSequenceNumber + "|");
            var header = ConstructHeader(qualifier, SessionMessageCode(SessionMessageType.Reject), messageSequenceNumber, string.Empty);
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }

        public string SequenceResetMessage(SessionQualifier qualifier, int messageSequenceNumber, int rejectSequenceNumber)
        {
            var body = new StringBuilder();
            //New Sequence Number
            body.Append("36=" + rejectSequenceNumber + "|");
            var header = ConstructHeader(qualifier, SessionMessageCode(SessionMessageType.SequenceReset), messageSequenceNumber, string.Empty);
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }
        #endregion
        #region New Order Single
        public string NewOrderSingleMessage(SessionQualifier qualifier, int messageSequenceNumber, 
                                            string clOrdD, long symbol, int side, string transactTime, 
                                            int orderQuantity, int orderType, string timeInForce, 
                                            decimal limitPrice = 0, decimal stopPrice = 0, string expireDate = "")
        {
            var body = new StringBuilder();
            body.Append("11=" + clOrdD + "|");
            body.Append("55=" + symbol + "|");
            body.Append("54=" + side + "|");
            body.Append("60=" + transactTime + "|");
            body.Append("38=" + orderQuantity + "|");
            body.Append("40=" + orderType + "|");
            if (limitPrice != 0)
            {
                body.Append("44=" + limitPrice + "|");
            }
            if (stopPrice != 0)
            {
                body.Append("99=" + stopPrice + "|");
            }
            body.Append("59=" + timeInForce + "|");
            if (expireDate != string.Empty)
            {
                body.Append("432=" + expireDate + "|");
            }
            var header = ConstructHeader(qualifier, ApplicationMessageCode(ApplicationMessageType.NewOrderSingle), messageSequenceNumber, body.ToString());
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }
        #endregion
        #region Order Status Request
        public string OrderStatusRequest(SessionQualifier qualifier, int messageSequenceNumber, string clOrdD)
        {
            var body = new StringBuilder();
            body.Append("11=" + clOrdD + "|");
            body.Append("54=1|");
            var header = ConstructHeader(qualifier, ApplicationMessageCode(ApplicationMessageType.OrderStatusRequest), messageSequenceNumber, body.ToString());
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }
        #endregion
        #region Execution report
        public string ExecutionReport(SessionQualifier qualifier, int messageSequenceNumber, string brokerSideOrderID, string orderStatus, string transactTime, long symbol = 0, int side = 1,
           int averagePrice = 0, int orderQuantity = 0, int leavesQuantity = 0, int cumQuantity = 0, string clOrdID = "", string orderType = "", int limitPrice = 0, int stopPrice = 0,
           string timeInForce = "", string expireTime = "", string text = "", int orderRejectionReason = -1, string positionID = "")
        {
            var body = new StringBuilder();
            
            // Unique LineData's simulator Order ID
            body.Append("37=" + brokerSideOrderID + "|");
            body.Append("11=" + clOrdID + "|");
            
            // Execution report type tag:
            body.Append("150=F|");
             
            // 0 = New;   1 = Partially filled;  2 = Filled;   8 = Rejected;
            // 4 = Cancelled(When an order is partially filled, "Cancelled" is
            // returned signifying Tag 151: LeavesQty is cancelled and will not be subsequently filled);
            // C = Expired.
            body.Append("39=" + orderStatus + "|");
            body.Append("55=" + symbol + "|");
            body.Append("54=" + side + "|");
            body.Append("60=" + transactTime + "|");
            if (averagePrice > 0)
            {
                // The limitPrice at which the deal was filled.
                // For an IOC or GTD order, this is the VWAP(Volume Weighted Average Price)
                // of the filled order.
                body.Append("6=" + averagePrice + "|");
            }
            if (orderQuantity > 0)
            {
                body.Append("38=" + orderQuantity + "|");
            }
            if (leavesQuantity > 0)
            {
                body.Append("151=" + leavesQuantity + "|");
            }
            if (cumQuantity > 0)
            {
                // The total amount of the order which has been filled.
                body.Append("14=" + cumQuantity + "|");
            }
            if (orderType != string.Empty)
            {
                body.Append("40=" + orderType + "|");
            }
            if (limitPrice > 0)
            {
                body.Append("44=" + limitPrice + "|");
            }
            if (stopPrice > 0)
            {
                body.Append("99=" + stopPrice + "|");
            }
            if (timeInForce != string.Empty)
            {
                body.Append("59=" + timeInForce + "|");
            }
            if (expireTime != string.Empty)
            {
                body.Append("126=" + expireTime + "|");
            }
            if (text != string.Empty)
            {
                body.Append("58=" + text + "|");
            }
            if (orderRejectionReason != -1)
            {
                body.Append("103=" + orderRejectionReason + "|");
            }
            if (positionID != string.Empty)
            {
                body.Append("721=" + positionID + "|");
            }

            var header = ConstructHeader(qualifier, ApplicationMessageCode(ApplicationMessageType.OrderStatusRequest), messageSequenceNumber, body.ToString());
            var headerAndBody = header + body;
            var trailer = ConstructTrailer(headerAndBody);
            var headerAndMessageAndTrailer = header + body + trailer;
            return headerAndMessageAndTrailer.Replace("|", "\u0001");
        }
        #endregion
        #region Session message tag
        private string SessionMessageCode(SessionMessageType type)
        {
            switch (type)
            {
                case SessionMessageType.Heartbeat:
                    return "0";
                    break;

                case SessionMessageType.Logon:
                    return "A";
                    break;

                case SessionMessageType.Logout:
                    return "5";
                    break;

                case SessionMessageType.Reject:
                    return "3";
                    break;

                case SessionMessageType.Resend:
                    return "2";
                    break;

                case SessionMessageType.SequenceReset:
                    return "4";
                    break;

                case SessionMessageType.TestRequest:
                    return "1";
                    break;

                default:
                    return "0";
            }
        }
        #endregion
        #region Message Header and Trailer constructor 
        private string ConstructHeader(SessionQualifier qualifier, string type,
            int messageSequenceNumber, string bodyMessage)
        {
            var header = new StringBuilder();
            header.Append("8=FIX.4.2|");
            var message = new StringBuilder();
            message.Append("35=" + type + "|");
            message.Append("49=" + _senderCompID + "|");
            message.Append("56=" + _targetCompID + "|"); //Valid value is "CSERVER"
            message.Append("57=" + qualifier.ToString() + "|"); //Possible values are: "QUOTE", "TRADE"
            message.Append("50=" + _senderSubID + "|");
            message.Append("34=" + messageSequenceNumber + "|");
            message.Append("52=" + DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss") + "|");
            var length = message.Length + bodyMessage.Length;
            header.Append("9=" + length + "|");
            header.Append(message);
            return header.ToString();
        }

        // Constructs the message trailer
        private string ConstructTrailer(string message)
        {
            var trailer = "10=" + CalculateChecksum(message.Replace("|", "\u0001").ToString()).ToString().PadLeft(3, '0') + "|";
            return trailer;
        }

        // Calculates the checksum
        private int CalculateChecksum(string dataToCalculate)
        {
            byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
            int checksum = 0;
            foreach (byte chData in byteToCalculate)
            {
                checksum += chData;
            }
            return checksum % 256;
        }
        #endregion
        #region Tag 35 = ?
        private string ApplicationMessageCode(ApplicationMessageType type)
        {
            switch (type)
            {

                case ApplicationMessageType.NewOrderSingle:
                    return "D";
                    break;

                case ApplicationMessageType.OrderStatusRequest:
                    return "H";
                    break;

                case ApplicationMessageType.ExecutionReport:
                    return "8";
                    break;

                case ApplicationMessageType.BusinessMessageReject:
                    return "j";
                    break;

                default:
                    return "0";
            }
        }
        #endregion
    }
}
