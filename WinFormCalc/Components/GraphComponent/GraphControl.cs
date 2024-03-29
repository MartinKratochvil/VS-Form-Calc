﻿using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.GraphComponent;

public class GraphControl
{

    private Size parentSize;

    public GraphRender GraphRender { get; }

    public PictureBox PictureBox { get; }


    public GraphControl(Size parentSize)
    {
        this.parentSize = parentSize;

        PictureBox = new PictureBox();
        GraphRender = new GraphRender();
    }

    public void Setup ()
    {
        PictureBox.Size = new Size(GridControl._size, GridControl._size);
        PictureBox.Location = new Point(0, 0);
        PictureBox.BackColor = Color.Transparent;
        PictureBox.Image = GraphRender.Bitmap;
    }

    public void Render(int a, int b, int c)
    {
        GraphRender.Render(a, b, c);
        PictureBox.Image = GraphRender.Bitmap;
    }
}