﻿#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 12:05

#endregion

namespace IEADPC.Shell.Contracts.Interfaces.Services.ModuleServices
{
    public interface IApplicationProvider : IService
    {
        IApplicationContext Context { get; set; }
    }
}