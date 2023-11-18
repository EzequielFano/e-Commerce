using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
		public bool Loguear(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			

			try
			{
				datos.setearProcedura("loguearUsuario");
				datos.setearParametro("@Email", usuario.Email);
				datos.setearParametro("@Nombre", usuario.Nombre);
				datos.setearParametro("@Pass", usuario.Password);
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					usuario.IdUsuario = (int)datos.Lector["IdUsuario"];					
					usuario.TipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
											
					return true;
				}
				return false;


			}
			catch (Exception ex)
			{

				throw ex;
			}

		}		
	}
}
