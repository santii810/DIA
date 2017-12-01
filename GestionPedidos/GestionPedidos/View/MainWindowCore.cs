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
        public MainWindow()
        {
            this.Build();
           pedidos = RegistroPedidos.RecuperaXml();
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

                this.Actualiza();
            }
        }

        private void Actualiza()
        {
            throw new NotImplementedException();
        }

        private void Guardar()
        {
            throw new NotImplementedException();
        }
        private void Eliminar()
        {
            throw new NotImplementedException();
        }

        private RegistroPedidos pedidos;
    }
}
