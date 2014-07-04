#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 16:47

#endregion

using System;
using System.Windows;
using System.Windows.Shell;
using DevExpress.Xpf.Bars;
using IEADPC.Shell.Commen.DevExpress13140.ViewModel;
using IEADPC.Shell.Commen.DevExpress13140.Window;
using IEADPC.Shell.Commen.DevExpressContracts.Interfaces.Services.ContainerService;
using IEADPC.Shell.Contracts.Attributes;
using IEADPC.Shell.Contracts.Interfaces;
using IEADPC.Shell.Contracts.Interfaces.Services.ApplicationServices;

namespace IEADPC.Shell.Commen.DevExpress13140.Service.Shell.VisualModule
{
    [VisualServiceExport("VisualMainWindow", true, typeof(IApplicationContainer))]
    public class VisualMainWindow : IApplicationContainer
    {
        public VisualMainWindow()
        {
            BarManager.CheckBarItemNames = false;
        }

        #region Implementation of IVisualModule

        public object View { get; private set; }

        public object ViewModel { get; private set; }

        public bool OnEnter()
        {
            try
            {
                View = new MainWindow ();
                Application.Current.MainWindow = (MainWindow)View;
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.Activate();
                Application.Current.MainWindow.Focus();

                Application.Current.MainWindow = View as MainWindow;
                System.Windows.Application.Current.MainWindow.TaskbarItemInfo = new TaskbarItemInfo();
                ViewModel = ApplicationProxy.ServicePool.GetDefaultSingelService<IRemoteApplicationViewService>();
                Application.Current.MainWindow.DataContext = ViewModel;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool OnLeave()
        {
            ((MainWindowViewModel)ViewModel).OnLeave();
            return true;
        }

        #endregion

        #region Implementation of IService

        public void OnStart(IApplicationContext application)
        {
            ApplicationProxy = application;
        }

        #endregion

        #region Implementation of IApplicationContainer

        public static IApplicationContext ApplicationProxy { get; set; }

        public IApplicationContext ApplicationContextProxy
        {
            get { return ApplicationProxy; }
        }

        #endregion
    }
}