using System.Collections.Generic;

namespace IEADPC.Shell.Contracts.Interfaces.Services.ShellServices.Logging
{
    public interface ILogEntry
    {
        string Name { get; set; }
        Dictionary<string, object> Messages { get; set; }
    }
}