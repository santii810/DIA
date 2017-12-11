using GestionPedidos.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GestionPedidos.View
{
    internal class ShowPanel : Panel
    {
        private DataGridView grdLista;

        public ShowPanel()
        {
            this.SuspendLayout();

            // Crear gridview
            this.grdLista = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            this.grdLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdLista.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;


            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            var textCellTemplate2 = new DataGridViewTextBoxCell();
            var textCellTemplate3 = new DataGridViewTextBoxCell();

            textCellTemplate0.Style.BackColor = Color.LightGray;
            textCellTemplate0.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.BackColor = Color.Wheat;
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            textCellTemplate2.Style.BackColor = Color.Wheat;
            textCellTemplate2.Style.ForeColor = Color.Black;
            textCellTemplate3.Style.BackColor = Color.Wheat;
            textCellTemplate3.Style.ForeColor = Color.Black;

            var column0 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = COL_0_TITLE,
                Width = colWidths[0],
                ReadOnly = true
            };

            var column1 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = COL_1_TITLE,
                Width = colWidths[1],
                ReadOnly = true
            };

            var column2 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate2,
                HeaderText = COL_2_TITLE,
                Width = colWidths[2],
                ReadOnly = true
            };

            var column3 = new DataGridViewTextBoxColumn
            {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate3,
                HeaderText = COL_3_TITLE,
                Width = colWidths[3],
                ReadOnly = true
            };



            this.grdLista.Columns.AddRange(new DataGridViewColumn[] {
                column0, column1, column2, column3
            });

            this.Controls.Add(this.grdLista);
            this.ResumeLayout(false);
        }


        public void updateList(List<Pedido> pedidos)
        {
            grdLista.Rows.Clear();

            for (int i = 0; i < pedidos.Count; i++)
            {
                Pedido ped = pedidos[i];
                this.grdLista.Rows.Add();
                DataGridViewRow row = this.grdLista.Rows[i];

                row.Cells[0].Value = ped.PedidoId.ToString();
                row.Cells[1].Value = ped.Nombre;
                row.Cells[2].Value = ped.Cliente.ToString();
                row.Cells[3].Value = ped.Entrega.ToString();
            }

        }


        public void updateWidth(int width, int height)
        {
            /*165 = tamaño del Month calendar*/
            int panelWidth = width - 165;
            this.grdLista.Width = panelWidth;
            this.Width = panelWidth;


            colWidths[0] = (int)(panelWidth * 0.15);
            colWidths[1] = (int)(panelWidth * 0.25);
            colWidths[2] = (int)(panelWidth * 0.25);
            colWidths[3] = (int)(panelWidth * 0.35);

            int cont = 0;
            foreach (DataGridViewColumn col in grdLista.Columns)
            {
                col.Width = colWidths[cont++];
            }

            this.grdLista.Height = height;
        }

        public Pedido getCurrentPedido()
        {
            int id = (int)grdLista.CurrentRow.Cells[0].Value;
            string nombre = (string)grdLista.CurrentRow.Cells[1].Value;
            int idCliente = (int)grdLista.CurrentRow.Cells[2].Value;
            string entrega = (string)grdLista.CurrentRow.Cells[3].Value;
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Parse(entrega);

            return new Pedido(id,nombre,idCliente,dateTime);

        }

        public string COL_0_TITLE = "Id pedido";
        public string COL_1_TITLE = "Nombre";
        public string COL_2_TITLE = "Id cliente";
        public string COL_3_TITLE = "Fecha";
        public int[] colWidths = new int[] { 100, 100, 100, 100 };
    }
}