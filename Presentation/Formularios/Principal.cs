using AppCore.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Formularios
{
    public partial class Principal : Form
    {
        IArchivotxtServices archivotxtServices;
        public Principal(IArchivotxtServices ArchivotxtServices)
        {
            this.archivotxtServices = ArchivotxtServices;
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
