using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Validacion
    {
        public bool[] validacionesfrmAlta(string nombre, string descripcion, string url, int indexTipo)
        {
            bool[] validar = new bool[4];
            if (validarStr(nombre))
                validar[0] = true;

            if (validarStr(descripcion))
                validar[1] = true;

            if (validarStr(url))
                validar[2] = true;

            if (validarCbo(indexTipo))
                validar[3] = true;
            return validar;
        }

        public bool validarStr(string obj)
        {
            if (obj.Length > 0)
                return true;
            return false;

        }

        public bool validarCbo(int index)
        {
            if (index > 0)
                return true;
            return false;
        }
    }
}
