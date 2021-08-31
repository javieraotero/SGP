
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
	public partial class OrdenesCapturaRN
	{
		OrdenesCapturaAD oOrdenesCapturaAD = new OrdenesCapturaAD();

		public OrdenesCaptura ObtenerPorId(int Id)
		{
			return this.oOrdenesCapturaAD.ObtenerPorId(Id);
		}

		public DbQuery<OrdenesCaptura> ObtenerTodo()
		{
			return this.oOrdenesCapturaAD.ObtenerTodo();
		}


		public DbQuery<OrdenesCapturaView> ObtenerParaGrilla()
		{
			return this.oOrdenesCapturaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oOrdenesCapturaAD.ObtenerOptions(filtro);
		}

		public void Guardar(OrdenesCaptura Objeto)
		{
			try
			{
			this.oOrdenesCapturaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrdenesCaptura Objeto)
		{
			try
			{
			this.oOrdenesCapturaAD.Actualizar(Objeto);
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
			this.oOrdenesCapturaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oOrdenesCapturaAD.Dispose();
		}
		public DbQuery<OrdenesCapturaViewT> JsonT(string term)
		{
			return (DbQuery<OrdenesCapturaViewT>)this.oOrdenesCapturaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
