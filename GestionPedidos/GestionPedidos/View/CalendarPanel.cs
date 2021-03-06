﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedidos.View
{
    class CalendarPanel : Panel
    {

        MonthCalendar calendar;
        MainWindow mw;
        public CalendarPanel(MainWindow mw)
        {
            this.mw = mw;
            calendar = new MonthCalendar()
            {
                Dock = DockStyle.Fill,
                Width = 300,
                ShowToday = true,
                MaxSelectionCount = 1,
                CalendarDimensions = new System.Drawing.Size(6, 3)
            };
            calendar.DateChanged += mcr_DateChanged;

            this.Controls.Add(calendar);
            this.Width = 165;
        }

        private void mcr_DateChanged(object sender, DateRangeEventArgs e)
        {
            mw.Actualizar(calendar.SelectionStart);
        }
    }
}
