
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class UsuariosCambiosClaveRN
	{
		UsuariosCambiosClaveAD oUsuariosCambiosClaveAD = new UsuariosCambiosClaveAD();

		public UsuariosCambiosClave ObtenerPorId(int Id)
		{
			return this.oUsuariosCambiosClaveAD.ObtenerPorId(Id);
		}

		public DbQuery<UsuariosCambiosClave> ObtenerTodo()
		{
			return this.oUsuariosCambiosClaveAD.ObtenerTodo();
		}


		public DbQuery<UsuariosCambiosClaveView> ObtenerParaGrilla()
		{
			return this.oUsuariosCambiosClaveAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oUsuariosCambiosClaveAD.ObtenerOptions(filtro);
		}

		public void Guardar(UsuariosCambiosClave Objeto)
		{
			try
			{
			this.oUsuariosCambiosClaveAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UsuariosCambiosClave Objeto)
		{
			try
			{
			this.oUsuariosCambiosClaveAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oUsuariosCambiosClaveAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oUsuariosCambiosClaveAD.Dispose();
		}
		public DbQuery<UsuariosCambiosClaveViewT> JsonT(string term)
		{
			return (DbQuery<UsuariosCambiosClaveViewT>)this.oUsuariosCambiosClaveAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
