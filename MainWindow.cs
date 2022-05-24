using System;
using Gtk;

public partial class MainWindow : Window
{
    public MainWindow() : base(WindowType.Toplevel)
    {
        this.Build();

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }


    protected void OnButton3Entered(object sender, EventArgs e)
    {
        Console.WriteLine("Hola");
        global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button3]));
        Random rand = new Random();
        int x = rand.Next(0, this.DefaultWidth - this.button3.WidthRequest);
        int y = rand.Next(0, this.DefaultHeight - this.button3.HeightRequest);
        w3.X = x;
        w3.Y = y;
        
    }
}
