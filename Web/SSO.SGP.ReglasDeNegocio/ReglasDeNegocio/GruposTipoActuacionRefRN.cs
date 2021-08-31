
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
	public partial class GruposTipoActuacionRefRN
	{
		GruposTipoActuacionRefAD oGruposTipoActuacionRefAD = new GruposTipoActuacionRefAD();

		public GruposTipoActuacionRef ObtenerPorId(int Id)
		{
			return this.oGruposTipoActuacionRefAD.ObtenerPorId(Id);
		}

		public DbQuery<GruposTipoActuacionRef> ObtenerTodo()
		{
			return this.oGruposTipoActuacionRefAD.ObtenerTodo();
		}


		public DbQuery<GruposTipoActuacionRefView> ObtenerParaGrilla()
		{
			return this.oGruposTipoActuacionRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oGruposTipoActuacionRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(GruposTipoActuacionRef Objeto)
		{
			try
			{
			this.oGruposTipoActuacionRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposTipoActuacionRef Objeto)
		{
			try
			{
			this.oGruposTipoActuacionRefAD.Actualizar(Objeto);
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
			this.oGruposTipoActuacionRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oGruposTipoActuacionRefAD.Dispose();
		}
		public DbQuery<GruposTipoActuacionRefViewT> JsonT(string term)
		{
			return (DbQuery<GruposTipoActuacionRefViewT>)this.oGruposTipoActuacionRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
