using Grpc.Core;
using Microsoft.Extensions.Logging;
using QuickFix;
using QuickFix.Fields;
using QuickFix.Fields.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcFixMessage
{
    public class ConstructerService : Constructer.ConstructerBase
    {

        private readonly ILogger<ConstructerService> _logger;
        public ConstructerService(ILogger<ConstructerService> logger)
        {
            _logger = logger;
        }

        //For testing purposes
        public override Task<NewOrderSingleReply> BuildFixMessageTesting(NewOrderSingleRequest request, ServerCallContext context)
        {
            #region Order Body
            var order = new QuickFix.FIX42.NewOrderSingle();

            order.ClOrdID = new ClOrdID(request.ClOrdId);
            order.Side = new Side(CharConverter.Convert(request.Side));
            order.Symbol = new Symbol(request.Symbol);
            order.OrderQty = new OrderQty(request.Quantity);
            order.OrdType = new OrdType(CharConverter.Convert(request.OrderType));

            if (CharConverter.Convert(request.OrderType) == '2')
            {
                order.Price = new Price(DecimalConverter.Convert(request.LimitPrice));
            }
            else if (CharConverter.Convert(request.OrderType) == '3')
            {
                order.StopPx = new StopPx(DecimalConverter.Convert(request.StopPrice));
            }
            else if (CharConverter.Convert(request.OrderType) == '4')
            {
                order.Price = new Price(DecimalConverter.Convert(request.LimitPrice));
                order.StopPx = new StopPx(DecimalConverter.Convert(request.StopPrice));
            }
            
            DateTime dt = DateTime.ParseExact(request.DateGTD, "yyyymmdd",
                                  CultureInfo.InvariantCulture);

            order.TimeInForce = new TimeInForce(CharConverter.Convert(request.TimeInForce));
            if (CharConverter.Convert(request.TimeInForce) == '6')
            {
                order.SetField(new ExpireDate(dt.ToString()));
            }

            order.Text = new Text(request.Note);
            order.Set(new HandlInst('1'));
            #endregion

            #region Message
            order.Header.SetField(new MsgType("D"));

            var sendingTime = DateTimeConverter.ConvertToDateTime(request.TransactTime);
            //DateTime sendingTime = DateTime.ParseExact(request.TransactTime, "yyyyMMdd-HH:mm:ss", CultureInfo.InvariantCulture);
            
            order.Header.SetField(new SendingDate(sendingTime.));
            #endregion

            return Task.FromResult(new NewOrderSingleReply 
            {
                Fixmessage = order.ToString()
            });

        }

    }
}
