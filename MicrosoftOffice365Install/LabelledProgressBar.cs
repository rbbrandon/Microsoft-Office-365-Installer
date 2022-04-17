//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

  public class LabelledProgressBar : ProgressBar
  {
    public LabelledProgressBar()
    {
      this.SetStyle(ControlStyles.UserPaint, true);
      base.ForeColor = Color.LimeGreen;
      base.BackColor = Color.LightGreen;
    }

    private Font _Font = SystemFonts.DefaultFont;
    private string _Text = "";
    private bool _ShowPercent = true;

    [DefaultValue(typeof(System.Drawing.Color), "LimeGreen")]
    public override Color ForeColor
    {
      get { return base.ForeColor; }
      set { base.ForeColor = value; }
    }

    [DefaultValue(typeof(System.Drawing.Color), "LightGreen")]
    public override Color BackColor
    {
      get { return base.BackColor; }
      set { base.BackColor = value; }
    }

    [Category("Appearance")]
    [Description("The font of the progress text.")]
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override Font Font
    {
      get { return _Font; }
      set
      {
        if (value == null)
          ResetFont();
        else
          _Font = value;
        this.Invalidate();
      }
    }

    public override void ResetFont()
    {
      this.Font = SystemFonts.DefaultFont;
    }

    private bool ShouldSerializeFont()
    {
      return !this.Font.Equals(SystemFonts.DefaultFont);
    }

    [Category("Appearance")]
    [Description("The text of the progress text.")]
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
      get { return _Text; }
      set
      {
        if (value == null)
          ResetText();
        else
          _Text = value;
        //this.Invalidate();
        this.Refresh();
      }
    }

    public override void ResetText()
    {
      this.Text = "";
    }

    private bool ShouldSerializeText()
    {
      return !this.Text.Equals("");
    }

    [Category("Appearance")]
    [Description("Show the percentage on the control.")]
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool ShowPercent
    {
      get { return _ShowPercent; }
      set
      {
        _ShowPercent = value;
        this.Invalidate();
      }
    }

    public void ResetShowPercent()
    {
      this.ShowPercent = true;
    }

    private bool ShouldSerializeShowPercent()
    {
      return !this.ShowPercent.Equals(true);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      // None... Helps control the flicker.
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      const int inset = 1; // A single inset value to control the sizing of the inner rect.

      using (Image offscreenImage = new Bitmap(this.Width, this.Height))
      {
        using (Graphics offscreen = Graphics.FromImage(offscreenImage))
        {
          Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

          if (ProgressBarRenderer.IsSupported)
            ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);

          rect.Inflate(new Size(-inset, -inset)); // Deflate inner rect.
          rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));
          if (rect.Width == 0) rect.Width = 1; // Can't draw rec with width of 0.

          LinearGradientBrush brush = new LinearGradientBrush(rect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);
          offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height);

          e.Graphics.DrawImage(offscreenImage, 0, 0);
        }
      }

      int percent = (int)(((double)(this.Value - this.Minimum) / (double)(this.Maximum - this.Minimum)) * 100);

      using (Graphics gr = this.CreateGraphics())
      {
        string text = this.Text.ToString();
        string percentText = "";

        if (_ShowPercent)
        {
          if (gr.MeasureString(text + " (100%)", _Font).Width > this.Width)
          {
            while (gr.MeasureString(text + "... (100%)", _Font).Width > this.Width)
              text = text.Substring(0, text.Length - 1);

            text += "...";
          }

          percentText = text + " (" + percent.ToString() + "%)";
        }
        else
        {
          if (gr.MeasureString(text, _Font).Width > this.Width)
          {
            while (gr.MeasureString(text + "...", _Font).Width > this.Width)
              text = text.Substring(0, text.Length - 1);

            text += "...";
          }

          percentText = text;
        }

        gr.DrawString(percentText,
            _Font,
            Brushes.Black,
            new PointF(this.Width / 2 - (gr.MeasureString(percentText, _Font).Width / 2.0F),
            this.Height / 2 - (gr.MeasureString(percentText, _Font).Height / 2.0F)));
      }
    }
  }
