
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
	public partial class SucesosTitulosRN
	{
		SucesosTitulosAD oSucesosTitulosAD = new SucesosTitulosAD();

		public SucesosTitulos ObtenerPorId(int Id)
		{
			return this.oSucesosTitulosAD.ObtenerPorId(Id);
		}

		public DbQuery<SucesosTitulos> ObtenerTodo()
		{
			return this.oSucesosTitulosAD.ObtenerTodo();
		}


		public DbQuery<SucesosTitulosView> ObtenerParaGrilla()
		{
			return this.oSucesosTitulosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSucesosTitulosAD.ObtenerOptions(filtro);
		}

		public void Guardar(SucesosTitulos Objeto)
		{
			try
			{
			this.oSucesosTitulosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SucesosTitulos Objeto)
		{
			try
			{
			this.oSucesosTitulosAD.Actualizar(Objeto);
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
			this.oSucesosTitulosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSucesosTitulosAD.Dispose();
		}
		public DbQuery<SucesosTitulosViewT> JsonT(string term)
		{
			return (DbQuery<SucesosTitulosViewT>)this.oSucesosTitulosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
