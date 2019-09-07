using System;
using System.Collections.Generic;
using NpgsqlTypes;
using Serilog.Sinks.PostgreSQL;

namespace Lunchbox.Extensions
{
    public static class SerilogConfig
    {
        public static string ConnectionString = "User ID=lunchboxuser;Password=lunchboxuser;Host=localhost;Port=5432;Database=lunchbox;Pooling=true;";
        public static string TableName = "Logging";
        public static IDictionary<string, ColumnWriterBase> ColumnWriters =
                new Dictionary<string, ColumnWriterBase>
                {
                    {"Message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
                    {"MessageTemplate", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
                    {"Level", new LevelColumnWriter(true, NpgsqlDbType.Text) },
                    {"TimeStamp", new TimestampColumnWriter(NpgsqlDbType.TimestampTz) },
                    {"Exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
                    {"Properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) }
                };
    }
}
