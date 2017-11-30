using GestionPedidos.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedidos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainWindow coreWindow = new MainWindow();
            Application.Run(coreWindow);
        }
    }
}
