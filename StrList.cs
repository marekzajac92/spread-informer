using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pl.xtb.api.message.codes;
using pl.xtb.api.message.command;
using pl.xtb.api.message.records;
using pl.xtb.api.message.response;
using pl.xtb.api.streaming;
using pl.xtb.api.sync;
using SyncAPIConnector.streaming;
using System.Threading;

namespace SpreadInformer
{
    class StrList : StreamingListener
    {
        void StreamingListener.receiveTradeRecord(TradeRecord tradeRecord)
        {
            Console.WriteLine(tradeRecord.ToString());
        }
        void StreamingListener.receiveTickRecord(TickRecord tickRecord)
        {
            Console.WriteLine(tickRecord.ToString());
            foreach (KeyValuePair<long?, double?> i in tickRecord.Profits)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
        }
    }
}
