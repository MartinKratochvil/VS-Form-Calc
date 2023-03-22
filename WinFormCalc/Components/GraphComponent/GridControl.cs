using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.GraphComponent;

public class GridControl : PictureBox
{

    public const int _size = 2500;
    
    private readonly Size parentSize;

    private Point startPoint;
        
    private Point stopPoint;

    private bool pressed;

    private readonly GridRender gridRender;

    private readonly LabelsRender labelsRender;

    public GraphControl GraphControl { get; }


    public GridControl(Size parentSize)
    {
        this.parentSize = parentSize;
        pressed = false;

        gridRender = new GridRender();
        labelsRender = new LabelsRender(parentSize);
        GraphControl = new GraphControl(parentSize);
    }


    public void Setup()
    {
        Size = new Size(_size, _size);
        Location = new Point(
            -1 * (_size / 2 - parentSize.Width / 2),
            -1 * (_size / 2 - parentSize.Height / 2)
        );
        Image = gridRender.Bitmap;

        GraphControl.Setup();

        Controls.Add(GraphControl.PictureBox);
            
        labelsRender.Setup(GraphControl.PictureBox);

        GraphControl.PictureBox.MouseDown += MouseDown;
        GraphControl.PictureBox.MouseUp += MouseUp;
        GraphControl.PictureBox.MouseMove += MouseMove;

        foreach (Control c in GraphControl.PictureBox.Controls) {
            if (! (c is Label)) {
                continue;
            }

            c.MouseDown += MouseDown;
            c.MouseUp += MouseUp;
            c.MouseMove += MouseMove;
        }
    }


    private new void MouseDown(object sender, MouseEventArgs e)
    {
        pressed = true;

        startPoint = PointToClient(Cursor.Position);
    }


    private new void MouseUp(object sender, MouseEventArgs e)
    {
        pressed = false;
    }


    private new void MouseMove(object sender, MouseEventArgs e)
    {
        if (! pressed) {
            return;
        }

        stopPoint = PointToClient(Cursor.Position);

        Location = Move();
        MoveLabels();

        startPoint = PointToClient(Cursor.Position);
    }


    private Point Move()
    {
        Point location = new Point(
            Location.X + (stopPoint.X - startPoint.X),
            Location.Y + (stopPoint.Y - startPoint.Y)
        );

        int minHorizontal = -1 * (_size - parentSize.Width);
        int minVertical = -1 * (_size - parentSize.Height);

        location.X = ValidateAxis(location.X, minHorizontal);
        location.Y = ValidateAxis(location.Y, minVertical);

        return location;
    }


    private void MoveLabels()
    {
        foreach (Control c in GraphControl.PictureBox.Controls) {
            if (
                (c.Location.X == _size / 2 - c.Width &&
                c.Location.Y == _size / 2) ||
                ! (c is Label)
            )
            {
                continue;
            }

            if (c.Location.Y == _size / 2) {
                if (
                    c.Location.X + Location.X + c.Width < 0 &&
                    startPoint.X - stopPoint.X > 0
                )
                {
                    c.Location = c.Location with {
                        X = c.Location.X + GridRender.Space * (GraphControl.PictureBox.Controls.Count - 1) / 2
                    };

                    SetLabelText((Label)c, Int32.Parse(c.Text) + 5);
                }

                if (
                    c.Location.X + Location.X > parentSize.Width &&
                    startPoint.X - stopPoint.X < 0
                )
                {
                    c.Location = c.Location with {
                        X = c.Location.X - GridRender.Space * (GraphControl.PictureBox.Controls.Count - 1) / 2
                    };

                    SetLabelText((Label)c, Int32.Parse(c.Text) - 5);
                }
            }

            if (c.Location.X == _size / 2 - c.Width) {
                if (
                    c.Location.Y + Location.Y + c.Height < 0 &&
                    startPoint.Y - stopPoint.Y > 0
                )
                {
                    c.Location = c.Location with {
                        Y = c.Location.Y + GridRender.Space * (GraphControl.PictureBox.Controls.Count - 1) / 2
                    };

                    SetLabelText((Label)c, Int32.Parse(c.Text) - 5);
                }

                if (
                    c.Location.Y + Location.Y > parentSize.Height &&
                    startPoint.Y - stopPoint.Y < 0
                )
                {
                    c.Location = c.Location with {
                        Y = c.Location.Y - GridRender.Space * (GraphControl.PictureBox.Controls.Count - 1) / 2
                    };

                    SetLabelText((Label)c, Int32.Parse(c.Text) + 5);
                }
            }
        }
    }


    private void SetLabelText(Label label, int value)
    {
        label.Text = value.ToString();

        if (value == 0) {
            label.Visible = false;
            return;
        }

        label.Visible = true;
    }


    private int ValidateAxis(int x, int border)
    {
        x = x > 0 ? 0 : x;
        x = x < border ? border : x;

        return x;
    }
}