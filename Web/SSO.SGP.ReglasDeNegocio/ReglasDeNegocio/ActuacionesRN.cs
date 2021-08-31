
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
	public partial class ActuacionesRN
	{
		ActuacionesAD oActuacionesAD = new ActuacionesAD();

		public Actuaciones ObtenerPorId(int Id)
		{
			return this.oActuacionesAD.ObtenerPorId(Id);
		}

		public DbQuery<Actuaciones> ObtenerTodo()
		{
			return this.oActuacionesAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesView> ObtenerParaGrilla()
		{
			return this.oActuacionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Actuaciones Objeto)
		{
			try
			{
			this.oActuacionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Actuaciones Objeto)
		{
			try
			{
			this.oActuacionesAD.Actualizar(Objeto);
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
			this.oActuacionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesAD.Dispose();
		}
		public DbQuery<ActuacionesViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesViewT>)this.oActuacionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
