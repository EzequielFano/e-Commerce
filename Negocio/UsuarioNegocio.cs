using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
		public bool loguear(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();
			

			try
			{
				datos.setearProcedura("loguearUsuario");
				datos.setearParametro("@Email", usuario.Email);
				datos.setearParametro("@Nombre", usuario.Name);
				datos.setearParametro("@Pass", usuario.Password);

				return true;

			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
	}
}
