using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IArchivotxtModel:IModel<Archivotxt>
    {
        void EditText(Archivotxt t);
        void EditName(Archivotxt t, string nn);
    }
}
