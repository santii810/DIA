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



            this.SuspendLayout();
            this.Controls.Add(this.pnlPpal);
            this.pnlPpal = new Panel()
            {
                Dock = DockStyle.Fill
            };

            this.pnlPpal.SuspendLayout();
            this.Controls.Add(this.pnlPpal);
            this.pnlPpal.Controls.Add(this.BuildShowPanel());
            this.pnlPpal.Controls.Add(this.BuildCalendarPanel());

            this.pnlPpal.ResumeLayout(false);



            this.MinimumSize = new Size(600, 400);
            this.Resize += (obj, e) => this.ResizeWindow();
            this.Text = "Gestion Pedidos";

            this.ResumeLayout(true);
            this.ResizeWindow();
            this.Closed += (sender, e) => this.Salir();
            //           this.Shown += (sender, e) => this.Actualiza();
        }

        private ShowPanel BuildShowPanel()
        {
            pnlShowDate = new ShowPanel();
            pnlShowDate.SuspendLayout();
            pnlShowDate.Dock = DockStyle.Right;
            return pnlShowDate;
        }


        /* Contruyo el calendarPanel y lo añado al mainwindow*/
        private CalendarPanel BuildCalendarPanel()
        {
            CalendarPanel pnlCalendar = new CalendarPanel();
            pnlCalendar.SuspendLayout();
            pnlCalendar.Dock = DockStyle.Left;
            return pnlCalendar;
        }



        /* Añade los elementos del menu*/
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
                GetManifestResourceStream("GestionPedidos.Res.appIcon.ico");

            if (resourceAppIcon != null)
            {
                this.Icon = Icon.FromHandle(
                    new Bitmap(resourceAppIcon).GetHicon());
            }
            return;
        }

        private void ResizeWindow()
        {
            // Tomar las nuevas medidas
            int width = this.pnlPpal.ClientRectangle.Width;
            int height = this.pnlPpal.ClientRectangle.Height;
            pnlShowDate.updateWidth(width, height);
        }


        private ShowPanel pnlShowDate;
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
