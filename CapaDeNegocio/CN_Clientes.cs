using CapaDeEntidades;
using CapaDeDatos;
using System.Collections.Generic;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Cliente
    {
        private CD_Clientes objCD = new CD_Clientes();

        public List<Cliente> Listar()
        {
            return objCD.Listar();
        }

        public int Registrar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                mensaje = "El documento es obligatorio";
                return 0;
            }
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                mensaje = "El nombre completo es obligatorio";
                return 0;
            }
            if (string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo es obligatorio";
                return 0;
            }

            return objCD.Registrar(obj, out mensaje);
        }

        public bool Editar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(obj.Documento))
            {
                mensaje = "El documento es obligatorio";
                return false;
            }
            if (string.IsNullOrWhiteSpace(obj.NombreCompleto))
            {
                mensaje = "El nombre completo es obligatorio";
                return false;
            }
            if (string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo es obligatorio";
                return false;
            }

            return objCD.Editar(obj, out mensaje);
        }

        public bool Eliminar(Cliente obj, out string mensaje)
        {
            return objCD.Eliminar(obj, out mensaje);
        }
        public Cliente ObtenerPorDocumento(string documento)
        {
            return objCD.ObtenerPorDocumento(documento);
        }
    }
}
