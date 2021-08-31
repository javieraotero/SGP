
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
	public partial class ExpedientesadmRN
	{
		ExpedientesadmAD oExpedientesadmAD = new ExpedientesadmAD();

		public Expedientesadm ObtenerPorId(int Id)
		{
			return this.oExpedientesadmAD.ObtenerPorId(Id);
		}

		public DbQuery<Expedientesadm> ObtenerTodo()
		{
			return this.oExpedientesadmAD.ObtenerTodo();
		}


		public DbQuery<ExpedientesadmView> ObtenerParaGrilla()
		{
			return this.oExpedientesadmAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExpedientesadmAD.ObtenerOptions(filtro);
		}

		public void Guardar(Expedientesadm Objeto)
		{
			try
			{
			this.oExpedientesadmAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Expedientesadm Objeto)
		{
			try
			{
			this.oExpedientesadmAD.Actualizar(Objeto);
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
			this.oExpedientesadmAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExpedientesadmAD.Dispose();
		}
		public DbQuery<ExpedientesadmViewT> JsonT(string term)
		{
			return (DbQuery<ExpedientesadmViewT>)this.oExpedientesadmAD.JsonT(term);
		}

		/*********************************************
		* Seccion Particular
		* *******************************************/
        public int proximoCorresponde(int expediente)
        {
            return this.oExpedientesadmAD.poroximoCorresponde(expediente);
        }

	}
}
