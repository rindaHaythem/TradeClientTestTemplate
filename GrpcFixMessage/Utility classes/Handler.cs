using QuickFix.Fields;
using QuickFix.Fields.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcFixMessage
{
    public class Handler : IHandler
    {
        
        public int messageSequenceNumber = 1;
        /*public Handler(ConstructerService constructerService, TradeClientLogic tradeClientLogic)
        {
            _constructerService = constructerService;
            _tradeClientLogic = tradeClientLogic;
        }*/

        public QuickFix.FIX42.NewOrderSingle NewOrderSingleBodyHandler(string clOrdID,
                                                string side,
                                                string symbol,
                                                int quantity,
                                                string orderType,
                                                string limitPrice,
                                                string stopPrice,
                                                string timeInForce,
                                                string dateGTD,
                                                string note)
        {

            var order = new QuickFix.FIX42.NewOrderSingle();
            order.ClOrdID = new ClOrdID(clOrdID);
            order.Side = new Side(CharConverter.Convert(side));
            order.Symbol = new Symbol(symbol);
            order.OrderQty = new OrderQty(quantity);
            order.OrdType = new OrdType(CharConverter.Convert(orderType));

            if (CharConverter.Convert(orderType) == '2')
            {
                order.Price = new Price(decimal.Parse(limitPrice, CultureInfo.InvariantCulture));
            }
            else if (CharConverter.Convert(orderType) == '3')
            {
                order.StopPx = new StopPx(decimal.Parse(stopPrice, CultureInfo.InvariantCulture));
            }
            else if (CharConverter.Convert(orderType) == '4')
            {
                order.Price = new Price(decimal.Parse(limitPrice, CultureInfo.InvariantCulture));
                order.StopPx = new StopPx(decimal.Parse(stopPrice, CultureInfo.InvariantCulture));
            }

            order.TimeInForce = new TimeInForce(CharConverter.Convert(timeInForce));
            if (CharConverter.Convert(timeInForce) == '6')
            {
                string dateExpireGTD = Convert.ToDateTime(dateGTD).ToString("yyyyMMdd");
                order.SetField(new ExpireDate(dateExpireGTD));
            }
            if (note != string.Empty)
            {
                order.Text = new Text(note);
            }

            return order;
        }

        public string headerAndMessageAndTrailerHandler(
                                    QuickFix.FIX42.NewOrderSingle message,
                                    string transactTime,
                                    string targetCompID,
                                    int messageSequenceNumber
                                    )
        {
            message.Header.SetField(new MsgType("D"));
            message.Header.SetField(new HandlInst('1'));
            message.Header.SetField(new MsgSeqNum(messageSequenceNumber));

            string sendTime = Convert.ToDateTime(transactTime).ToString("yyyyMMdd-HH:mm:ss");
            message.Header.SetField(new SendingTime(DateTimeConverter.ConvertToDateTime(sendTime)));
            
            //for testing purposes
            message.Header.SetField(new SenderCompID("LINEFIXtrade"));
            message.Header.SetField(new TargetCompID(targetCompID.ToString()));

            return message.ToString().Replace("\u0001", "|");
        }

        

    }
}
