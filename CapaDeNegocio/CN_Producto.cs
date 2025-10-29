using CapaDeEntidades;
using System.Collections.Generic;
using CapaDeDatos;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCD_Producto = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCD_Producto.Listar().Where(p => p.Estado == true).ToList();
        }

        public List<Producto> ListarTodos()
        {
            return objCD_Producto.Listar();
        }

        public bool Guardar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            if (string.IsNullOrWhiteSpace(obj.Nombre)) mensaje = "El nombre es obligatorio.";
            else if (string.IsNullOrWhiteSpace(obj.codigo)) mensaje = "El código es obligatorio.";

            if (!string.IsNullOrEmpty(mensaje)) return false;

            if (obj.IdProducto == 0)
            {
                int idGenerado = objCD_Producto.Registrar(obj, out mensaje);
                return idGenerado != 0;
            }
            else
            {
                return objCD_Producto.Editar(obj, out mensaje);
            }
        }

        public bool Eliminar(int idProducto, out string mensaje)
        {
            return objCD_Producto.Eliminar(idProducto, out mensaje);
        }

        public bool AnadirStock(int idProducto, int cantidad, int idUsuario, out string mensaje)
        {
            if (cantidad <= 0)
            {
                mensaje = "La cantidad a añadir debe ser mayor a cero.";
                return false;
            }
            return objCD_Producto.AnadirStock(idProducto, cantidad, idUsuario, out mensaje);
        }

    }
}