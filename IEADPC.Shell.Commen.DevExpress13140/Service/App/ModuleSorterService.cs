#region Jean-Pierre Bachmann

// Erstellt von Jean-Pierre Bachmann am 11:02

#endregion

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IEADPC.Shell.Commen.DevExpress13140.Ribbon;
using IEADPC.Shell.Contracts.Attributes;
using IEADPC.Shell.Contracts.Interfaces;
using IEADPC.Shell.Contracts.Interfaces.Metadata;
using IEADPC.Shell.Contracts.Interfaces.Services;

namespace IEADPC.Shell.Commen.DevExpress13140.Service.App
{
    [ServiceExport("ModuleSorterService", typeof (IModuleSorterService))]
    public class ModuleSorterService : IModuleSorterService
    {
        #region Implementation of IModuleSorterService

        public ModuleLayoutDescriptor GenerateDescriptor(IVisualServiceMetadata module)
        {
            return new ModuleLayoutDescriptor(module.Descriptor, "Application", 1, "Application", 1,
                                              "Application " + module.Descriptor, 1, module);
        }

        public IEnumerable<ModuleLayoutDescriptor> Sort(IEnumerable<ModuleLayoutDescriptor> modules)
        {
            return modules.OrderBy(s => s.Label);
        }

        #endregion

        #region Implementation of IService

        public void OnStart(IApplicationContext application)
        {
        }

        #endregion
    }

    public interface IModuleSorterService : IService
    {
        ModuleLayoutDescriptor GenerateDescriptor(IVisualServiceMetadata module);
        IEnumerable<ModuleLayoutDescriptor> Sort(IEnumerable<ModuleLayoutDescriptor> modules);
    }
}