
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
	public partial class CategoriasExpedienteadmRefRN
	{
		CategoriasExpedienteadmRefAD oCategoriasExpedienteadmRefAD = new CategoriasExpedienteadmRefAD();

		public CategoriasExpedienteadmRef ObtenerPorId(int Id)
		{
			return this.oCategoriasExpedienteadmRefAD.ObtenerPorId(Id);
		}

		public DbQuery<CategoriasExpedienteadmRef> ObtenerTodo()
		{
			return this.oCategoriasExpedienteadmRefAD.ObtenerTodo();
		}


		public DbQuery<CategoriasExpedienteadmRefView> ObtenerParaGrilla()
		{
			return this.oCategoriasExpedienteadmRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCategoriasExpedienteadmRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(CategoriasExpedienteadmRef Objeto)
		{
			try
			{
			this.oCategoriasExpedienteadmRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasExpedienteadmRef Objeto)
		{
			try
			{
			this.oCategoriasExpedienteadmRefAD.Actualizar(Objeto);
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
			this.oCategoriasExpedienteadmRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCategoriasExpedienteadmRefAD.Dispose();
		}
		public DbQuery<CategoriasExpedienteadmRefViewT> JsonT(string term)
		{
			return (DbQuery<CategoriasExpedienteadmRefViewT>)this.oCategoriasExpedienteadmRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
