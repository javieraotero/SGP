
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
	public partial class ActuacionesVocesRN
	{
		ActuacionesVocesAD oActuacionesVocesAD = new ActuacionesVocesAD();

		public ActuacionesVoces ObtenerPorId(int Id)
		{
			return this.oActuacionesVocesAD.ObtenerPorId(Id);
		}

		public DbQuery<ActuacionesVoces> ObtenerTodo()
		{
			return this.oActuacionesVocesAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesVocesView> ObtenerParaGrilla()
		{
			return this.oActuacionesVocesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesVocesAD.ObtenerOptions(filtro);
		}

		public void Guardar(ActuacionesVoces Objeto)
		{
			try
			{
			this.oActuacionesVocesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesVoces Objeto)
		{
			try
			{
			this.oActuacionesVocesAD.Actualizar(Objeto);
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
			this.oActuacionesVocesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesVocesAD.Dispose();
		}
		public DbQuery<ActuacionesVocesViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesVocesViewT>)this.oActuacionesVocesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
