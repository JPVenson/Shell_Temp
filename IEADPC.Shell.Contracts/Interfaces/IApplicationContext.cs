#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 11:42

#endregion

using IEADPC.Shell.Contracts.Interfaces.Services.ModuleServices;
using IEADPC.Shell.Contracts.Interfaces.Services.ShellServices;
using IEADPC.Shell.Contracts.Interfaces.Services.ShellServices.Logging;

namespace IEADPC.Shell.Contracts.Interfaces
{
    public interface IApplicationContext
    {
        IDataBroker DataBroker { get; }
        IServicePool ServicePool { get; }
        IMessageBroker MessageBroker { get; }
        IImportPool ImportPool { get; }
        IVisualModuleManager VisualModuleManager { get; }
    }
}