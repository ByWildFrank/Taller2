using CapaDeEntidades;
using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BeanDesktop.CapaDeNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objCD = new CD_Categoria(); // Clase de la capa de datos

        // Listar todas las categorías
        public List<Categoria> Listar()
        {
            return objCD.Listar();
        }

        // Obtener una categoría por Id
        public Categoria ObtenerPorId(int idCategoria)
        {
            return objCD.ObtenerPorId(idCategoria);
        }

        // Guardar o actualizar una categoría
        public string Guardar(Categoria oCategoria)
        {
            if (string.IsNullOrWhiteSpace(oCategoria.Descripcion))
                return "La descripción es obligatoria";

            if (oCategoria.IdCategoria == 0)
                return objCD.Insertar(oCategoria);
            else
                return objCD.Actualizar(oCategoria);
        }

        // Eliminar una categoría por Id
        public string Eliminar(int idCategoria)
        {
            return objCD.Eliminar(idCategoria);
        }
    }
}

