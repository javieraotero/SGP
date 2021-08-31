
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
	public partial class ExpedientesArchivoRN
	{
		ExpedientesArchivoAD oExpedientesArchivoAD = new ExpedientesArchivoAD();

		public ExpedientesArchivo ObtenerPorId(int Id)
		{
			return this.oExpedientesArchivoAD.ObtenerPorId(Id);
		}

		public DbQuery<ExpedientesArchivo> ObtenerTodo()
		{
			return this.oExpedientesArchivoAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesArchivoView> ObtenerParaGrilla()
		{
			return this.oExpedientesArchivoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesArchivoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ExpedientesArchivo Objeto)
		{
			try
			{
			this.oExpedientesArchivoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesArchivo Objeto)
		{
			try
			{
			this.oExpedientesArchivoAD.Actualizar(Objeto);
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
			this.oExpedientesArchivoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesArchivoAD.Dispose();
		}
		public DbQuery<ExpedientesArchivoViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesArchivoViewT>)this.oExpedientesArchivoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
