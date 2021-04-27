// This is a generated file.  Don't edit it directly!

using QuickFix.Fields;
namespace QuickFix
{
    namespace FIX42 
    {
        public class ListCancelRequest : Message
        {
            public const string MsgType = "K";

            public ListCancelRequest() : base()
            {
                this.Header.SetField(new MsgType("K"));
            }

            public ListCancelRequest(
                    ListID aListID,
                    TransactTime aTransactTime
                ) : this()
            {
                this.ListID = aListID;
                this.TransactTime = aTransactTime;
            }

            public ListID ListID
            { 
                get 
                {
                    ListID val = new ListID();
                    GetField(val);
                    return val;
                }
                set { SetField(value); }
            }
            
            public void Set(ListID val) 
            { 
                this.ListID = val;
            }
            
            public ListID Get(ListID val) 
            { 
                GetField(val);
                return val;
            }
            
            public bool IsSet(ListID val) 
            { 
                return IsSetListID();
            }
            
            public bool IsSetListID() 
            { 
                return IsSetField(Tags.ListID);
            }
            public TransactTime TransactTime
            { 
                get 
                {
                    TransactTime val = new TransactTime();
                    GetField(val);
                    return val;
                }
                set { SetField(value); }
            }
            
            public void Set(TransactTime val) 
            { 
                this.TransactTime = val;
            }
            
            public TransactTime Get(TransactTime val) 
            { 
                GetField(val);
                return val;
            }
            
            public bool IsSet(TransactTime val) 
            { 
                return IsSetTransactTime();
            }
            
            public bool IsSetTransactTime() 
            { 
                return IsSetField(Tags.TransactTime);
            }
            public Text Text
            { 
                get 
                {
                    Text val = new Text();
                    GetField(val);
                    return val;
                }
                set { SetField(value); }
            }
            
            public void Set(Text val) 
            { 
                this.Text = val;
            }
            
            public Text Get(Text val) 
            { 
                GetField(val);
                return val;
            }
            
            public bool IsSet(Text val) 
            { 
                return IsSetText();
            }
            
            public bool IsSetText() 
            { 
                return IsSetField(Tags.Text);
            }
            public EncodedTextLen EncodedTextLen
            { 
                get 
                {
                    EncodedTextLen val = new EncodedTextLen();
                    GetField(val);
                    return val;
                }
                set { SetField(value); }
            }
            
            public void Set(EncodedTextLen val) 
            { 
                this.EncodedTextLen = val;
            }
            
            public EncodedTextLen Get(EncodedTextLen val) 
            { 
                GetField(val);
                return val;
            }
            
            public bool IsSet(EncodedTextLen val) 
            { 
                return IsSetEncodedTextLen();
            }
            
            public bool IsSetEncodedTextLen() 
            { 
                return IsSetField(Tags.EncodedTextLen);
            }
            public EncodedText EncodedText
            { 
                get 
                {
                    EncodedText val = new EncodedText();
                    GetField(val);
                    return val;
                }
                set { SetField(value); }
            }
            
            public void Set(EncodedText val) 
            { 
                this.EncodedText = val;
            }
            
            public EncodedText Get(EncodedText val) 
            { 
                GetField(val);
                return val;
            }
            
            public bool IsSet(EncodedText val) 
            { 
                return IsSetEncodedText();
            }
            
            public bool IsSetEncodedText() 
            { 
                return IsSetField(Tags.EncodedText);
            }
        }
    }
}
