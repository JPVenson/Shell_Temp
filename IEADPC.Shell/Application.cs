#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 15:50

#endregion

using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Windows;
using IEADPC.Shell.Contracts.Interfaces.Services.ApplicationServices;
using IEADPC.Shell.MEF;
using IEADPC.Shell.MEF.Log;
using IEADPC.Shell.MEF.Services;

namespace IEADPC.Shell
{
    public class Program : Application
    {
        [STAThread]
        public static void Main(string[] param)
        {
            Main2();
        }

        [DebuggerStepThrough]
        public static void Main2()
        {
            var app = new Program();
            app.Run();
        }

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