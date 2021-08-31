
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
	public partial class CajaForenseRN
	{
		CajaForenseAD oCajaForenseAD = new CajaForenseAD();

		public CajaForense ObtenerPorId(int Id)
		{
			return this.oCajaForenseAD.ObtenerPorId(Id);
		}

		public DbQuery<CajaForense> ObtenerTodo()
		{
			return this.oCajaForenseAD.ObtenerTodo();
		}


		public DbQuery<CajaForenseView> ObtenerParaGrilla()
		{
			return this.oCajaForenseAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCajaForenseAD.ObtenerOptions(filtro);
		}

		public void Guardar(CajaForense Objeto)
		{
			try
			{
			this.oCajaForenseAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CajaForense Objeto)
		{
			try
			{
			this.oCajaForenseAD.Actualizar(Objeto);
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
			this.oCajaForenseAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCajaForenseAD.Dispose();
		}
		public DbQuery<CajaForenseViewT> JsonT(string term)
		{
			return (DbQuery<CajaForenseViewT>)this.oCajaForenseAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
