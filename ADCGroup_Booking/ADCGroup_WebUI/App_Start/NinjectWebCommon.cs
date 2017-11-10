[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ADCGroup_WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ADCGroup_WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace ADCGroup_WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ADCGroup_Service.InterfaceEx.Service_Basic;
    using ADCGroup_Service.Service.Service_Basic;
    using ADCGroup_Service.InterfaceEx.Service_Booking;
    using ADCGroup_Service.Service.Service_Booking;
    using ADCGroup_Service.InterfaceEx.Service_Login;
    using ADCGroup_Service.Service.Service_Login;
    using Ninject.Web.Common.WebHost;
    using ADCGroup_Service.InterfaceEx.Service_Html;
    using ADCGroup_Service.Service.Service_Html;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IChangeType>().To<ChangeType>();
            kernel.Bind<IMeeting>().To<Metting>();
            kernel.Bind<IJiraLogin>().To<JiraLogin>();
            kernel.Bind<IService_Login>().To<Login>();
            kernel.Bind<IHtml_MeetingRoom>().To<Html_MeetingRoom>();
        }        
    }
}
