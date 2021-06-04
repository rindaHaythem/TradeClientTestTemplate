
using QuickFix.Fields;

namespace GrpcFixMessage
{
    public interface IHandler
    {
        QuickFix.FIX42.NewOrderSingle NewOrderSingleBodyHandler(string clOrdID,
                                    string side,
                                    string symbol, 
                                    int quantity,
                                    string orderType,
                                    string limitPrice,
                                    string stopPrice,
                                    string timeInForce,
                                    string dateGTD,
                                    string note
                                    );
        string headerAndMessageAndTrailerHandler(QuickFix.FIX42.NewOrderSingle orderBody,
                                    string transactTime,
                                    string targetCompId,
                                    int messageSequenceNumber
                                    );
    }
}