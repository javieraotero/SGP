
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
	public partial class AudienciasRN
	{
		AudienciasAD oAudienciasAD = new AudienciasAD();

		public Audiencias ObtenerPorId(int Id)
		{
			return this.oAudienciasAD.ObtenerPorId(Id);
		}

		public DbQuery<Audiencias> ObtenerTodo()
		{
			return this.oAudienciasAD.ObtenerTodo();
		}


		public DbQuery<AudienciasView> ObtenerParaGrilla()
		{
			return this.oAudienciasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Audiencias Objeto)
		{
			try
			{
			this.oAudienciasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Audiencias Objeto)
		{
			try
			{
			this.oAudienciasAD.Actualizar(Objeto);
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
			this.oAudienciasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasAD.Dispose();
		}
		public DbQuery<AudienciasViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasViewT>)this.oAudienciasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
