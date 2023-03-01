using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.GraphComponent
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

            int maxHoriz = parentSize.Width / GridRender.Space;
            int value = maxHoriz / -2;

            for (int i = 0; i <= maxHoriz; i++) {
                Label label = CreateLabel();

                label.Location = new Point(
                    label.Location.X + GridRender.Space * i - label.Width / 2,
                    label.Location.Y + parentSize.Height / 2
                );

                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = value.ToString();
                value++;

                if (i == parentSize.Width / GridRender.Space / 2) {
                    label.Visible = false;
                }

                pictureBox.Controls.Add(label);
            }

            int maxVert = parentSize.Height / GridRender.Space;
            value = maxVert / 2;

            for (int i = 0; i <= maxVert; i++) {
                Label label = CreateLabel();

                label.Location = new Point(
                    label.Location.X + parentSize.Width / 2 - label.Width,
                    label.Location.Y + GridRender.Space * i - label.Height / 2
                );

                label.TextAlign = ContentAlignment.MiddleRight;
                label.Text = value.ToString();
                value--;

                if (i == parentSize.Height / GridRender.Space / 2) {
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
