using calificacion.entidades;
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
    public partial class RegistrarAlumnos : Form
    {
        public RegistrarAlumnos()
        {
            InitializeComponent();
        }

        private void RegistrarAlumnos_Load(object sender, EventArgs e)
        {


        }
        private void Registrar(object sender, EventArgs e)
        {
            AlumnO alumno1 = new AlumnO()
            {
                Nombres = tbnombre.Text,
                Apellidos = tbapellido.Text,
                Matricula = tbmatricula.Text, 


            };
           response resp =  central.RegistrarAlumnos(alumno1);
            if( resp.Codigo == 1) 
            {
               
                MessageBox.Show(resp.Mensaje);
            }
            else if (resp.Codigo == 2 )
            {
                MessageBox.Show(resp.Mensaje,"error");
            }
        }

        private void tbnombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
