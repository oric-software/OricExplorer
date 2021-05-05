using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OricExplorer.User_Controls
{
    public partial class ctlProgressBar : UserControl
    {
        private StringAlignment infoHorizontalAlignment = StringAlignment.Center;

        private int percentageValue = 0;
        private Color percentageBarColour = Color.FromArgb(0, 255, 0);

        private String text = "";

        /// <summary>
        /// Gets or sets the value of the Percentage bar.
        /// </summary>
        [DefaultValue(typeof(int), "0"), Category("ProgressBar"), Description("Gets or sets the value of the Percentage bar.")]
        public int PercentageValue
        {
            get { return percentageValue; }
            set { percentageValue = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color for the percentage bar.
        /// </summary>
        [DefaultValue(typeof(Color), "Green"), Category("ProgressBar"), Description("Gets or sets the color for the percentage bar.")]
        public Color PercentageBarColour
        {
            get { return percentageBarColour; }
            set { percentageBarColour = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the controls text.
        /// </summary>
        [EditorAttribute("System.ComponentModel.Design.MultilineStringEditor, System.Design", "System.Drawing.Design.UITypeEditor")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text
        {
            get { return text; }
            set { text = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the horizontal alignment of the controls text.
        /// </summary>
        [DefaultValue(typeof(StringAlignment), "Center"), Category("ProgressBar"), Description("Gets or sets the horizontal alignment of the controls text.")]
        public StringAlignment TextHorizontalAlignment
        {
            get { return infoHorizontalAlignment; }
            set { infoHorizontalAlignment = value; Invalidate(); }
        }

        public ctlProgressBar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void ctlProgressBar_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(percentageBarColour);

            if (percentageValue < 0)
                percentageValue = 0;

            if (percentageValue > 100)
                percentageValue = 100;

            float barWidth = ((float)percentageValue / 100) * ClientRectangle.Width;

            e.Graphics.FillRectangle(b, 0, 0, barWidth, ClientRectangle.Height);

            if (text.Length > 0)
            {
                // Create a StringFormat object with the each line of text, and the block of text centered on the page.
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = infoHorizontalAlignment,
                    LineAlignment = StringAlignment.Center
                };

                // Draw the text and the surrounding rectangle.
                Rectangle textRectangle = ClientRectangle;
                textRectangle.Inflate(-3, -3);
                e.Graphics.DrawString(text, this.Font, new SolidBrush(this.ForeColor), textRectangle, stringFormat);
            }

            b.Dispose();
        }
    }
}
