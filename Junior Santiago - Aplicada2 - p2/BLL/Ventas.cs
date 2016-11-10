using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Ventas : ClaseMaestra
    {
        public int VetaId { get; set; }
        public string Fecha { get; set; }
        public float Monto { get; set; }
        public List<VentasDetalle> Detalle { get; set; }
        public Ventas()
        {
            this.VetaId = 0;
            this.Fecha = "";
            this.Monto = 0;
            this.Detalle = new List<VentasDetalle>();
        }
        public override bool Actualizar()
        {
            bool Retornar = false;
            DbConexion cone = new DbConexion();
            try
            {
                Retornar = cone.Ejecutar(String.Format("Update Ventas set Fecha='{0}',Monto={1} where VentaId={2}",this.Fecha,this.Monto,this.VetaId));
              
                if (Retornar)
                {
                    cone.Ejecutar("Delete from VentasDetalle where VentaId ="+ this.VetaId);
                    foreach (VentasDetalle item in this.Detalle)
                    {
                        cone.Ejecutar(String.Format("Insert into VentasDetalle(VentaId,ArticuloId,Cantidad,Precio) Values({0},{1},{2},{3})",this.VetaId, item.ArticuloId, item.Cantidad, item.Precio));
                    }
                }


            }
            catch(Exception ex)
            {
                throw ex;
            }
          return  Retornar;
        }

        public override bool Buscar(int IdBuscar)
        {
            DbConexion cone = new DbConexion();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            bool Retornar = false;
            try
            {
                dt = cone.ObtenerDatos("Select * from Ventas where ventaId = "+IdBuscar);
                if(dt.Rows.Count>0)
                {
                    this.VetaId = (int)dt.Rows[0]["VentaId"];
                    this.Monto = Convert.ToSingle(dt.Rows[0]["Monto"]);
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();

                    dt2 = cone.ObtenerDatos(String.Format("Select * from VentasDetalle where VentaId = {0}", IdBuscar));
                    foreach(DataRow row in dt2.Rows)
                    {
                        AgregarArticulos((int)row["ArticuloId"], (int)row["Cantidad"], Convert.ToSingle(row["Precio"]));
                    }
                }
              return  dt.Rows.Count > 0;

            }catch(Exception)
            {
                
                Retornar = false;
            }
            return Retornar;
        }

        public override bool Eliminar()
        {
            bool Retornar = false;
            DbConexion cone = new DbConexion();
            try
            {
              Retornar= cone.Ejecutar(String.Format("Delete from VentasDetalle where VentaId = {0}; " + "Delete from Ventas where VentaId = {0}", this.VetaId));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Insertar()
        {
            int Retornar = 0;
            object Identity = null;
            DbConexion cone = new DbConexion();
           try
            {
                Identity = cone.ObtenerValor(String.Format("Insert into Ventas(Fecha,Monto) Values('{0}',{1}) SELECT @@Identity", this.Fecha, this.Monto));
                int.TryParse(Identity.ToString(), out Retornar);
                
                if(Retornar > 0)
                {
                    foreach(VentasDetalle item in this.Detalle)
                    {
                        cone.Ejecutar(String.Format("Insert into VentasDetalle(VentaId,ArticuloId,Cantidad,Precio) Values({0},{1},{2},{3})", Retornar, item.ArticuloId, item.Cantidad, item.Precio));
                    }
                }
             

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar > 0;
        }

        public override DataTable Listar(string Campo, string Condicion, string Orden)
        {
            DataTable dt = new DataTable();
            DbConexion cone = new DbConexion();
            string OrdenFinal = "";

            if (!Orden.Equals(""))
                OrdenFinal = "Order by " + Orden;

            return cone.ObtenerDatos(String.Format("Select " + Campo + " from Ventas as v inner join VentasDetalle d on v.ventasId = d.VentasId " + Condicion + " " + OrdenFinal));

        }
        public void AgregarArticulos(int ArticuloId, int Cantidad, float Precio)
        {
            this.Detalle.Add(new VentasDetalle(ArticuloId, Cantidad, Precio));
        }
    }
}
