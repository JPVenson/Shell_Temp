#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 12:47

#endregion

using IEADPC.Shell.Contracts.Interfaces.Services.ModuleServices;

namespace IEADPC.Shell.Contracts.Interfaces.Services.ApplicationServices
{
    public interface IApplicationContainer : IVisualService
    {
        IApplicationContext ApplicationContextProxy { get; }
    }
}