using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace GradientPanel
{
    public partial class GradientPanel : System.Windows.Forms.Panel  
    {

        System.Drawing.Color m_startColor = Color.White;
        System.Drawing.Color m_endColor = Color.White;

        Boolean m_drawInnerBorder = true;

        System.Drawing.Drawing2D.LinearGradientMode m_gradientMode = LinearGradientMode.Horizontal;

        /// <summary>
        /// Gets or sets the starting color for the panels gradient.
        /// </summary>
        [DefaultValue(typeof(Color), "White"), Category("Panel"), Description("Gets or sets the starting color for the panels gradient.")]
        public Color PanelStartColor
        {
            get { return m_startColor; }
            set { m_startColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the ending color for the panels gradient.
        /// </summary>
        [DefaultValue(typeof(Color), "White"), Category("Panel"), Description("Gets or sets the ending color for the panels gradient.")]
        public Color PanelEndColor
        {
            get { return m_endColor; }
            set { m_endColor = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the direction in which the gradient is displayed.
        /// </summary>
        [DefaultValue(typeof(LinearGradientMode), "Horizontal"), Category("Panel"), Description("Gets or sets the direction in which the gradient is displayed.")]
        public LinearGradientMode GradientMode
        {
            get { return m_gradientMode; }
            set { m_gradientMode = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the visibility of the inner border.
        /// </summary>
        [DefaultValue(true), Category("Panel"), Description("Gets or sets the visibility of the inner border.")]
        public bool DrawInnerShadow
        {
            get { return m_drawInnerBorder; }
            set { m_drawInnerBorder = value; Invalidate(); }
        }

        public GradientPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
		{
			using (System.Drawing.Drawing2D.LinearGradientBrush filler =
				new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, PanelStartColor, PanelEndColor, GradientMode))
			{
				e.Graphics.FillRectangle(filler, ClientRectangle);
			}
		}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (m_drawInnerBorder)
            {
                // Draw inner border
                Rectangle innerRect = ClientRectangle;
                innerRect.X += 1;
                innerRect.Y += 1;

                innerRect.Width -= 3;
                innerRect.Height -= 3;

                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), innerRect);
            }
        }
    }
}
