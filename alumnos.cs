using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calificacion
{
    public partial class alumnos : Form
    {
        public alumnos()
        {
            InitializeComponent();
        }
        private void AgregarAlumnos(object sender, EventArgs e)
        {
            RegistrarAlumnos reg = new RegistrarAlumnos();
             reg.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void alumnos_Load(object sender, EventArgs e)
        {
            gvalumno.DataSource = central.CargarAlumno();
        }
    }
}
