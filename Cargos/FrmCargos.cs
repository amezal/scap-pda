using System;
using Gtk;
using ScapProject0.Datos;
namespace ScapProject0.Cargos
{
    public partial class FrmCargos : Gtk.Window
    {
        Dt_tbl_cargo dtcar = new Dt_tbl_cargo();
        private string query = "";
        private int CargoActual;
        MessageDialog ms = null;


        public FrmCargos() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
          
            this.llenarCargos();
            /*if (CargoActual == 0)
            {
                .IsVisible = false;
            }*/
        }



            protected void llenarCargos()
            {
                this.tvwCar.Model = dtcar.listarCargos();

                string[] titulos = { "ID", "Cargo", "Departamento", "Descripcion" };
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
            if (CargoActual == 0)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Seleccione un cargo");
                ms.Run();
                ms.Destroy();
            }
            else
            {
                Cargos.FrmModCargos frm = new Cargos.FrmModCargos(CargoActual);
                frm.Show();
                frm.Caller = this;
                this.Hide();
                Console.WriteLine(CargoActual);
            }
        }
        protected void OnTvwCarCursorChanged(object sender, EventArgs e)
        {

            tvwCar.GetCursor(out TreePath path, out TreeViewColumn treeviewColumn);
            var model = tvwCar.Model;
            model.GetIter(out TreeIter iter, path);
            int idCargo = Convert.ToInt32(model.GetValue(iter, 0).ToString());
            CargoActual = idCargo;


            //lblPruebaID.Text = idCargo.ToString();
            Console.WriteLine(idCargo);
        }

        private Gtk.Window caller;

        public Window Caller { get => caller; set => caller = value; }

        protected void OnBtnBackClicked(object sender, EventArgs e)
        {
            this.caller.Show();
            this.Hide();
        }

        protected void OnEliminarActionActivated(object sender, EventArgs e)
        {
            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
            ButtonsType.YesNo, "¿Desea eliminar este cargo?");

            int result = md.Run();
            if (result == -8)
            {
                if (dtcar.EliminarCargo(CargoActual))
                {
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Cargo eliminado");
                    ms.Run();
                    ms.Destroy();
                    this.llenarCargos();
                }
            }
            md.Destroy();
        }

        protected void OnBuscarActionActivated(object sender, EventArgs e)
        {
            this.tvwCar.Model = dtcar.buscarCargos(txtCargoNombre.Text.Trim());
        }

    }
}
