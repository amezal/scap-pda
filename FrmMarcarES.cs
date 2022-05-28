using System;
using Gtk;
using System.Timers;

namespace ScapProject0
{
    public partial class FrmMarcarES : Gtk.Window
    {
        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }
        public FrmMarcarES() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += tick;
            timer.Start();

            Pango.FontDescription txt = new Pango.FontDescription()
            {
                Stretch = Pango.Stretch.UltraExpanded,
                Size = Convert.ToInt32(40 * Pango.Scale.PangoScale),
                Family = "sans serif",
            };
            labelHora.ModifyFont(font_desc:txt);
            labelHora.Text = DateTime.Now.TimeOfDay.ToString();
        }

        private void tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.TimeOfDay.ToString();
        }

        protected void OnButton17Clicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

    }
}
