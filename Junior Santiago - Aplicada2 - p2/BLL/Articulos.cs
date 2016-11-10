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
        public int Cantidad { get; set; }
        public List<Articulos> Lista { get; set; }

        public Articulos()
        {
            this.ArticuloId = 0;
            this.Descripcion = "";
            this.Existencia = 0;
            this.Precio = 0;
            this.Lista = new List<Articulos>();
        }
        public Articulos(int articuloId,int existencia,int Cantidad)
        {
            this.ArticuloId = articuloId;
            this.Existencia = existencia;
            this.Cantidad = Cantidad;
  
        }
        public void ObtenerDatosArticulo(int Articulo)
        {
            
            DbConexion cone = new DbConexion();
            DataTable dt = new DataTable();

            try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Articulos where ArticuloId ={0}", Articulo));
                if(dt.Rows.Count > 0)
                {
                    this.ArticuloId = (int)dt.Rows[0]["ArticuloId"];
                    this.Precio =Convert.ToSingle(dt.Rows[0]["Precio"]);
                    this.Existencia = (int)dt.Rows[0]["Existencia"];
                   
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
        public bool AfectarExistencia()
        {
            DbConexion cone = new DbConexion();
            bool Retornar = false;
            try
            {
                foreach(Articulos ar in this.Lista)
                {
                  Retornar = cone.Ejecutar(String.Format("Update Articulos set Existencia={0} where ArticuloId = {1}",ar.Existencia-ar.Cantidad, ar.ArticuloId));
                }
               
            }
            catch (Exception)
            {

            }
            return Retornar;
        }
        public void AgregarExistencia(int articuloId,int restarExi,int cantidad)
        {
            this.Lista.Add(new Articulos(articuloId,Existencia,cantidad));
        }
        public void ObtenerDatosArticuloTex(string Articulo)
        {

            DbConexion cone = new DbConexion();
            DataTable dt = new DataTable();

            try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Articulos where Descripcion ='{0}'", Articulo));
                if (dt.Rows.Count > 0)
                {
                    this.ArticuloId = (int)dt.Rows[0]["ArticuloId"];
                    this.Precio = Convert.ToSingle(dt.Rows[0]["Precio"]);
                    this.Existencia = (int)dt.Rows[0]["Existencia"];
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
