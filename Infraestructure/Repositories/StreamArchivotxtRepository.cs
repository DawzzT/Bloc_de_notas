using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class StreamArchivotxtRepository : IArchivotxtModel
    {
        string carpetaPath = Directory.GetCurrentDirectory() + @"\Archivos de Texto";
        public void Create(Archivotxt t)
        {
            string archivoPath = @"\" + t.Nombre + ".txt";
            File.Create(carpetaPath+ archivoPath);
        }

        public void Delete(Archivotxt t)
        {
            string archivoPath = @"\" + t.Nombre + ".txt";
            File.Delete(carpetaPath + archivoPath);
        }

        public void EditName(Archivotxt t, string nn)
        {
            string nuevoNombrePath = @"\" + nn + ".txt";
            string archivoPath = @"\" + t.Nombre + ".txt";
            File.Move(carpetaPath + archivoPath, carpetaPath + nuevoNombrePath);
        }

        public void EditText(Archivotxt t)
        {
            string archivoPath = @"\" + t.Nombre + ".txt";
            File.AppendAllText(carpetaPath + archivoPath, t.Contenido);
        }
    }
}
