
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
	public partial class ActuacionesPersonaDelitoRN
	{
		ActuacionesPersonaDelitoAD oActuacionesPersonaDelitoAD = new ActuacionesPersonaDelitoAD();

		public ActuacionesPersonaDelito ObtenerPorId(int Id)
		{
			return this.oActuacionesPersonaDelitoAD.ObtenerPorId(Id);
		}

		public DbQuery<ActuacionesPersonaDelito> ObtenerTodo()
		{
			return this.oActuacionesPersonaDelitoAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesPersonaDelitoView> ObtenerParaGrilla()
		{
			return this.oActuacionesPersonaDelitoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesPersonaDelitoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ActuacionesPersonaDelito Objeto)
		{
			try
			{
			this.oActuacionesPersonaDelitoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesPersonaDelito Objeto)
		{
			try
			{
			this.oActuacionesPersonaDelitoAD.Actualizar(Objeto);
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
			this.oActuacionesPersonaDelitoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesPersonaDelitoAD.Dispose();
		}
		public DbQuery<ActuacionesPersonaDelitoViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesPersonaDelitoViewT>)this.oActuacionesPersonaDelitoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
