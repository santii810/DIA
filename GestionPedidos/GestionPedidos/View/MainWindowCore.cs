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
        }


        private void Salir()
        {
            this.pedidos.GuardaXml();
            this.Dispose(true);
        }
        
        private void Inserta()
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
