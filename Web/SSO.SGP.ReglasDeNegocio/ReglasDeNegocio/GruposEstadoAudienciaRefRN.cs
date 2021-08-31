
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
	public partial class GruposEstadoAudienciaRefRN
	{
		GruposEstadoAudienciaRefAD oGruposEstadoAudienciaRefAD = new GruposEstadoAudienciaRefAD();

		public GruposEstadoAudienciaRef ObtenerPorId(int Id)
		{
			return this.oGruposEstadoAudienciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<GruposEstadoAudienciaRef> ObtenerTodo()
		{
			return this.oGruposEstadoAudienciaRefAD.ObtenerTodo();
		}


		public DbQuery<GruposEstadoAudienciaRefView> ObtenerParaGrilla()
		{
			return this.oGruposEstadoAudienciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oGruposEstadoAudienciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(GruposEstadoAudienciaRef Objeto)
		{
			try
			{
			this.oGruposEstadoAudienciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposEstadoAudienciaRef Objeto)
		{
			try
			{
			this.oGruposEstadoAudienciaRefAD.Actualizar(Objeto);
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
			this.oGruposEstadoAudienciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oGruposEstadoAudienciaRefAD.Dispose();
		}
		public DbQuery<GruposEstadoAudienciaRefViewT> JsonT(string term)
		{
			return (DbQuery<GruposEstadoAudienciaRefViewT>)this.oGruposEstadoAudienciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
