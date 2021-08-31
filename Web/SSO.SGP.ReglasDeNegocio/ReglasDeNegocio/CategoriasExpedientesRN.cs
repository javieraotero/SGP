
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
	public partial class CategoriasExpedientesRN
	{
		CategoriasExpedientesAD oCategoriasExpedientesAD = new CategoriasExpedientesAD();

		public CategoriasExpedientes ObtenerPorId(int Id)
		{
			return this.oCategoriasExpedientesAD.ObtenerPorId(Id);
		}

		public DbQuery<CategoriasExpedientes> ObtenerTodo()
		{
			return this.oCategoriasExpedientesAD.ObtenerTodo();
		}


		public DbQuery<CategoriasExpedientesView> ObtenerParaGrilla()
		{
			return this.oCategoriasExpedientesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCategoriasExpedientesAD.ObtenerOptions(filtro);
		}

		public void Guardar(CategoriasExpedientes Objeto)
		{
			try
			{
			this.oCategoriasExpedientesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasExpedientes Objeto)
		{
			try
			{
			this.oCategoriasExpedientesAD.Actualizar(Objeto);
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
			this.oCategoriasExpedientesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCategoriasExpedientesAD.Dispose();
		}
		public DbQuery<CategoriasExpedientesViewT> JsonT(string term)
		{
			return (DbQuery<CategoriasExpedientesViewT>)this.oCategoriasExpedientesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
