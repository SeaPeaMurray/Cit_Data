using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Interactivity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;

namespace USAspendingWindow
{
   public class BootStrapper : UnityBootstrapper
{
    protected override System.Windows.DependencyObject CreateShell()
    {
        return this.Container.Resolve<PrismAppShell>();
    }
    protected override void InitializeModules()
    {
        base.InitializeModules();
        App.Current.MainWindow = (PrismAppShell)this.Shell;
        App.Current.MainWindow.Show();
    }
    protected override void ConfigureModuleCatalog()
    {
        base.ConfigureModuleCatalog();
        ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
        // Seems like as soon as you add a new module, internally seletor module
        // adopter (since blotter region is on tab control), automatically adds a tab item)
        moduleCatalog.AddModule(typeof(usaspendmodule));
        //moduleCatalog.AddModule(typeof(PrismApp.Module.Deriv.Blotter.DerivBlotterModule));
        //moduleCatalog.AddModule("CashBlotterModule", 
        //   "PrismApp.Module.Cash.Blotter.CashBlotterModule");

    }
}
}
