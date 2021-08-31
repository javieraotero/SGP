
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
	public partial class ActuacionesProvisoriasRN
	{
		ActuacionesProvisoriasAD oActuacionesProvisoriasAD = new ActuacionesProvisoriasAD();

		public ActuacionesProvisorias ObtenerPorId(int Id)
		{
			return this.oActuacionesProvisoriasAD.ObtenerPorId(Id);
		}

		public DbQuery<ActuacionesProvisorias> ObtenerTodo()
		{
			return this.oActuacionesProvisoriasAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesProvisoriasView> ObtenerParaGrilla()
		{
			return this.oActuacionesProvisoriasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesProvisoriasAD.ObtenerOptions(filtro);
		}

		public void Guardar(ActuacionesProvisorias Objeto)
		{
			try
			{
			this.oActuacionesProvisoriasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesProvisorias Objeto)
		{
			try
			{
			this.oActuacionesProvisoriasAD.Actualizar(Objeto);
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
			this.oActuacionesProvisoriasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesProvisoriasAD.Dispose();
		}
		public DbQuery<ActuacionesProvisoriasViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesProvisoriasViewT>)this.oActuacionesProvisoriasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
