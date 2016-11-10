using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public abstract class ClaseMaestra
    {
        public abstract bool Insertar();
        public abstract bool Buscar(int IdBuscar);
        public abstract bool Eliminar();
        public abstract bool Actualizar();
        public abstract DataTable Listar(string Campo,string Condicion,string Orden);
    }
}
