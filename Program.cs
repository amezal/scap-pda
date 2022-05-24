using System;
using Gtk;

namespace ScapProject0
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            //Window frm = new Empleados.FrmEmp();
            //Window frm = new Horarios.FrmAddHor();
            Window frm = new FrmAccesoPrincipal();
            frm.Show();
            Application.Run();
        }
    }
}
