using System;
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

        public void updateWidth(int width,int  height)
        {
            /*165 = tamaño del Month calendar*/
            int panelWidth = width - 165;
            this.grdLista.Width = panelWidth;
            this.Width = panelWidth;
            for (int i = 0; i < colWidths.Length; i++)
            {
                colWidths[i] = panelWidth / (colWidths.Length);
            }

            int cont = 0;
            foreach (DataGridViewColumn col in grdLista.Columns)
            {
                col.Width = colWidths[cont++]; 
            }

            this.grdLista.Height = height;
        }

        public string COL_0_TITLE = "Id pedido";
        public string COL_1_TITLE = "Nombre";
        public string COL_2_TITLE = "Id cliente";
        public string COL_3_TITLE = "Fecha";
        public int[] colWidths = new int[] { 100, 100, 100, 100 };
    }
}