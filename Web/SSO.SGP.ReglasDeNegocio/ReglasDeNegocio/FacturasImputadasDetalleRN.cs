
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
	public partial class FacturasImputadasDetalleRN
	{
		FacturasImputadasDetalleAD oFacturasImputadasDetalleAD = new FacturasImputadasDetalleAD();

		public FacturasImputadasDetalle ObtenerPorId(int Id)
		{
			return this.oFacturasImputadasDetalleAD.ObtenerPorId(Id);
		}

		public DbQuery<FacturasImputadasDetalle> ObtenerTodo()
		{
			return this.oFacturasImputadasDetalleAD.ObtenerTodo();
		}


		public DbQuery<FacturasImputadasDetalleView> ObtenerParaGrilla()
		{
			return this.oFacturasImputadasDetalleAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFacturasImputadasDetalleAD.ObtenerOptions(filtro);
		}

		public void Guardar(FacturasImputadasDetalle Objeto)
		{
			try
			{
			this.oFacturasImputadasDetalleAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FacturasImputadasDetalle Objeto)
		{
			try
			{
			this.oFacturasImputadasDetalleAD.Actualizar(Objeto);
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
			this.oFacturasImputadasDetalleAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFacturasImputadasDetalleAD.Dispose();
		}
		public DbQuery<FacturasImputadasDetalleViewT> JsonT(string term)
		{
			return (DbQuery<FacturasImputadasDetalleViewT>)this.oFacturasImputadasDetalleAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
