
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
	public partial class SaldosDeLicenciasOrdinariasRN
	{
		SaldosDeLicenciasOrdinariasAD oSaldosDeLicenciasOrdinariasAD = new SaldosDeLicenciasOrdinariasAD();

		public SaldosDeLicenciasOrdinarias ObtenerPorId(int Id)
		{
			return this.oSaldosDeLicenciasOrdinariasAD.ObtenerPorId(Id);
		}

		public DbQuery<SaldosDeLicenciasOrdinarias> ObtenerTodo()
		{
			return this.oSaldosDeLicenciasOrdinariasAD.ObtenerTodo();
		}


		public DbQuery<SaldosDeLicenciasOrdinariasView> ObtenerParaGrilla()
		{
			return this.oSaldosDeLicenciasOrdinariasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSaldosDeLicenciasOrdinariasAD.ObtenerOptions(filtro);
		}

		public void Guardar(SaldosDeLicenciasOrdinarias Objeto)
		{
			try
			{
			this.oSaldosDeLicenciasOrdinariasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SaldosDeLicenciasOrdinarias Objeto)
		{
			try
			{
			this.oSaldosDeLicenciasOrdinariasAD.Actualizar(Objeto);
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
			this.oSaldosDeLicenciasOrdinariasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSaldosDeLicenciasOrdinariasAD.Dispose();
		}
		public DbQuery<SaldosDeLicenciasOrdinariasViewT> JsonT(string term)
		{
			return (DbQuery<SaldosDeLicenciasOrdinariasViewT>)this.oSaldosDeLicenciasOrdinariasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
