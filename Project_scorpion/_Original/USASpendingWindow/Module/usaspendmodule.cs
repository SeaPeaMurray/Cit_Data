using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Interactivity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;


namespace USAspendingWindow
{
    class usaspendmodule : IModule
{
    private readonly IRegionViewRegistry regionViewRegistry = null;
    public usaspendmodule(IRegionViewRegistry regionViewRegistry)
    {
        this.regionViewRegistry = regionViewRegistry;
    }
    public void Initialize()
    {
        var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
        this.regionViewRegistry.RegisterViewWithRegion("RibbonRegion", typeof(mainmenu));
       // this.regionViewRegistry.RegisterViewWithRegion("BlotterRegion", typeof(USASpendingloader));
        this.regionViewRegistry.RegisterViewWithRegion("BlotterRegion", typeof(summaryview));
        // register other views used for navigation.
        container.RegisterType<Object, summaryview>("summaryview");
        container.RegisterType<Object, USASpendingloader>("USASpendingloader");

        container.RegisterType<Object, USASpendingloaderadvanced>("USASpendingloaderadvanced");
        container.RegisterType<Object, outofscopefilterview>("outofscopefilterview");
        container.RegisterType<Object, Contracttest>("Contracttest");
        container.RegisterType<Object, OOSreviewsummary>("OOSreviewsummary");
        container.RegisterType<Object, zeroreviewsummary>("zeroreviewsummary");
        container.RegisterType<Object, querycontract>("querycontract");
        container.RegisterType<Object, querynewpiid>("querynewpiid");
        container.RegisterType<Object, GovWinloader>("GovWinloader");
    }
}
}
