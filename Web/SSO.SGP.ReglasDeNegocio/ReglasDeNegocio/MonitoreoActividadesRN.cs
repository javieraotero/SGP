
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
	public partial class MonitoreoActividadesRN
	{
		MonitoreoActividadesAD oMonitoreoActividadesAD = new MonitoreoActividadesAD();

		public MonitoreoActividades ObtenerPorId(int Id)
		{
			return this.oMonitoreoActividadesAD.ObtenerPorId(Id);
		}

		public DbQuery<MonitoreoActividades> ObtenerTodo()
		{
			return this.oMonitoreoActividadesAD.ObtenerTodo();
		}


		public DbQuery<MonitoreoActividadesView> ObtenerParaGrilla()
		{
			return this.oMonitoreoActividadesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMonitoreoActividadesAD.ObtenerOptions(filtro);
		}

		public void Guardar(MonitoreoActividades Objeto)
		{
			try
			{
			this.oMonitoreoActividadesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MonitoreoActividades Objeto)
		{
			try
			{
			this.oMonitoreoActividadesAD.Actualizar(Objeto);
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
			this.oMonitoreoActividadesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMonitoreoActividadesAD.Dispose();
		}
		public DbQuery<MonitoreoActividadesViewT> JsonT(string term)
		{
			return (DbQuery<MonitoreoActividadesViewT>)this.oMonitoreoActividadesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
