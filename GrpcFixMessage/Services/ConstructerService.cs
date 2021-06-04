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
using static GrpcFixMessage.FixMessageConstructor;

namespace GrpcFixMessage
{
    public class ConstructerService : Constructer.ConstructerBase
    {

        private readonly ILogger<ConstructerService> _logger;
        private readonly Handler _handler;
        public ConstructerService(ILogger<ConstructerService> logger, Handler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        
        //For testing purposes
/*        public override Task<NewOrderSingleReply> BuildFixMessageTesting(NewOrderSingleRequest request, ServerCallContext context)
        {
            QuickFix.FIX42.NewOrderSingle orderBody = _handler.NewOrderSingleBodyHandler(request.ClOrdId,
                                                            request.Side,
                                                            request.Symbol,
                                                            request.Quantity,
                                                            request.OrderType,
                                                            request.LimitPrice,
                                                            request.StopPrice,
                                                            request.TimeInForce,
                                                            request.DateGTD,
                                                            request.Note);

            string orderMessage = _handler.headerAndMessageAndTrailerHandler(orderBody,
                                                                            request.TransactTime,
                                                                            1);
            return Task.FromResult(new NewOrderSingleReply { Fixmessage = orderMessage });
        }
*/
        public override Task<EmptyMessageNewOrderSingleReply> BuildFixMessage(NewOrderSingleRequest request, ServerCallContext context)
        {
            QuickFix.FIX42.NewOrderSingle orderBody = _handler.NewOrderSingleBodyHandler(request.ClOrdId,
                                                            request.Side,
                                                            request.Symbol,
                                                            request.Quantity,
                                                            request.OrderType,
                                                            request.LimitPrice,
                                                            request.StopPrice,
                                                            request.TimeInForce,
                                                            request.DateGTD,
                                                            request.Note);

            string orderMessage = _handler.headerAndMessageAndTrailerHandler(orderBody,
                                                                            request.TransactTime,
                                                                            request.TargetCompID,
                                                                            1);

            _logger.LogInformation("The output FIX message:");
            _logger.LogInformation(orderMessage);

            return Task.FromResult(new EmptyMessageNewOrderSingleReply());
        }

    }
}
