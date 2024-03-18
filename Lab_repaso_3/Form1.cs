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

namespace Lab_repaso_3
{
    public partial class Form1 : Form
    {
        List<Propiedades> propiedad = new List<Propiedades>();
        List<Propietarios> propietario = new List<Propietarios>();
        List<Reporte_propiedad> reporte = new List<Reporte_propiedad>();
   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar_Propiedades();
            mostrar_Propiedades();
            cargar_Propietarios();
            mostrar_Propietarios();
        }
        private void cargar_Propiedades()
        {
            string fileName = "Propiedades.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propiedades propiedades = new Propiedades();
                propiedades.No_casa = reader.ReadLine();
                propiedades.Dpi = Convert.ToInt64(reader.ReadLine());
                propiedades.Cuota_mantenimiento= int.Parse(reader.ReadLine());
                propiedad.Add(propiedades);
            }
            reader.Close();
        }
        private void mostrar_Propiedades()
        {
            dataGridViewPropiedades.DataSource = null;
            dataGridViewPropiedades.DataSource = propiedad;
            dataGridViewPropiedades.Refresh();
        }
        private void cargar_Propietarios ()
        {
            string fileName = "Propietarios.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propietarios propietarios = new Propietarios();
                propietarios.Dpi = Convert.ToInt64(reader.ReadLine());
                propietarios.Nombre = reader.ReadLine();
                propietarios.Apellido = reader.ReadLine();
                propietario.Add(propietarios);
            }
            reader.Close();
        }
        private void mostrar_Propietarios()
        {
            dataGridViewPropietarios.DataSource = null;
            dataGridViewPropietarios.DataSource = propiedad;
            dataGridViewPropietarios.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (reporte.Count == 0)
            {
                foreach (Propietarios propietarios in propietario)
                {
                    Propiedades propiedades = propiedad.FirstOrDefault(c => c.Dpi == propietarios.Dpi);
                    Reporte_propiedad reportes = new Reporte_propiedad();
                    reportes.Nombre = propietarios.Nombre;
                    reportes.Apellido = propietarios.Apellido;
                    reportes.No_casa = propiedades.No_casa;
                    reportes.Cuota_mantenimiento = propiedades.Cuota_mantenimiento;
                    reporte.Add(reportes);

                }
            }
        }
    }
}
