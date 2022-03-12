using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.IServices
{
    public interface IArchivotxtServices: IServices<Archivotxt>
    {
        void EditText(Archivotxt t);
        void EditName(Archivotxt t, string nn);
    }
}
