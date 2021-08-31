
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
	public partial class AudienciasImputadosRN
	{
		AudienciasImputadosAD oAudienciasImputadosAD = new AudienciasImputadosAD();

		public AudienciasImputados ObtenerPorId(int Id)
		{
			return this.oAudienciasImputadosAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasImputados> ObtenerTodo()
		{
			return this.oAudienciasImputadosAD.ObtenerTodo();
		}


		public DbQuery<AudienciasImputadosView> ObtenerParaGrilla()
		{
			return this.oAudienciasImputadosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasImputadosAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasImputados Objeto)
		{
			try
			{
			this.oAudienciasImputadosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasImputados Objeto)
		{
			try
			{
			this.oAudienciasImputadosAD.Actualizar(Objeto);
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
			this.oAudienciasImputadosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasImputadosAD.Dispose();
		}
		public DbQuery<AudienciasImputadosViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasImputadosViewT>)this.oAudienciasImputadosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
