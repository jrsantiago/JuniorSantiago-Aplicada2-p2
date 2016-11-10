using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
   public class Articulos
    {
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public float Precio { get; set; }

        public Articulos()
        {
            this.ArticuloId = 0;
            this.Descripcion = "";
            this.Existencia = 0;
            this.Precio = 0;
        }
        public void ObtenerDatosArticulo(string Articulo)
        {
            
            DbConexion cone = new DbConexion();
            DataTable dt = new DataTable();

            try
            {
                dt = cone.ObtenerDatos(String.Format("Select ArticuloId from Articulos where Descripcion ='{0}'", this.Descripcion));
                if(dt.Rows.Count > 0)
                {
                    this.ArticuloId = (int)dt.Rows[0]["ArticuloId"];
                    this.Precio = Convert.ToSingle(dt.Rows[0]["Precio"]);
                }

            }catch(Exception ex)
            {
                throw ex;
            }
          
        }
        public  DataTable Listar(string Campo, string Condicion, string Orden)
        {
            DataTable dt = new DataTable();
            DbConexion cone = new DbConexion();
            string OrdenFinal = "";

            if (!Orden.Equals(""))
                OrdenFinal = "Order by " + Orden;

            return dt = cone.ObtenerDatos(String.Format("Select * from Articulos "));

        }
    }
}
