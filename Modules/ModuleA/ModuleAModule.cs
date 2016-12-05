using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using PrismUnityApp2.Infrastructure;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IContentAView, ContentAView>();
            _container.RegisterType<IToolbarAView, ToolbarAView>();
            _container.RegisterType<IContentAViewModel, ContentAViewModel>();
            _container.RegisterType<IToolbarAViewModel, ToolbarAViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, () => _container.Resolve<IContentAView>());
            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, () => _container.Resolve<IToolbarAView>());
            var region = _regionManager.Regions[RegionNames.ToolbarRegion];
            //_regionManager.RequestNavigate();
            
        }
    }
}
