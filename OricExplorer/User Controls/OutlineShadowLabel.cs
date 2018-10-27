namespace OutlineShadowLabel
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using TextDesignerCSLibrary;

    class OutlineShadowLabel : Label
    {
        private Boolean drawOutline;
        private Boolean drawShadow;
        private Boolean drawDiffusedShadow;
        private Boolean drawGradient;

        private Color outlineColor;
        private Color gradientEndColor;

        private SmoothingMode smoothingMode;

        private int outlineThickness;
        private int shadowThickness;

        private int shadowOffsetHorizontal;
        private int shadowOffsetVertical;

        public OutlineShadowLabel() : base()
        {
            drawOutline = true;
            drawShadow = true;
            drawDiffusedShadow = true;
            drawGradient = true;

            outlineColor = Color.Black;
            gradientEndColor = Color.WhiteSmoke;

            smoothingMode = SmoothingMode.AntiAlias;

            outlineThickness = 2;
            shadowThickness = 1;

            shadowOffsetHorizontal = 2;
            shadowOffsetVertical = 2;
        }

        [Category("Appearance")]
        [Description("Enable/Disable the diffused shadow")]
        [DefaultValue(typeof(Boolean), "True")]
        public Boolean ShadowDiffused
        {
            get { return drawDiffusedShadow; }
            set { drawDiffusedShadow = value; Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or Sets the text smoothing mode")]
        [DefaultValue(typeof(SmoothingMode), "AntiAlias")]
        public SmoothingMode SmoothingMode
        {
            get { return smoothingMode; }
            set { smoothingMode = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Enable/Disable the text outline")]
        [DefaultValue(typeof(Boolean), "True")]
        public Boolean Outline
        {
            get { return drawOutline; }
            set { drawOutline = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Enable/Disable the text shadow")]
        [DefaultValue(typeof(Boolean), "True")]
        public Boolean Shadow
        {
            get { return drawShadow; }
            set { drawShadow = value; Invalidate(); }
        }

        [Category("Appearance")]
        [Description("Enable/Disable the text gradient")]
        [DefaultValue(typeof(Boolean), "True")]
        public Boolean Gradient
        {
            get { return drawGradient; }

            set
            {
                drawGradient = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or Sets the outline color")]
        [DefaultValue(typeof(Color), "0x000000")]
        public Color OutlineColor
        {
            get { return outlineColor; }

            set
            {
                outlineColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or Sets the gradient end color")]
        [DefaultValue(typeof(Color), "0xC0C0C0")]
        public Color GradientEndColor
        {
            get { return gradientEndColor; }

            set
            {
                gradientEndColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or Sets the outline thickness")]
        [DefaultValue(typeof(int), "2")]
        public int OutlineThickness
        {
            get { return outlineThickness; }

            set
            {
                outlineThickness = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or Sets the shadow thickness")]
        [DefaultValue(typeof(int), "1")]
        public int ShadowThickness
        {
            get { return shadowThickness; }

            set
            {
                shadowThickness = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or Sets the shadow horizontal offset")]
        [DefaultValue(typeof(int), "2")]
        public int ShadowOffsetHorizontal
        {
            get { return shadowOffsetHorizontal; }

            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("ShadowHorizontalOffset", "Shadow horizontal offset must be between 0 and 10");
                }

                shadowOffsetHorizontal = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or Sets the shadow vertical offset")]
        [DefaultValue(typeof(int), "2")]
        public int ShadowOffsetVertical
        {
            get { return shadowOffsetVertical; }

            set
            {
                if(value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("ShadowVerticalOffset", "Shadow vertical offset must be between 0 and 10");
                }

                shadowOffsetVertical = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics labelGraphics = e.Graphics;

            labelGraphics.SmoothingMode = smoothingMode;
            labelGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            OutlineText m_OutlineText = new OutlineText();

            // Text colour, Outline colour, Thickness
            if (drawOutline)
            {
                m_OutlineText.TextOutline(ForeColor, outlineColor, outlineThickness);
            }
            else
            {
                m_OutlineText.TextNoOutline(ForeColor);
            }

            m_OutlineText.EnableShadow(drawShadow);
            m_OutlineText.SetNullShadow();

            if (m_OutlineText.IsShadowEnabled())
            {
                if (drawDiffusedShadow)
                {
                    m_OutlineText.DiffusedShadow(Color.FromArgb(150, 0, 0, 0), shadowThickness, new Point(shadowOffsetHorizontal, shadowOffsetVertical));
                }
                else
                {
                    m_OutlineText.Shadow(Color.FromArgb(150, 0, 0, 0), shadowThickness, new Point(shadowOffsetHorizontal, shadowOffsetVertical));
                }
            }

            if (drawGradient)
            {
                float fStartX = 0.0f;
                float fStartY = 0.0f;

                float fDestWidth = 0.0f;
                float fDestHeight = 0.0f;

                m_OutlineText.MeasureString(labelGraphics, Font.FontFamily, FontStyle.Regular, FontHeight, Text, new Point(0, 0), StringFormat.GenericTypographic, ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

                LinearGradientBrush gradientBrush = new LinearGradientBrush(new Rectangle(0, 0, (int)fDestWidth, (int)fDestHeight),
                                                                            ForeColor, gradientEndColor, LinearGradientMode.Vertical);

                if (drawOutline)
                {
                    m_OutlineText.TextOutline(gradientBrush, outlineColor, outlineThickness);
                }
                else
                {
                    m_OutlineText.TextNoOutline(gradientBrush);
                }
            }

            m_OutlineText.DrawString(labelGraphics, Font.FontFamily, FontStyle.Regular, FontHeight, Text, new Point(0, 0), StringFormat.GenericTypographic);
        }
    }
}