
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
	public partial class CausasAccesosRN
	{
		CausasAccesosAD oCausasAccesosAD = new CausasAccesosAD();

		public CausasAccesos ObtenerPorId(int Id)
		{
			return this.oCausasAccesosAD.ObtenerPorId(Id);
		}

		public DbQuery<CausasAccesos> ObtenerTodo()
		{
			return this.oCausasAccesosAD.ObtenerTodo();
		}


		public DbQuery<CausasAccesosView> ObtenerParaGrilla()
		{
			return this.oCausasAccesosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCausasAccesosAD.ObtenerOptions(filtro);
		}

		public void Guardar(CausasAccesos Objeto)
		{
			try
			{
			this.oCausasAccesosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasAccesos Objeto)
		{
			try
			{
			this.oCausasAccesosAD.Actualizar(Objeto);
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
			this.oCausasAccesosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCausasAccesosAD.Dispose();
		}
		public DbQuery<CausasAccesosViewT> JsonT(string term)
		{
			return (DbQuery<CausasAccesosViewT>)this.oCausasAccesosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
