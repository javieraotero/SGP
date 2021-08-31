
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
	public partial class ActuacionesCivilRN
	{
		ActuacionesCivilAD oActuacionesCivilAD = new ActuacionesCivilAD();

		public ActuacionesCivil ObtenerPorId(int Id)
		{
			return this.oActuacionesCivilAD.ObtenerPorId(Id);
		}

		public DbQuery<ActuacionesCivil> ObtenerTodo()
		{
			return this.oActuacionesCivilAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesCivilView> ObtenerParaGrilla()
		{
			return this.oActuacionesCivilAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesCivilAD.ObtenerOptions(filtro);
		}

		public void Guardar(ActuacionesCivil Objeto)
		{
			try
			{
			this.oActuacionesCivilAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesCivil Objeto)
		{
			try
			{
			this.oActuacionesCivilAD.Actualizar(Objeto);
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
			this.oActuacionesCivilAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesCivilAD.Dispose();
		}
		public DbQuery<ActuacionesCivilViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesCivilViewT>)this.oActuacionesCivilAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
