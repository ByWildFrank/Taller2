using BeanDesktop.CapaDeDatos;
using BeanDesktop.CapaDeEntidades;
using CapaDeDatos;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Permiso
    {

        private CD_PERMISO objcd_permiso = new CD_PERMISO();

        public List<Permiso> Listar(int idUsuario)
        {
            return objcd_permiso.Listar(idUsuario);
        }
    }
}
