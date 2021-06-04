using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcFixMessage.Message
{
    public class FixMessageLogic
    {
        //Configuration for the fix session
        private int _tradePort = 5212;
        private string _host = "";
        
        private string _username = "";
        private string _password = "";
        
        private string _senderCompID = "";
        private string _senderSubID = "";
        
        private string _targetCompID = "";
        
        private int _messageSequenceNumber = 1;
        private int _testRequestID = 1;

        private TcpClient _tradeClient;
        private SslStream _tradeStreamSSL;

        private FixMessageConstructor _fixMessageConstructor;
        public FixMessageLogic()
        {
            _tradeClient = new TcpClient(_host, _tradePort);
            _tradeStreamSSL = new SslStream(_tradeClient.GetStream(), false,
                        new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
            _tradeStreamSSL.AuthenticateAsClient(_host);
            _fixMessageConstructor = new FixMessageConstructor(_host, _username,
                _password, _senderCompID, _senderSubID, _targetCompID);
        }
        #region Server Certification
        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            return false;
        }
        #endregion
        private string Logon(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.LogonMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE,
                                    _messageSequenceNumber, 
                                    30, false);
            return message;
        }
        private string SendTradeMessage(string message, bool readResponse = true)
        {
            return SendMessage(message, _tradeStreamSSL, readResponse);
        }
        private string SendMessage(string message, SslStream stream, bool readResponse = true)
        {
            var byteArray = Encoding.ASCII.GetBytes(message);
            stream.Write(byteArray, 0, byteArray.Length);
            var buffer = new byte[1024];
            if (readResponse)
            {
                Thread.Sleep(100);
                stream.Read(buffer, 0, 1024);
            }
            _messageSequenceNumber++;
            var returnMessage = Encoding.ASCII.GetString(buffer);
            return returnMessage;
        }
        private string TestRequestTrade(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.TestRequestMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE, 
                                    _messageSequenceNumber, 
                                    _testRequestID);
            _testRequestID++;
            return  message;
        }
        private string Logout(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.LogoutMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE,
                                    _messageSequenceNumber);
            _messageSequenceNumber = 1; //To reset it!?
            return message;
            
        }
        private string Heartbeat(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.HeartbeatMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE,
                                    _messageSequenceNumber);
            return message;
        }
        private string ResendRequest(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.ResendMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE,
                                    _messageSequenceNumber, 
                                    _messageSequenceNumber - 1);
            _testRequestID++;
            return message;
        }
        private string Reject(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.RejectMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE, 
                                    _messageSequenceNumber, 
                                    0);
            _testRequestID++;
            return message;
        }
        private string SequenceReset(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.SequenceResetMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE, 
                                    _messageSequenceNumber, 
                                    0);
            _testRequestID++;
            return message;
        }
        private string NewOrderSingle(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.NewOrderSingleMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE, 
                                    _messageSequenceNumber,
                                    "client order here?? :(", 
                                    1, 
                                    1, 
                                    DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss"), 
                                    1000, 
                                    1,
                                    "");
            _testRequestID++;
            return message;
        }
        private string OrderStatusRequest(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.OrderStatusRequest
                                    (FixMessageConstructor.SessionQualifier.TRADE, 
                                    _messageSequenceNumber, 
                                    "client order here?? :(");
            _testRequestID++;
            return message;
        }
        //order types Limit, Stop & stop limit EXAMPLES! working on this
        private string LimitOrder(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.NewOrderSingleMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE,
                                    _messageSequenceNumber,
                                    "10",
                                    1,
                                    1,
                                    DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss"),
                                    1000,
                                    2,
                                    "3",
                                    (decimal)15.18);
            _testRequestID++;
            return message;
        }
        private string StopOrder(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.NewOrderSingleMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE, 
                                    _messageSequenceNumber, 
                                    "10", 
                                    1, 
                                    1, 
                                    DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss"), 
                                    1000,
                                    3, 
                                    "3", 
                                    0, 
                                    (decimal)1.08);
            _testRequestID++;
            return message;
        }
        private string StopLimitOrder(object sender, EventArgs e)
        {
            var message = _fixMessageConstructor.NewOrderSingleMessage
                                    (FixMessageConstructor.SessionQualifier.TRADE, 
                                    _messageSequenceNumber, 
                                    "10", 
                                    1, 
                                    1, 
                                    DateTime.UtcNow.ToString("yyyyMMdd-HH:mm:ss"), 
                                    1000, 
                                    4, 
                                    "3", 
                                    (decimal)1.08,
                                    (decimal)14.20);
            _testRequestID++;
            return message;
        }
    }
}
