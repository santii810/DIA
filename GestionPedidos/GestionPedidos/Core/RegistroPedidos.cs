using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GestionPedidos.Core
{
    public class RegistroPedidos
    {
        public const string ArchivoXml = "pedidos.xml";
        public const string EtqPedidos = "pedidos";
        public const string EtqPedido = "pedido";
        public const string EtqEntrega = "fechaEntrega";
        public const string EtqCliente = "idCliente";
        public const string EtqIdPedido = "id";

        private List<Pedido> pedidos;

        /// <summary>
        /// Crea un <see cref="T:GestionPedidos.Core.RegistroPedidos"/> sin pedidos.
        /// </summary>
        public RegistroPedidos()
        {
            this.pedidos = new List<Pedido>();
        }

        /// <summary>
        /// Inserta un pedido dado al final de la lista.
        /// </summary>
        /// <param name="pedido">Un objeto <see cref="Pedido"/>.</param>
		public void Add(Pedido pedido)
        {
            this.pedidos.Add(pedido);
        }

        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

        /// <summary>
        /// Guarda la lista de viajes como XML.
        /// <param name="nf">El nombre del archivo.</param>
        /// </summary>
        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var raiz = new XElement(EtqPedidos);

            foreach (Pedido pedido in this.pedidos)
            {
                raiz.Add(
                    new XElement(EtqPedido,
                            new XAttribute(EtqIdPedido, pedido.Nombre),
                            new XElement(EtqCliente, pedido.Cliente.ToString()),
                            new XElement(EtqEntrega, pedido.Entrega.ToString())));
            }

            doc.Add(raiz);
            doc.Save(nf);
        }
    }
}