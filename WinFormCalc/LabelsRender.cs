using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc
{
    public class LabelsRender
    {
        PictureBox pictureBox;

        Size parentSize;


        public LabelsRender(Size parentSize)
        {
            this.parentSize = parentSize;
        }


        public void Render(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;

            int maxHoriz = parentSize.Width / GridRender._space;
            int value = maxHoriz / -2;

            for (int i = 0; i <= maxHoriz; i++)
            {
                Label label = CreateLabel();

                label.Location = new Point(
                    label.Location.X + GridRender._space * i - label.Width / 2,
                    label.Location.Y + parentSize.Height / 2
                );
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = value.ToString();
                value++;

                if (i == parentSize.Width / GridRender._space / 2)
                {
                    label.Visible = false;
                }

                pictureBox.Controls.Add(label);
            }

            int maxVert = parentSize.Height / GridRender._space;
            value = maxVert / 2;

            for (int i = 0; i <= maxVert; i++)
            {
                Label label = CreateLabel();

                label.Location = new Point(
                    label.Location.X + parentSize.Width / 2 - label.Width,
                    label.Location.Y + GridRender._space * i - label.Height / 2
                );
                label.TextAlign = ContentAlignment.MiddleRight;
                label.Text = value.ToString();
                value--;

                if (i == parentSize.Height / GridRender._space / 2)
                {
                    label.Visible = false;
                }

                pictureBox.Controls.Add(label);
            }

            Label labelNull = CreateLabel();
            labelNull.Location = new Point(
                labelNull.Location.X + parentSize.Width / 2 - labelNull.Size.Width,
                labelNull.Location.Y + parentSize.Height / 2
            );
            labelNull.TextAlign = ContentAlignment.MiddleRight;
            labelNull.Text = "0";

            pictureBox.Controls.Add(labelNull);
        }


        private Label CreateLabel() => new Label()
        {
            Location = new Point(
                pictureBox.Parent.Location.X * -1,
                pictureBox.Parent.Location.Y * -1
            ),
            Size = new Size(60, 20),
            AutoSize = false,
            Font = new Font("Microsoft YaHei", 10, FontStyle.Regular),
            BackColor = Color.Transparent,
        };
    }
}
