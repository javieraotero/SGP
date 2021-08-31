
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
	public partial class LiquidacionAbogadosRN
	{
		LiquidacionAbogadosAD oLiquidacionAbogadosAD = new LiquidacionAbogadosAD();

		public LiquidacionAbogados ObtenerPorId(int Id)
		{
			return this.oLiquidacionAbogadosAD.ObtenerPorId(Id);
		}

		public DbQuery<LiquidacionAbogados> ObtenerTodo()
		{
			return this.oLiquidacionAbogadosAD.ObtenerTodo();
		}


		public DbQuery<LiquidacionAbogadosView> ObtenerParaGrilla()
		{
			return this.oLiquidacionAbogadosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLiquidacionAbogadosAD.ObtenerOptions(filtro);
		}

		public void Guardar(LiquidacionAbogados Objeto)
		{
			try
			{
			this.oLiquidacionAbogadosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionAbogados Objeto)
		{
			try
			{
			this.oLiquidacionAbogadosAD.Actualizar(Objeto);
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
			this.oLiquidacionAbogadosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLiquidacionAbogadosAD.Dispose();
		}
		public DbQuery<LiquidacionAbogadosViewT> JsonT(string term)
		{
			return (DbQuery<LiquidacionAbogadosViewT>)this.oLiquidacionAbogadosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
