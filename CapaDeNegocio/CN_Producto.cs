using CapaDeEntidades;
using System.Collections.Generic;
using CapaDeDatos;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCD_Producto = new CD_Producto();

        // El método Listar ahora devuelve List<Producto>
        public List<Producto> Listar()
        {
            return objCD_Producto.Listar();
        }

        // Método unificado para Guardar (decide si registrar o editar)
        public bool Guardar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;
            // Validaciones
            if (string.IsNullOrEmpty(obj.Nombre)) mensaje = "El nombre es obligatorio.";
            else if (string.IsNullOrEmpty(obj.codigo)) mensaje = "El código es obligatorio.";
            // ... (más validaciones) ...

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

        // Método para Eliminar (Lógico)
        public bool Eliminar(int idProducto, out string mensaje)
        {
            return objCD_Producto.Eliminar(idProducto, out mensaje);
        }
    }
}