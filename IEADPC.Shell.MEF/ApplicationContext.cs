#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 10:22

#endregion

using IEADPC.Shell.Contracts.Interfaces;
using IEADPC.Shell.Contracts.Interfaces.Services.ModuleServices;
using IEADPC.Shell.Contracts.Interfaces.Services.ShellServices;
using IEADPC.Shell.Contracts.Interfaces.Services.ShellServices.Logging;

namespace IEADPC.Shell.MEF
{
    public class ApplicationContext : IApplicationContext
    {
        public ApplicationContext(IImportPool importPool, IMessageBroker messageBroker, IServicePool servicePool,
                                  IDataBroker dataBroker, IVisualModuleManager visualModuleManager)
        {
            VisualModuleManager = visualModuleManager;
            DataBroker = dataBroker;
            ServicePool = servicePool;
            MessageBroker = messageBroker;
            ImportPool = importPool;
        }

        public static ApplicationContext Instance { get; set; }

        #region Implementation of IApplicationContext

        public IDataBroker DataBroker { get; set; }

        public IServicePool ServicePool { get; set; }

        public IMessageBroker MessageBroker { get; set; }

        public IImportPool ImportPool { get; set; }

        public IVisualModuleManager VisualModuleManager { get; set; }

        #endregion
    }
}