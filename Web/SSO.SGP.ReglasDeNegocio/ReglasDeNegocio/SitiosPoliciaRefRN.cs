
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
	public partial class SitiosPoliciaRefRN
	{
		SitiosPoliciaRefAD oSitiosPoliciaRefAD = new SitiosPoliciaRefAD();

		public SitiosPoliciaRef ObtenerPorId(int Id)
		{
			return this.oSitiosPoliciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<SitiosPoliciaRef> ObtenerTodo()
		{
			return this.oSitiosPoliciaRefAD.ObtenerTodo();
		}


		public DbQuery<SitiosPoliciaRefView> ObtenerParaGrilla()
		{
			return this.oSitiosPoliciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSitiosPoliciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(SitiosPoliciaRef Objeto)
		{
			try
			{
			this.oSitiosPoliciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SitiosPoliciaRef Objeto)
		{
			try
			{
			this.oSitiosPoliciaRefAD.Actualizar(Objeto);
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
			this.oSitiosPoliciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSitiosPoliciaRefAD.Dispose();
		}
		public DbQuery<SitiosPoliciaRefViewT> JsonT(string term)
		{
			return (DbQuery<SitiosPoliciaRefViewT>)this.oSitiosPoliciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
