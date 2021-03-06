﻿using GestionPedidos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedidos.View
{




    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            this.Build();
            pedidos = RegistroPedidos.RecuperaXml();
            Actualizar();
        }


        private void Salir()
        {
            this.pedidos.GuardaXml();
            this.Dispose(true);
        }

        private void Inserta()
        {
            DlgInserta dlgInserta = new DlgInserta();

            if (dlgInserta.ShowDialog() == DialogResult.OK)
            {
                this.pedidos.Add(new Pedido(pedidos.CountPedidos, dlgInserta.Nombre,
                                                    dlgInserta.Cliente,
                                                  dlgInserta.Entrega));
                this.Actualizar(dlgInserta.Entrega.Date);
            }
        }

        public void Actualizar()
        {
            Actualizar(DateTime.Now);
        }


        public void Actualizar(DateTime fecha)
        {
            List<Pedido> pedidosFiltrados = new List<Pedido>();
            foreach (Pedido item in pedidos.GetList())
            {
                if (item.Entrega.Date == fecha.Date)
                {
                    pedidosFiltrados.Add(item);
                }
            }
            this.pnlShowDate.updateList(pedidosFiltrados);
        }



        private void Guardar()
        {
            this.pedidos.GuardaXml();
        }

        private void Eliminar(Pedido pedido)
        {
            this.pedidos.Remove(pedido);
        }

        public RegistroPedidos pedidos;
    }
}
