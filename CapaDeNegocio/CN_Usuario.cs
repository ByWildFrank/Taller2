using CapaDeDatos;
using CapaDeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Security.Claims;


namespace CapaDeNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "") { 
                Mensaje += "El nombre del usuario no puede estar vacio\n";
            }
            if (obj.Documento == "")
            {
                Mensaje += "El documento del usuario no puede estar vacio\n";
            }
            if (obj.oRol.IdRol == 0)
            {
                Mensaje += "Debe seleccionar un rol\n";
            }
            if(obj.Correo == "")
            {
                Mensaje += "El correo del usuario no puede estar vacio\n";
            }
            if(obj.Clave == "")
            {
                Mensaje += "La clave del usuario no puede estar vacia\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            return objcd_usuario.Registrar(obj, out Mensaje);
        }
        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre del usuario no puede estar vacio\n";
            }
            if (obj.Documento == "")
            {
                Mensaje += "El documento del usuario no puede estar vacio\n";
            }
            if (obj.oRol.IdRol == 0)
            {
                Mensaje += "Debe seleccionar un rol\n";
            }
            if (obj.Correo == "")
            {
                Mensaje += "El correo del usuario no puede estar vacio\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "La clave del usuario no puede estar vacia\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            return objcd_usuario.Editar(obj, out Mensaje);
        }
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }
    }
}
