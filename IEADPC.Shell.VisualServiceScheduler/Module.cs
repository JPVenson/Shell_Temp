#region Jean-Pierre Bachmann
// Erstellt von Jean-Pierre Bachmann am 18:38
#endregion

using IEADPC.Shell.Contracts.Attributes;
using IEADPC.Shell.Contracts.Interfaces;
using IEADPC.Shell.Contracts.Interfaces.Services.ModuleServices;
using IEADPC.Shell.Contracts.Interfaces.Services.ShellServices;
using IEADPC.Shell.VisualServiceScheduler.View;
using IEADPC.Shell.VisualServiceScheduler.ViewModel;

namespace IEADPC.Shell.VisualServiceScheduler
{
    [VisualServiceExport("Shell.VisualServiceScheduler", typeof(IVisualService))]
    public class Module : IVisualService
    {
        public static IApplicationContext Context;

        #region Implementation of IVisualModule

        public object View
        {
            get { return new View.VisualServiceScheduler() { DataContext = ViewModel }; }
        }

        public object ViewModel
        {
            get { return new MainWindowViewModel(); }
        }

        public bool OnEnter()
        {
            return true;
        }

        public bool OnLeave()
        {
            return true;
        }

        #endregion

        #region Implementation of IService

        public void OnStart(IApplicationContext application)
        {
            Context = application;
        }

        #endregion
    }
}