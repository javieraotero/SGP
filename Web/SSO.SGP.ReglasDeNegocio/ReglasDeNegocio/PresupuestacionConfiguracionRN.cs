
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
	public partial class PresupuestacionConfiguracionRN
	{
		PresupuestacionConfiguracionAD oPresupuestacionConfiguracionAD = new PresupuestacionConfiguracionAD();

		public PresupuestacionConfiguracion ObtenerPorId(int Id)
		{
			return this.oPresupuestacionConfiguracionAD.ObtenerPorId(Id);
		}

		public DbQuery<PresupuestacionConfiguracion> ObtenerTodo()
		{
			return this.oPresupuestacionConfiguracionAD.ObtenerTodo();
		}


		public DbQuery<PresupuestacionConfiguracionView> ObtenerParaGrilla()
		{
			return this.oPresupuestacionConfiguracionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPresupuestacionConfiguracionAD.ObtenerOptions(filtro);
		}

		public void Guardar(PresupuestacionConfiguracion Objeto)
		{
			try
			{
			this.oPresupuestacionConfiguracionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionConfiguracion Objeto)
		{
			try
			{
			this.oPresupuestacionConfiguracionAD.Actualizar(Objeto);
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
			this.oPresupuestacionConfiguracionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPresupuestacionConfiguracionAD.Dispose();
		}
		public DbQuery<PresupuestacionConfiguracionViewT> JsonT(string term)
		{
			return (DbQuery<PresupuestacionConfiguracionViewT>)this.oPresupuestacionConfiguracionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
