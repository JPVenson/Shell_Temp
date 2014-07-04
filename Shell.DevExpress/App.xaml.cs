using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Windows;
using IEADPC.Shell.Contracts.Interfaces.Services.ApplicationServices;
using IEADPC.Shell.MEF.Services;

namespace Shell.DevExpress13140
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DebuggerStepThrough]
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServicePool.PreLoadServicePool("IEADPC");
            var defaultSingelService = ServicePool.Instance.GetDefaultSingelService<IApplicationContainer>();

            if (defaultSingelService == null)
                throw new CompositionException("Could not load the Default IVisualMainWindow");

            if (!defaultSingelService.OnEnter())
                Shutdown(1);
        }

        //[DebuggerStepThrough]
        protected override void OnExit(ExitEventArgs e)
        {
            var defaultSingelService = ServicePool.Instance.GetDefaultSingelService<IApplicationContainer>();

            if (defaultSingelService == null)
                throw new CompositionException("Could not load the Default IVisualMainWindow");

            if (defaultSingelService.OnLeave())
                base.Shutdown();
        }
    }
}
