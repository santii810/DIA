using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionPedidos.View
{
    internal class DlgInserta :Form
    {
        private TextBox edNombre;
        private NumericUpDown edCliente;
        private DateTimePicker edEntrega;

        public DlgInserta()
        {
            this.Build();
        }

        private Panel BuildPnlNombre()
        {
            var toret = new Panel();
            this.edNombre = new TextBox {  Dock = DockStyle.Fill };

            var lbNombre = new Label
            {
                Text = "Nombre del pedido:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.edNombre);
            toret.Controls.Add(lbNombre);
            toret.Dock = DockStyle.Top;
            toret.MaximumSize = new Size(int.MaxValue, edNombre.Height * 2);

            return toret;
        }

        private Panel BuildPnlCliente()
        {
            var toret = new Panel();
            this.edCliente = new NumericUpDown { Dock = DockStyle.Fill };

            var lbCliente = new Label
            {
                Text = "Número de cliente:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.edCliente);
            toret.Controls.Add(lbCliente);
            toret.Dock = DockStyle.Top;
            toret.MaximumSize = new Size(int.MaxValue, edCliente.Height * 2);

            return toret;
        }

        private Panel BuildPnlEntrega()
        {
            var toret = new Panel();
            this.edEntrega = new DateTimePicker { Dock = DockStyle.Fill };

            var lbEntrega = new Label
            {
                Text = "Fecha de la entrega:",
                Dock = DockStyle.Left
            };

            toret.Controls.Add(this.edEntrega);
            toret.Controls.Add(lbEntrega);
            toret.Dock = DockStyle.Top;
            toret.MaximumSize = new Size(int.MaxValue, edEntrega.Height * 2);

            return toret;
        }

        private Panel BuildPnlBotones()
        {
            var toret = new TableLayoutPanel()
            {
                ColumnCount = 2,
                RowCount = 1
            };

            var btCierra = new Button()
            {
                DialogResult = DialogResult.Cancel,
                Text = "&Cancelar"
            };

            var btGuarda = new Button()
            {
                DialogResult = DialogResult.OK,
                Text = "&Guardar"
            };

            this.AcceptButton = btGuarda;
            this.CancelButton = btCierra;

            toret.Controls.Add(btGuarda);
            toret.Controls.Add(btCierra);
            toret.Dock = DockStyle.Top;

            return toret;
        }

        private void Build()
        {
            this.SuspendLayout();

            var pnlInserta = new TableLayoutPanel { Dock = DockStyle.Fill };
            pnlInserta.SuspendLayout();
            this.Controls.Add(pnlInserta);

            var pnlNombre = this.BuildPnlNombre();
            pnlInserta.Controls.Add(pnlNombre);

            var pnlCliente = this.BuildPnlCliente();
            pnlInserta.Controls.Add(pnlCliente);

            var pnlEntrega = this.BuildPnlEntrega();
            pnlInserta.Controls.Add(pnlEntrega);


            var pnlBotones = this.BuildPnlBotones();
            pnlInserta.Controls.Add(pnlBotones);

            pnlInserta.ResumeLayout(true);

            this.Text = "Nuevo pedido";
            this.Size = new Size(400,
                            pnlNombre.Height + pnlCliente.Height
                            + pnlEntrega.Height + pnlBotones.Height);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }


        /// <summary>
        /// Obtiene el nombre de pedido introducido por el usuario.
        /// </summary>
        /// <value>Una cadena de caracteres con el nombre del pedido.</value>
        public string Nombre => this.edNombre.Text;

        /// <summary>
        /// Obtiene el cliente introducido por el usuario.
        /// </summary>
        /// <value>El id de cliente como un entero.</value>
        public string Cliente => this.edCliente.Text;

        /// <summary>
        /// Obtiene la fecha de entrega del pedido introducida por el usuario.
        /// </summary>
        /// <value>La fecha de entrega como datetime.</value>
        public DateTime Entrega => Convert.ToDateTime(this.edEntrega.Value);

    }
}
