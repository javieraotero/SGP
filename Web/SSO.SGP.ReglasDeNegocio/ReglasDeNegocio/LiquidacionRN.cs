
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
	public partial class LiquidacionRN
	{
		LiquidacionAD oLiquidacionAD = new LiquidacionAD();

		public Liquidacion ObtenerPorId(int Id)
		{
			return this.oLiquidacionAD.ObtenerPorId(Id);
		}

		public DbQuery<Liquidacion> ObtenerTodo()
		{
			return this.oLiquidacionAD.ObtenerTodo();
		}


		public DbQuery<LiquidacionView> ObtenerParaGrilla()
		{
			return this.oLiquidacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLiquidacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(Liquidacion Objeto)
		{
			try
			{
			this.oLiquidacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Liquidacion Objeto)
		{
			try
			{
			this.oLiquidacionAD.Actualizar(Objeto);
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
			this.oLiquidacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLiquidacionAD.Dispose();
		}
		public DbQuery<LiquidacionViewT> JsonT(string term)
		{
			return (DbQuery<LiquidacionViewT>)this.oLiquidacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
