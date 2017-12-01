using GestionPedidos.Core;
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


        public const int ColNum = 0;
        public const int ColKms = 1;
        public const int ColOrg = 2;
        public const int ColDest = 3;
        public const int ColHoraLLegada = 4;



        public MainWindow()
        {
            this.Build();
            pedidos = RegistroPedidos.RecuperaXml();
            Actualizar();
        }


        private void Salir()
        {
            //        this.pedidos.GuardaXml();
            this.Dispose(true);
        }

        private void Inserta()
        {
            DlgInserta dlgInserta = new DlgInserta();
            if (dlgInserta.ShowDialog() == DialogResult.OK)
            {
                //      this.pedidos.Add(new Pedido(dlgInserta.CiudadOrigen,
                //                                    dlgInserta.CiudadDestino,
                //                                  dlgInserta.Kms));

                this.Actualizar();
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
                if(item.Entrega.Date == fecha.Date)
                {
                    pedidosFiltrados.Add(item);
                }
            }
            this.pnlShowDate.updateList(pedidosFiltrados);
        }



        private void Guardar()
        {
            throw new NotImplementedException();
        }
        private void Eliminar()
        {
            throw new NotImplementedException();
        }

        public RegistroPedidos pedidos;
    }
}
