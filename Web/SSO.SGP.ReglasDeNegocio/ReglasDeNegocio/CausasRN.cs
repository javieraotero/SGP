
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
	public partial class CausasRN
	{
		CausasAD oCausasAD = new CausasAD();

		public Causas ObtenerPorId(int Id)
		{
			return this.oCausasAD.ObtenerPorId(Id);
		}

		public DbQuery<Causas> ObtenerTodo()
		{
			return this.oCausasAD.ObtenerTodo();
		}


		public DbQuery<CausasView> ObtenerParaGrilla()
		{
			return this.oCausasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCausasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Causas Objeto)
		{
			try
			{
			this.oCausasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Causas Objeto)
		{
			try
			{
			this.oCausasAD.Actualizar(Objeto);
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
			this.oCausasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCausasAD.Dispose();
		}
		public DbQuery<CausasViewT> JsonT(string term)
		{
			return (DbQuery<CausasViewT>)this.oCausasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
