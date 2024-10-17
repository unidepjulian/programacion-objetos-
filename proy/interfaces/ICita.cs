using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy.interfaces
{// Esta es una interfaz llamada ICita
    internal interface ICita
    {
        // Este método, AgregarCita, está diseñado para agregar una nueva cita.
        void AgregarCita(Cita cita);

        // Este método, ObtenerCitasPorCliente, está diseñado para
        // obtener una lista de citas de un cliente 
        // Recibe el id del cliente como parámetro (idCliente) y retorna una lista de objetos de tipo Cita.
        List<Cita> ObtenerCitasPorCliente(int idCliente);
    }
}
