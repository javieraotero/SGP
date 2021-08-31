
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
	public partial class GruposEstadoExpedienteRefRN
	{
		GruposEstadoExpedienteRefAD oGruposEstadoExpedienteRefAD = new GruposEstadoExpedienteRefAD();

		public GruposEstadoExpedienteRef ObtenerPorId(int Id)
		{
			return this.oGruposEstadoExpedienteRefAD.ObtenerPorId(Id);
		}

		public DbQuery<GruposEstadoExpedienteRef> ObtenerTodo()
		{
			return this.oGruposEstadoExpedienteRefAD.ObtenerTodo();
		}


		public DbQuery<GruposEstadoExpedienteRefView> ObtenerParaGrilla()
		{
			return this.oGruposEstadoExpedienteRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oGruposEstadoExpedienteRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(GruposEstadoExpedienteRef Objeto)
		{
			try
			{
			this.oGruposEstadoExpedienteRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposEstadoExpedienteRef Objeto)
		{
			try
			{
			this.oGruposEstadoExpedienteRefAD.Actualizar(Objeto);
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
			this.oGruposEstadoExpedienteRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oGruposEstadoExpedienteRefAD.Dispose();
		}
		public DbQuery<GruposEstadoExpedienteRefViewT> JsonT(string term)
		{
			return (DbQuery<GruposEstadoExpedienteRefViewT>)this.oGruposEstadoExpedienteRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
