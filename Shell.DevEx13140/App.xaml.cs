using System.ComponentModel.Composition;
using System.Windows;
using DevExpress.Xpf.Core;
using IEADPC.Shell.Contracts.Interfaces.Services.ApplicationServices;
using IEADPC.Shell.MEF.Services;
using Shell.DXSplashScreen;
using Shell.Services;

namespace Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var sc = new SplashScreenService();
            sc.StartSplashScreen();

            ServicePool.PreLoadServicePool("IEADPC");
            var defaultSingelService = ServicePool.Instance.GetDefaultSingelService<IApplicationContainer>();

            if (defaultSingelService == null)
                throw new CompositionException("Could not load the Default IVisualMainWindow");

            if (!defaultSingelService.OnEnter())
                Shutdown(1);

            sc.StopSplashScreen();
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
