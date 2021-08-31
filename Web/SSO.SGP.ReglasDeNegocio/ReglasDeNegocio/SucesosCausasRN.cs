
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
	public partial class SucesosCausasRN
	{
		SucesosCausasAD oSucesosCausasAD = new SucesosCausasAD();

		public SucesosCausas ObtenerPorId(int Id)
		{
			return this.oSucesosCausasAD.ObtenerPorId(Id);
		}

		public DbQuery<SucesosCausas> ObtenerTodo()
		{
			return this.oSucesosCausasAD.ObtenerTodo();
		}


		public DbQuery<SucesosCausasView> ObtenerParaGrilla()
		{
			return this.oSucesosCausasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSucesosCausasAD.ObtenerOptions(filtro);
		}

		public void Guardar(SucesosCausas Objeto)
		{
			try
			{
			this.oSucesosCausasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SucesosCausas Objeto)
		{
			try
			{
			this.oSucesosCausasAD.Actualizar(Objeto);
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
			this.oSucesosCausasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSucesosCausasAD.Dispose();
		}
		public DbQuery<SucesosCausasViewT> JsonT(string term)
		{
			return (DbQuery<SucesosCausasViewT>)this.oSucesosCausasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
