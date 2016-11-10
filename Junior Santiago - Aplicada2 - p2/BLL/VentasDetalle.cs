using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VentasDetalle
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

       public VentasDetalle(int VentaId,int ArticuloId, int Cantidad, float Precio)
        {
            this.VentaId = VentaId;
            this.ArticuloId = ArticuloId;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }
    }
}
