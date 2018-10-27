using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShadowLabel
{   
	/// <summary>
	/// Summary description for ShadowLabel.
	/// </summary>
	[ToolboxItem(true)]
	public partial class ShadowLabel : Label
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private float _yShadowOffset = 1;
        private float _xShadowOffset = 1;
        private Color _shadowColour = Color.Black;
      
		private System.ComponentModel.Container components = null;

		public ShadowLabel(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
		}

		public ShadowLabel()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}

            base.Dispose(disposing);
		}

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(_shadowColour), _xShadowOffset, _yShadowOffset, StringFormat.GenericDefault);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 0, 0, StringFormat.GenericDefault);
        }

        [Category("Drop Shadow"), Description("The X Offset used to draw the shadow"), DefaultValue(1)]
        public float XOffset
        {
            get { return this._xShadowOffset; }
            set { this._xShadowOffset = value; this.Invalidate(); }
        }

        [Category("Drop Shadow"), Description("The Y Offset used to draw the shadow"), DefaultValue(1)]
        public float YOffset
        {
            get { return this._yShadowOffset; }
            set { this._yShadowOffset = value; this.Invalidate(); }
        }

        [Category("Drop Shadow"), Description("The colour used to draw the shadow"), DefaultValue(typeof(System.Drawing.Color), "Color.Black")]
        public Color ShadowColour
        {
            get { return this._shadowColour; }
            set { this._shadowColour = value; this.Invalidate(); }
        }

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            components = new System.ComponentModel.Container();         
            this.ForeColor = Color.White;
		}
		#endregion
	}
}
