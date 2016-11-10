using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace Junior_Santiago___Aplicada2___p2
{
    public partial class Formulario : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if(!IsPostBack)
            {
                FecharTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                FilasGridView();
            }
            FilasGridView(); 
            Articulos ar = new Articulos();

            dt = ar.Listar("*", "0=0", "ORDER BY Descripcion");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                ArticulosDropDownList.Items.Add(Convert.ToString(ar.Listar("*", "0=0", "ORDER BY Descripcion").Rows[i]["Descripcion"]));

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Detalle"];
            DataRow row;
            Articulos ar = new Articulos();
            ar.ObtenerDatosArticulo(ArticulosDropDownList.Text);

            
                row = dt.NewRow();
                row["ArticuloId"] = ar.ArticuloId;
                row["Cantidad"] = CantidadTextBox0.Text;
                row["Precio"] = ar.Precio;

                dt.Rows.Add(row);
                ViewState["Detalle"] = dt;

                ObtenerGridView();
            
        }
        public void ObtenerDatos(Ventas ven)
        {
            ven.Fecha = FecharTextBox.Text;
            ven.Monto = Convert.ToSingle(TotalTextBox.Text);

            foreach(GridViewRow row in DetalleGridView.Rows)
            {
                ven.AgregarArticulos(Convert.ToInt32(BuscarTextBox.Text),Convert.ToInt32(row.Cells[0].Text), Convert.ToInt32(row.Cells[1].Text), Convert.ToSingle(row.Cells[2].Text));
            }
           
        }
        public void ObtenerGridView()
        {
            DetalleGridView.DataSource = (DataTable)ViewState["Detalle"];
            DetalleGridView.DataBind();
        }
        public void FilasGridView()
        {
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ArticuloId"), new DataColumn("Cantidad"), new DataColumn("Precio") });
            ViewState["Detalle"] = dt;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            CantidadTextBox0.Text = "";
            TotalTextBox.Text = "";
            BuscarTextBox.Text = "";
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ObtenerDatos(ven);
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                Utilitarios.ShowToastr(this, "LLenar Campo Id", "Mensaje", "danger");
            }
            else
            {

                if (ven.Insertar())
                {
                    Utilitarios.ShowToastr(this, "Guardado", "Mensaje", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error", "Mensaje", "danger");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            int id = 0;
            int.TryParse(BuscarTextBox.Text, out id);
            venta.VetaId = id;
            if(venta.Eliminar())
            {
                Utilitarios.ShowToastr(this, "Eliminado", "Mensaje", "danger");
            }
            
        }
    }
}