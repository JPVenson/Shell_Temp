using System.Configuration;

namespace IEADPC.Shell.Contracts.Interfaces.Services.ShellServices
{
    public interface IConfigManagerService : IService
    {
        void Add(ConnectionStringSettings settings);
    }
}