
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
	public partial class FacturasRN
	{
		FacturasAD oFacturasAD = new FacturasAD();

		public Facturas ObtenerPorId(int Id)
		{
			return this.oFacturasAD.ObtenerPorId(Id);
		}

		public DbQuery<Facturas> ObtenerTodo()
		{
			return this.oFacturasAD.ObtenerTodo();
		}


		public DbQuery<FacturasDetalleView> ObtenerParaGrilla()
		{
			return this.oFacturasAD.ObtenerParaGrilla();
		}

        public DbQuery<FacturasView> FacturasSinExpediente()
        {
            return this.oFacturasAD.FacturasSinExpediente();
        }

        public DbQuery<FacturasView> FacturasDeExpediente(int expediente)
        {
            return this.oFacturasAD.FacturasDeExpediente(expediente);
        }

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFacturasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Facturas Objeto)
		{
			try
			{
			this.oFacturasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Facturas Objeto)
		{
			try
			{
			this.oFacturasAD.Actualizar(Objeto);
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
			this.oFacturasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFacturasAD.Dispose();
		}
		public DbQuery<FacturasViewT> JsonT(string term)
		{
			return (DbQuery<FacturasViewT>)this.oFacturasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
