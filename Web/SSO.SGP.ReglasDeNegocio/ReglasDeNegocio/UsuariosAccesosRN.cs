
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
	public partial class UsuariosAccesosRN
	{
		UsuariosAccesosAD oUsuariosAccesosAD = new UsuariosAccesosAD();

		public UsuariosAccesos ObtenerPorId(int Id)
		{
			return this.oUsuariosAccesosAD.ObtenerPorId(Id);
		}

		public DbQuery<UsuariosAccesos> ObtenerTodo()
		{
			return this.oUsuariosAccesosAD.ObtenerTodo();
		}


		public DbQuery<UsuariosAccesosView> ObtenerParaGrilla()
		{
			return this.oUsuariosAccesosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oUsuariosAccesosAD.ObtenerOptions(filtro);
		}

		public void Guardar(UsuariosAccesos Objeto)
		{
			try
			{
			this.oUsuariosAccesosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UsuariosAccesos Objeto)
		{
			try
			{
			this.oUsuariosAccesosAD.Actualizar(Objeto);
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
			this.oUsuariosAccesosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oUsuariosAccesosAD.Dispose();
		}
		public DbQuery<UsuariosAccesosViewT> JsonT(string term)
		{
			return (DbQuery<UsuariosAccesosViewT>)this.oUsuariosAccesosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
