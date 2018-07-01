using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenSchema
{
    public interface IQuotablMessage
    {
        string GetQuotaId();
    }

    public partial class Message : IQuotablMessage
    {
        public string GetQuotaId() => this.SourceId;
    }
}
