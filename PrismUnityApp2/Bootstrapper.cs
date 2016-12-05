using Microsoft.Practices.Unity;
using Prism.Unity;
using PrismUnityApp2.Views;
using System.Windows;
using ModuleA;
using Prism.Modularity;

namespace PrismUnityApp2
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ModuleAModule));
            return catalog;
        }
    }
}
