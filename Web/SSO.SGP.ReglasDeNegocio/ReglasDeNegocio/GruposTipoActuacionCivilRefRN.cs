
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
	public partial class GruposTipoActuacionCivilRefRN
	{
		GruposTipoActuacionCivilRefAD oGruposTipoActuacionCivilRefAD = new GruposTipoActuacionCivilRefAD();

		public GruposTipoActuacionCivilRef ObtenerPorId(int Id)
		{
			return this.oGruposTipoActuacionCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<GruposTipoActuacionCivilRef> ObtenerTodo()
		{
			return this.oGruposTipoActuacionCivilRefAD.ObtenerTodo();
		}


		public DbQuery<GruposTipoActuacionCivilRefView> ObtenerParaGrilla()
		{
			return this.oGruposTipoActuacionCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oGruposTipoActuacionCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(GruposTipoActuacionCivilRef Objeto)
		{
			try
			{
			this.oGruposTipoActuacionCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposTipoActuacionCivilRef Objeto)
		{
			try
			{
			this.oGruposTipoActuacionCivilRefAD.Actualizar(Objeto);
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
			this.oGruposTipoActuacionCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oGruposTipoActuacionCivilRefAD.Dispose();
		}
		public DbQuery<GruposTipoActuacionCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<GruposTipoActuacionCivilRefViewT>)this.oGruposTipoActuacionCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
