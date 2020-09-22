using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Tipo(int id, string desc)
        {
            Id = id;
            Descripcion = desc;
        }
        public Tipo() {  }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
