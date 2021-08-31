
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
	public partial class FeriasAgentesRN
	{
		FeriasAgentesAD oFeriasAgentesAD = new FeriasAgentesAD();

		public FeriasAgentes ObtenerPorId(int Id)
		{
			return this.oFeriasAgentesAD.ObtenerPorId(Id);
		}

		public DbQuery<FeriasAgentes> ObtenerTodo()
		{
			return this.oFeriasAgentesAD.ObtenerTodo();
		}


		public DbQuery<FeriasAgentesView> ObtenerParaGrilla()
		{
			return this.oFeriasAgentesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFeriasAgentesAD.ObtenerOptions(filtro);
		}

		public void Guardar(FeriasAgentes Objeto, int Dias, bool SinEfecto)
		{
			try
			{
			    this.oFeriasAgentesAD.Guardar(Objeto, Dias, SinEfecto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FeriasAgentes Objeto, int Dias, bool SinEfecto)
		{
			try
			{
			this.oFeriasAgentesAD.Actualizar(Objeto, Dias, SinEfecto);
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
			this.oFeriasAgentesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFeriasAgentesAD.Dispose();
		}
		public DbQuery<FeriasAgentesViewT> JsonT(string term)
		{
			return (DbQuery<FeriasAgentesViewT>)this.oFeriasAgentesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
