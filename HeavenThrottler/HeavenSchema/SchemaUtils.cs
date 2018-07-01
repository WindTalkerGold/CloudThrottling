using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bond;
using Bond.Protocols;

namespace HeavenSchema
{
    public static class SchemaUtils
    {
        public static Stream ToXmlStream<T>(this T bondObject)
        {
            var stream = new MemoryStream();
            var writer = new SimpleXmlWriter(stream);

            Serialize.To(writer, bondObject);

            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
