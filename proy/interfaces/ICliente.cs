using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proy.interfaces
{// Esta es una interfaz llamada ICliente,
    internal interface ICliente
    {
        void AgregarCliente(Cliente cliente); // Método para agregar un cliente
        List<Cliente> ObtenerClientes(); // Método que retorna una lista de clientes
    }
}
