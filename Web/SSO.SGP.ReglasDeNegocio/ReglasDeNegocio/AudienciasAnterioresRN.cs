
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
	public partial class AudienciasAnterioresRN
	{
		AudienciasAnterioresAD oAudienciasAnterioresAD = new AudienciasAnterioresAD();

		public AudienciasAnteriores ObtenerPorId(int Id)
		{
			return this.oAudienciasAnterioresAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasAnteriores> ObtenerTodo()
		{
			return this.oAudienciasAnterioresAD.ObtenerTodo();
		}


		public DbQuery<AudienciasAnterioresView> ObtenerParaGrilla()
		{
			return this.oAudienciasAnterioresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasAnterioresAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasAnteriores Objeto)
		{
			try
			{
			this.oAudienciasAnterioresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasAnteriores Objeto)
		{
			try
			{
			this.oAudienciasAnterioresAD.Actualizar(Objeto);
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
			this.oAudienciasAnterioresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasAnterioresAD.Dispose();
		}
		public DbQuery<AudienciasAnterioresViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasAnterioresViewT>)this.oAudienciasAnterioresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
