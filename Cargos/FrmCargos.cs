using System;
using Gtk;
using ScapProject0.Datos;
namespace ScapProject0.Cargos
{
    public partial class FrmCargos : Gtk.Window
    {
       Dt_tbl_cargo dtcar = new Dt_tbl_cargo();
        private int CargoActual = 1;

        public FrmCargos() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
          
            this.llenarCargos();
        }
            protected void llenarCargos()
            {
                this.tvwCar.Model = dtcar.listarCargos();

            string[] titulos = { "ID", "Cargo", "Departamento" };
                for (int i = 0; i < titulos.Length; i++)
                {
                    this.tvwCar.AppendColumn(titulos[i], new CellRendererText(), "text", i);
                }
            }
           

        protected void OnAgregarActionActivated(object sender, EventArgs e)
        {
            Cargos.FrmAddCargos frm = new Cargos.FrmAddCargos();
            frm.Show();
            frm.Caller = this;
            this.Hide();
        }

        protected void OnModificarActionActivated(object sender, EventArgs e)
        {
            Cargos.FrmModCargos frm = new Cargos.FrmModCargos(CargoActual);
            frm.Show();
            frm.Caller = this;
            this.Hide();
            Console.WriteLine(CargoActual);
        }
        protected void OnTvwCarCursorChanged(object sender, EventArgs e)
        {

            tvwCar.GetCursor(out TreePath path, out TreeViewColumn treeviewColumn);
            var model = tvwCar.Model;
            model.GetIter(out TreeIter iter, path);
            int idCargo = Convert.ToInt32(model.GetValue(iter, 0).ToString());
            CargoActual = idCargo;

          Console.WriteLine(idCargo);
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }
    }
}
