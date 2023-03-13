using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormCalc.Components
{
    public static class TableDataManager
    {

        public static void SetAsymmetricalRows(TableLayoutPanel panel, List<Control> rows)
        {
            panel.ColumnStyles.Clear();
            panel.RowStyles.Clear();

            panel.ColumnCount = 1;
            panel.RowCount = rows.Count;

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            int height = 0;
            rows.ForEach(row => height += row.Height);

            for (int i = 0; i < rows.Count; i++) {
                panel.RowStyles.Add(new RowStyle(
                    SizeType.Percent,
                    100f * rows[i].Height / height
                ));

                panel.Controls.Add(rows[i], 0, i);
            }
        }
        
        
        public static void SetAsymmetricalColumns(TableLayoutPanel panel, List<Control> columns)
        {
            panel.ColumnStyles.Clear();
            panel.RowStyles.Clear();

            panel.RowCount = 1;
            panel.ColumnCount = columns.Count;

            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            int width = 0;
            columns.ForEach(column => width += column.Width);

            for (int i = 0; i < columns.Count; i++) {
                panel.ColumnStyles.Add(new ColumnStyle(
                    SizeType.Percent,
                    100f * columns[i].Width / width
                ));

                panel.Controls.Add(columns[i], i, 0);
            }
        }


        public static void SetSymmetricalData(TableLayoutPanel panel, List<List<Control>> data)
        {
            panel.ColumnStyles.Clear();
            panel.RowStyles.Clear();

            panel.ColumnCount = data.Count;
            panel.RowCount = data[0].Count;

            for(int i = 0; i < panel.RowCount; i++) {
                panel.RowStyles.Add(new RowStyle(
                    SizeType.Percent,
                    100f / panel.RowCount
                ));
            }

            for (int i = 0; i < panel.ColumnCount; i++) {
                panel.ColumnStyles.Add(new ColumnStyle(
                    SizeType.Percent,
                    100f / panel.ColumnCount
                ));

                for (int j = 0; j < panel.RowCount; j++) {
                    panel.Controls.Add(data[i][j], i, j);
                }
            }
        }


        //--------------------------------------------
        //---------- for asymmetrical data -----------
        //--------------------------------------------
        private static int GetTotalWidth(List<List<Control>> data)
        {
            int totalWidth = 0;

            data.ForEach(columns => {
                int maxWidth = 0;

                columns.ForEach(column => {
                    if (column.Size.Width > maxWidth) {
                        maxWidth = column.Size.Width;
                    }
                });

                totalWidth += maxWidth;
            });

            return totalWidth;
        }


        private static int GetTotalHeight(List<List<Control>> data)
        {
            int totalHeight = 0;

            for (int i = 0; i < data[0].Count; i++) {
                int maxHeight = 0;

                for (int j = 0; j < data.Count; j++) {
                    if (data[j][i].Size.Height > maxHeight) {
                        maxHeight = data[j][i].Size.Height;
                    }
                }

                totalHeight += maxHeight;
            }

            return totalHeight;
        }
    }
}
