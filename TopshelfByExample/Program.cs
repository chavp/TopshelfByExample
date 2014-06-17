using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopshelfByExample
{
    using Topshelf;

    class Program
    {
        /// <summary>
        ///  http://msdn.microsoft.com/en-us/magazine/dn745865.aspx
        ///  http://docs.topshelf-project.com/en/latest/overview/commandline.html
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HostFactory.Run(host =>
            {
                host.Service<TownCrier>(service =>
                {
                    service.ConstructUsing(() => new TownCrier());

                    service.WhenStarted(a => a.Start());
                    service.WhenStopped(a => a.Stop());

                    //service.WhenPaused(s => s.Pause());
                    //service.WhenContinued(s => s.Continue());

                    //service.WhenShutdown(s => s.Shutdown());
                });

                host.RunAsLocalSystem();                            //6

                host.SetDescription("Sample Topshelf Host");        //7
                host.SetDisplayName("Stuff");                       //8
                host.SetServiceName("stuff");                       //9
            });
        }
    }
}
