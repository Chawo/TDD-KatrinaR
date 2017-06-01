using System.Collections.Generic;

namespace TheBank
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}