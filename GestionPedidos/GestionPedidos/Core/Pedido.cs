using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidos.Core
{
    public class Pedido
    {
        public string Nombre { get; private set; }
        public int Cliente { get; private set; }
        public DateTime Entrega { get; private set; }

        public Pedido(string nombre,  int cliente, DateTime entrega)
        {
            Nombre = nombre;
            Cliente = cliente;
            Entrega = entrega;
        }
    }
}
