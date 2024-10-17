using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy.interfaces
{// Esta es una interfaz llamada IServicio
    internal interface IServicio
    {
        // Este método, AgregarServicio, está diseñado para agregar un nuevo servicio al sistema.
        void AgregarServicio(Servicio servicio);
        // Este método, ObtenerServicios, está diseñado para obtener una lista de todos los servicios disponibles.
        List<Servicio> ObtenerServicios();
    }
}
