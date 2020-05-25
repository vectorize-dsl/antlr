using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Vectorize.Editor
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            LogManager.GetLog = t => new DebugLog(t);

            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();

            container.PerRequest<ShellViewModel>();
            container.PerRequest<Features.Workbench.WorkbenchViewModel>();
            container.PerRequest<Features.Workbench.CodeEditorViewModel>();
            container.PerRequest<Features.Workbench.PreviewViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}