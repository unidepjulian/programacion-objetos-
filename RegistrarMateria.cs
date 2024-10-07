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
    public partial class RegistrarMateria : Form
    {
        public RegistrarMateria()
        {
            InitializeComponent();
        }

        private void RegistrarMateria_Load(object sender, EventArgs e)
        {
            MaTeria materia = new MaTeria()
            {
                Nombre = tbNombre.Text,
                codigo = tbCodigo.Text

            };
            central.RegitrarMAteria(materia);

        }
    }
}
