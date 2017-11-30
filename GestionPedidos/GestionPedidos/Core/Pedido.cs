using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidos.Core
{
    public class Pedido
    {
        public int PedidoId { get; private set; }
        public int Cliente { get; private set; }
        public DateTime Entrega { get; private set; }

        public Pedido(int pedido,  int cliente, DateTime entrega)
        {
            PedidoId = pedido;
            Cliente = cliente;
            Entrega = entrega;
        }
    }
}
