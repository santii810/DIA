using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace GestionPedidos.Core
{
    public class RegistroPedidos
    {
        public const string ArchivoXml = @"..\..\Samples\pedidos.xml";
        public const string EtqPedidos = "pedidos";
        public const string EtqPedido = "pedido";
        public const string EtqEntrega = "fechaEntrega";
        public const string EtqCliente = "idCliente";
        public const string EtqNombre = "nombre";
        public const string EtqIdPedido = "id";

        private List<Pedido> pedidos;

        /// <summary>
        /// Crea un <see cref="T:Pedidos.Core.RegistroPedidos"/> sin pedidos.
        /// </summary>
        public RegistroPedidos()
        {
            this.pedidos = new List<Pedido>();
        }


        public Pedido Get(int n)
        {
            return pedidos[n];
        }

        public List<Pedido> GetList()
        {
            return pedidos;
        }

        /// <summary>
        /// Inserta un pedido dado al final de la lista.
        /// </summary>
        /// <param name="pedido">Un objeto <see cref="Pedido"/>.</param>
		public void Add(Pedido pedido)
        {
            this.pedidos.Add(pedido);
        }

        /// <summary>
        /// Elimina un pedido dado.
        /// </summary>
        /// <returns>True si se ha eliminado, False en otro caso.</returns>
        /// <param name="pedido">El <see cref="Pedido"/> a eliminar.</param>
		public bool Remove(Pedido pedido)
        {
            return this.pedidos.Remove(pedido);
        }

        /// <summary>
        /// Devuelve el total de pedidos guardados en este registro.
        /// </summary>
        /// <value>El total de pedidos como entero.</value>
		public int CountPedidos
        {
            get { return this.pedidos.Count; }
        }

        /// <summary>
        /// Elimina todos los pedidos almacenados.
        /// </summary>
		public void Clear()
        {
            this.pedidos.Clear();
        }

        /// <summary>
        /// Comprueba si el pedido dado se encuentra guardado.
        /// </summary>
        /// <returns>True si se encuentra, False en otro caso.</returns>
        /// <param name="pedido">El <see cref="Pedido"/> a comprobar.</param>
		public bool Contains(Pedido pedido)
        {
            return this.pedidos.Contains(pedido);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Pedidos.Core.RegistroViajes"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Pedidos.Core.RegistroViajes"/>.</returns>
		public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Pedido pedido in this.pedidos)
            {
                toret.AppendLine(pedido.ToString());
            }

            return toret.ToString();
        }

        /// <summary>
        /// Guarda la lista de pedidos como xml.
        /// </summary>
        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }

        /// <summary>
        /// Guarda la lista de pedidos como XML.
        /// <param name="nf">El nombre del archivo.</param>
        /// </summary>
        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var raiz = new XElement(EtqPedidos);

            foreach (Pedido pedido in this.pedidos)
            {
            DateTime dateVal = DateTime.ParseExact(pedido.Entrega.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                raiz.Add(
                    new XElement(EtqPedido,
                            new XAttribute(EtqIdPedido, pedido.PedidoId.ToString()),
                            new XElement(EtqNombre, pedido.Nombre),
                            new XElement(EtqCliente, pedido.Cliente.ToString()),
                            new XElement(EtqEntrega, dateVal)));
            }

            doc.Add(raiz);
            doc.Save(nf);
        }

        /// <summary>
        /// Recupera los pedidos desde un archivo XML.
        /// </summary>
        /// <returns>Un <see cref="RegistroPedidos"/> con los
        /// <see cref="Pedido"/>'s.</returns>
        /// <param name="f">El nombre del archivo.</param>
        public static RegistroPedidos RecuperaXml(string nf)
        {
            var toret = new RegistroPedidos();

            try
            {
                var doc = XDocument.Load(nf);

                if (doc.Root != null
                  && doc.Root.Name == EtqPedidos)
                {
                    var pedidos = doc.Root.Elements(EtqPedido);

                    foreach (XElement pedidoXml in pedidos)
                    {
                        toret.Add(new Pedido(
                            (int)pedidoXml.Attribute(EtqIdPedido),
                            (string)pedidoXml.Element(EtqNombre),
                            (int)pedidoXml.Element(EtqCliente),
                            (DateTime)pedidoXml.Element(EtqEntrega)));
                    }
                }
            }
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                toret.Clear();
            }

            return toret;
        }

        /// <summary>
        /// Crea un registro de pedidos con la lista de pedidos recuperada
        /// del archivo por defecto.
        /// </summary>
        /// <returns>Un <see cref="RegistroPedidos"/>.</returns>
		public static RegistroPedidos RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }
    }
}