using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Bloc
{
    public partial class Bloc_de_notas : Form
    {
        string carpeta = Application.StartupPath + @"\Archivos de texto";
        public Bloc_de_notas()
        {
            try
            {
                if (!Directory.Exists(carpeta))
                {
                    MessageBox.Show("La carpeta no existe, creando");
                    Directory.CreateDirectory(carpeta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            InitializeComponent();
        }
        private TreeNode CrearArbol(DirectoryInfo directoryInfo)
        {
            TreeNode treeNode = new TreeNode(directoryInfo.Name);

            foreach (var item in directoryInfo.GetDirectories())
            {
                treeNode.Nodes.Add(item.Name);
            }
            foreach (var item in directoryInfo.GetFiles())
            {
                if (Path.GetExtension(item.FullName)== ".txt")
                {
                    treeNode.Nodes.Add(new TreeNode(item.Name));
                }
               
            }
            return treeNode;
        }


        private void Bloc_de_notas_Load(object sender, EventArgs e)
        {
            string nombre ="kk";
            File.Create(carpeta + @"\" + nombre + ".txt");
            trvArchivos.Nodes.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(carpeta);

            trvArchivos.Nodes.Add(CrearArbol(directoryInfo));
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trvArchivos_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNombre.Visible = true;
            btnCrear.Visible = true;
            richTextBox1.Clear();
            
        }

        private void cambiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNombre.Visible = true;
            btnCambiar.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            File.AppendAllText(carpeta + @"\" + txtNombre.Text + ".txt",richTextBox1.Text);
            trvArchivos.Nodes.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(carpeta);

            trvArchivos.Nodes.Add(CrearArbol(directoryInfo));
            
            btnCrear.Visible = false;
            txtNombre.Clear();
            txtNombre.Visible = false;
            richTextBox1.Clear();

        }

        private void trvArchivos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Clear();
            string ruta = trvArchivos.SelectedNode.FullPath;
            string extension = Path.GetExtension(ruta);
            if (extension == ".txt")
            {
                richTextBox1.Text = File.ReadAllText(ruta);
            }
            else
            {
                MessageBox.Show("No es un archivode texto");
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path =trvArchivos.SelectedNode.FullPath;
            trvArchivos.SelectedNode.Remove();
            File.Delete(path);
        }

        private void arbirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string ruta;
            if (trvArchivos.SelectedNode == null)
            {
                ruta = carpeta;
            }
            else
            {
                ruta = trvArchivos.SelectedNode.FullPath;
                MessageBox.Show(ruta);
            }
            
            string extension = Path.GetExtension(ruta);
            if (extension == ".txt")
            {
                richTextBox1.Text = File.ReadAllText(ruta);
            }
            else
            {
                MessageBox.Show("No es un archivode texto");
            }
        }

        private void trvArchivos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                string ruta;
                string extension;
                try
                {
                    trvArchivos.SelectedNode = trvArchivos.GetNodeAt(e.X, e.Y);
                    
                    if(trvArchivos.SelectedNode == null)
                    {
                        ruta = carpeta;
                    }
                    else
                    {
                        ruta = trvArchivos.SelectedNode.FullPath;
                    }
                    extension = Path.GetExtension(ruta);
                    if (extension == ".txt")
                    {
                        nuevoToolStripMenuItem.Enabled = false;
                        eliminarToolStripMenuItem.Enabled = true;
                        cambiarNombreToolStripMenuItem.Enabled = true;
                        arbirToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        nuevoToolStripMenuItem.Enabled = true;
                        eliminarToolStripMenuItem.Enabled = false;
                        cambiarNombreToolStripMenuItem.Enabled = false;
                        arbirToolStripMenuItem.Enabled = false;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " +ex.Message );
                }
              
            }

        }

        private void contextMenuStripEdit_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void nuevoToolStripFile_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string path = trvArchivos.SelectedNode.FullPath;
            string newpath = carpeta + @"\" + txtNombre.Text + ".txt";
            File.Move(path, newpath);
            trvArchivos.Nodes.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(carpeta);

            trvArchivos.Nodes.Add(CrearArbol(directoryInfo));

            btnCambiar.Visible = false;
            txtNombre.Clear();
            txtNombre.Visible = false;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path =trvArchivos.SelectedNode.FullPath;
          
            
                File.WriteAllText(path, richTextBox1.Text);
                trvArchivos.Nodes.Clear();

                DirectoryInfo directoryInfo = new DirectoryInfo(carpeta);

                trvArchivos.Nodes.Add(CrearArbol(directoryInfo));
                MessageBox.Show("Guardado");
                richTextBox1.Clear();
          
            

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            OpenFileDialog msg = new OpenFileDialog();
            msg.Filter = "Archivos de texto|*.txt";
            DialogResult res = msg.ShowDialog();

            if (res == DialogResult.OK)
                richTextBox1.Text = File.ReadAllText(msg.FileName);
        }
    }
}
