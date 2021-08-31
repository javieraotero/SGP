
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
	public partial class GruposUsuarioRefRN
	{
		GruposUsuarioRefAD oGruposUsuarioRefAD = new GruposUsuarioRefAD();

		public GruposUsuarioRef ObtenerPorId(int Id)
		{
			return this.oGruposUsuarioRefAD.ObtenerPorId(Id);
		}

		public DbQuery<GruposUsuarioRef> ObtenerTodo()
		{
			return this.oGruposUsuarioRefAD.ObtenerTodo();
		}


		public DbQuery<GruposUsuarioRefView> ObtenerParaGrilla()
		{
			return this.oGruposUsuarioRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oGruposUsuarioRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(GruposUsuarioRef Objeto)
		{
			try
			{
			this.oGruposUsuarioRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposUsuarioRef Objeto)
		{
			try
			{
			this.oGruposUsuarioRefAD.Actualizar(Objeto);
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
			this.oGruposUsuarioRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oGruposUsuarioRefAD.Dispose();
		}
		public DbQuery<GruposUsuarioRefViewT> JsonT(string term)
		{
			return (DbQuery<GruposUsuarioRefViewT>)this.oGruposUsuarioRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
