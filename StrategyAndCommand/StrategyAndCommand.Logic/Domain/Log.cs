using System;
using System.Collections.Generic;

namespace StrategyAndCommand.Logic.Domain
{
    public class Log
    {
        public long UserID { get; set; }

        public string UserName { get; set; }

        public string TableName { get; set; }

        public string Action { get; set; }

        public List<ChangeLog> Changes { get; set; }

        public DateTime TimeStamp { get; set; }
    }

    public class ChangeLog
    {
        public string FieldName { get; }

        public string From { get; }

        public string To { get; }

        public ChangeLog(string fieldName, string from, string to)
        {
            FieldName = fieldName;
            From = from;
            To = to;
        }

    }
}
