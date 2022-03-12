using AppCore.IServices;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class ArchivotxtServices : BaseServices<Archivotxt>, IArchivotxtServices
    {
        IArchivotxtModel archivotxtModel;
        public ArchivotxtServices(IArchivotxtModel model) : base(model)
        {
            this.archivotxtModel = model;
        }
        public void EditName(Archivotxt t, string nn)
        {
            archivotxtModel.EditName(t, nn);
        }

        public void EditText(Archivotxt t)
        {
            archivotxtModel.EditText(t);
        }
    }
}
