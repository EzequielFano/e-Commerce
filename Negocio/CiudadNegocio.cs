﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CiudadNegocio
    {
        public List<Ciudad> listarXIdDeProvincia(int IdProvincia)
        {
            List<Ciudad> ciudades = new List<Ciudad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedura("StoredListarCiudadesPorProvincia");
                datos.setearParametro("IdProvincia", IdProvincia);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.IdCiudad = datos.Lector.GetInt32(0);
                    ciudad.Nombre = (string)datos.Lector["Nombre"];
                    ciudades.Add(ciudad);
                }
                return ciudades;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public string listarCiudadXId(int Id)
        {
            string CiudadNombre = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedura("ObtenerNombreCiudad");
                datos.setearParametro("IdCiudad", Id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.Nombre = (string)datos.Lector["Nombre"];
                    CiudadNombre = ciudad.Nombre;
                    
                }
                return CiudadNombre;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
