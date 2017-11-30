using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedidos.View
{
    public partial class MainWindow
    {
        public void Build()
        {

            this.BuildIcons();
            this.BuildStatus();
            this.BuildMenu();
            this.BuildPanelLista();
        }

        private void BuildPanelLista()
        {
            Panel pnlLista = new Panel();
            pnlLista.SuspendLayout();
            pnlLista.Dock = DockStyle.Fill;





        }

        private void BuildMenu()
        {
            this.mPpal = new MainMenu();

            this.mArchivo = new MenuItem("&Archivo");
            this.mEditar = new MenuItem("&Editar");

            this.opSalir = new MenuItem("&Salir") { Shortcut = Shortcut.CtrlQ };
            this.opSalir.Click += (sender, e) => this.Salir();

            this.opGuardar = new MenuItem("&Guardar") { Shortcut = Shortcut.CtrlG };
            this.opGuardar.Click += (sender, e) => this.Guardar();

            this.opEliminar = new MenuItem("&Eliminar") { Shortcut = Shortcut.CtrlD };
            this.opEliminar.Click += (sender, e) => this.Eliminar();

            this.opInsertar = new MenuItem("&Insertar")
            {
                Shortcut = Shortcut.CtrlIns
            };
            this.opInsertar.Click += (sender, e) => this.Inserta();

            this.mArchivo.MenuItems.Add(this.opGuardar);
            this.mArchivo.MenuItems.Add(this.opSalir);
            this.mEditar.MenuItems.Add(this.opInsertar);
            this.mEditar.MenuItems.Add(this.opEliminar);

            this.mPpal.MenuItems.Add(this.mArchivo);
            this.mPpal.MenuItems.Add(this.mEditar);
            this.Menu = mPpal;
        }







        /*Añade una status bar en Dock-bot*/
        private void BuildStatus()
        {
            this.sbStatus = new StatusBar { Dock = DockStyle.Bottom };
            this.Controls.Add(this.sbStatus);
        }

        /* Buildea el icono de la app*/
        private void BuildIcons()
        {
            var assembly = System.Reflection.Assembly.GetEntryAssembly();
            var resourceAppIcon = assembly.
                GetManifestResourceStream("GestionPedidos.Res.appIcon.png");

            if (resourceAppIcon != null)
            {
                this.Icon = Icon.FromHandle(
                    new Bitmap(resourceAppIcon).GetHicon());
            }
            return;
        }



        private StatusBar sbStatus;
        private Panel pnlPpal;


        /*Menu atribbutes*/
        private MainMenu mPpal;
        private MenuItem mArchivo;
        private MenuItem mEditar;
        private MenuItem opSalir;
        private MenuItem opGuardar;
        private MenuItem opEliminar;
        private MenuItem opInsertar;


    }
}
