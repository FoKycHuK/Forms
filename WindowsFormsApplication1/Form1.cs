using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Form1 : Form
    {
        RadioButton firstRadioButton;
        int size;
        string text;
        ListBox popup;
        public Form1()
        {
            DoubleBuffered = true;
            size = 700;
            Size = new Size(size, size);
            firstRadioButton = new RadioButton()
            {
                Text = "strong",
                Left = size / 50,
                Top = size / 50
            };
            //firstRadioButton.CheckedChanged += (sender, eventArgs) => Invalidate();
            var secondRadioButton = new RadioButton()
            {
                Text = "simple",
                Left = size / 8,
                Top = size / 50
            };
            var button = new Button()
            {
                Text = "print",
                Left = size / 2,
                Top = size / 3
            };
            var textBox = new TextBox()
            {
                Text = "Enter text here",
                Left = size / 5,
                Top = size / 3
            };
            button.Click += (sender, e) => { text = textBox.Text; Invalidate(); };
            popup = new ListBox();
            popup.Items.AddRange(new string[] { "blue", "red" });
            popup.Dock = DockStyle.Bottom;
            //popup.SelectedIndexChanged += (sender, e) => Invalidate();
            this.Controls.Add(popup);
            this.Controls.Add(textBox);
            this.Controls.Add(button);
            this.Controls.Add(secondRadioButton);
            this.Controls.Add(firstRadioButton);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString(
                text, 
                new Font("Arial", firstRadioButton.Checked ? size / 25 : size / 50), 
                popup.SelectedItem == "red" ? Brushes.Red : Brushes.Blue, 
                new Point(
                    (int)(size / 2), 
                    (int)(size / 1.5)), 
                    new StringFormat() { 
                        Alignment = StringAlignment.Center, 
                        LineAlignment = StringAlignment.Center } );
        }
        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);
        //    size = Math.Min(Size.Height, Size.Width);
        //    Invalidate();
        //}
    }
}
