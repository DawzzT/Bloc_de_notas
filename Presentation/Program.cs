using Autofac;
using AppCore.IServices;
using AppCore.Services;
using Domain.Interfaces;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Formularios;

namespace Presentation
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ContainerBuilder();
            builder.RegisterType<StreamArchivotxtRepository>().As<IArchivotxtModel>();
            builder.RegisterType<ArchivotxtServices>().As<IArchivotxtServices>();
            var container = builder.Build();
            Application.Run(new Principal(container.Resolve<IArchivotxtServices>()));
        }
    }
}
