
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
	public partial class PermisosGruposUsuarioRelRN
	{
		PermisosGruposUsuarioRelAD oPermisosGruposUsuarioRelAD = new PermisosGruposUsuarioRelAD();

		public PermisosGruposUsuarioRel ObtenerPorId(int Id)
		{
			return this.oPermisosGruposUsuarioRelAD.ObtenerPorId(Id);
		}

		public DbQuery<PermisosGruposUsuarioRel> ObtenerTodo()
		{
			return this.oPermisosGruposUsuarioRelAD.ObtenerTodo();
		}


		public DbQuery<PermisosGruposUsuarioRelView> ObtenerParaGrilla()
		{
			return this.oPermisosGruposUsuarioRelAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPermisosGruposUsuarioRelAD.ObtenerOptions(filtro);
		}

		public void Guardar(PermisosGruposUsuarioRel Objeto)
		{
			try
			{
			this.oPermisosGruposUsuarioRelAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PermisosGruposUsuarioRel Objeto)
		{
			try
			{
			this.oPermisosGruposUsuarioRelAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oPermisosGruposUsuarioRelAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPermisosGruposUsuarioRelAD.Dispose();
		}
		public DbQuery<PermisosGruposUsuarioRelViewT> JsonT(string term)
		{
			return (DbQuery<PermisosGruposUsuarioRelViewT>)this.oPermisosGruposUsuarioRelAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
