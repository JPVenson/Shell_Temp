#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 12:17

#endregion

using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using IEADPC.Shell.Contracts.Interfaces;
using IEADPC.Shell.Contracts.Interfaces.Services.ModuleServices;
using Shell.DXSplashScreen;

namespace Shell.Services
{
    public class SplashScreenService : ISplashScreenService
    {
        public static DevExSplashScreen SplashScreen;

        #region Implementation of IService

        public void OnStart(IApplicationContext application)
        {
            Context = application;
        }

        #endregion

        #region Implementation of IApplicationProvider

        public IApplicationContext Context { get; set; }

        #endregion

        #region Implementation of ISplashScreenService

        public void StartSplashScreen()
        {
            if (_thread == null)
            {
                _thread = new Thread(StartSplashScreen);
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.Start();
                return;
            }
            if (_dispatcher == null)
            {
                _dispatcher = Dispatcher.CurrentDispatcher;
                _dispatcher.Invoke(new Action(() =>
                {
                    SplashScreen = new DevExSplashScreen();
                    SplashScreen.SetProgressState(true);
                    SplashScreen.ShowDialog();
                }));

                while (!_dispatcher.HasShutdownStarted)
                {
                    _dispatcher.Invoke(new Action(() => { }), DispatcherPriority.SystemIdle);
                }
            }
        }

        public void StopSplashScreen()
        {
            _dispatcher.BeginInvoke(new Action(() =>
            {
                SplashScreen.CloseSplashScreen();
                _dispatcher.InvokeShutdown();
            }),DispatcherPriority.Send);
        }

        #endregion

        private Thread _thread;
        private Dispatcher _dispatcher;

        ~SplashScreenService()
        {
            _dispatcher.InvokeShutdown();
            _thread.Abort();
        }
    }

    public interface ISplashScreenService : IApplicationProvider
    {
        void StartSplashScreen();
        void StopSplashScreen();
    }
}

