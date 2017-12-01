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
        public string Nombre { get; private set; }
        public double Cliente { get; private set; }
        public DateTime Entrega { get; private set; }

        public Pedido(int pedido, string nombre, double cliente, DateTime entrega)
        {
            PedidoId = pedido;
            Nombre = nombre;
            Cliente = cliente;
            Entrega = entrega;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Pedidos.Core.Pedido"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Pedidos.Core.Pedido"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "Pedido {0} del cliente {1} con entrega en la fecha: {3}\n",
                this.PedidoId, this.Cliente, this.Entrega);
        }
    }
}
