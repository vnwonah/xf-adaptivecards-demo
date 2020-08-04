using XFAdaptiveCards.Interfaces;
using XFAdaptiveCards.Services;

namespace XFAdaptiveCards.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            RegisterTypes();
            LoadApplication(new XFAdaptiveCards.App());
        }

        void RegisterTypes()
        {
            XFAdaptiveCards.App.RegisterType<ILogger, Logger>();
            XFAdaptiveCards.App.BuildContainer();
        }
    }
}
