
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
	public partial class AuditoriaRN
	{
		AuditoriaAD oAuditoriaAD = new AuditoriaAD();

		public Auditoria ObtenerPorId(int Id)
		{
			return this.oAuditoriaAD.ObtenerPorId(Id);
		}

		public DbQuery<Auditoria> ObtenerTodo()
		{
			return this.oAuditoriaAD.ObtenerTodo();
		}


		public DbQuery<AuditoriaView> ObtenerParaGrilla()
		{
			return this.oAuditoriaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAuditoriaAD.ObtenerOptions(filtro);
		}

		public void Guardar(Auditoria Objeto)
		{
			try
			{
			this.oAuditoriaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Auditoria Objeto)
		{
			try
			{
			this.oAuditoriaAD.Actualizar(Objeto);
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
			this.oAuditoriaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAuditoriaAD.Dispose();
		}
		public DbQuery<AuditoriaViewT> JsonT(string term)
		{
			return (DbQuery<AuditoriaViewT>)this.oAuditoriaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
