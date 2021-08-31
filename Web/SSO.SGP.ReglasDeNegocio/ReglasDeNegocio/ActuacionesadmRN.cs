
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
	public partial class ActuacionesadmRN
	{
		ActuacionesadmAD oActuacionesadmAD = new ActuacionesadmAD();

		public Actuacionesadm ObtenerPorId(int Id)
		{
			return this.oActuacionesadmAD.ObtenerPorId(Id);
		}

		public DbQuery<Actuacionesadm> ObtenerTodo()
		{
			return this.oActuacionesadmAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesadmView> ObtenerParaGrilla()
		{
			return this.oActuacionesadmAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesadmAD.ObtenerOptions(filtro);
		}

		public void Guardar(Actuacionesadm Objeto)
		{
			try
			{
			this.oActuacionesadmAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Actuacionesadm Objeto)
		{
			try
			{
			this.oActuacionesadmAD.Actualizar(Objeto);
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
			this.oActuacionesadmAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesadmAD.Dispose();
		}
		public DbQuery<ActuacionesadmViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesadmViewT>)this.oActuacionesadmAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
