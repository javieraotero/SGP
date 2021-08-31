
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
	public partial class CategoriasCausasRN
	{
		CategoriasCausasAD oCategoriasCausasAD = new CategoriasCausasAD();

		public CategoriasCausas ObtenerPorId(int Id)
		{
			return this.oCategoriasCausasAD.ObtenerPorId(Id);
		}

		public DbQuery<CategoriasCausas> ObtenerTodo()
		{
			return this.oCategoriasCausasAD.ObtenerTodo();
		}


		public DbQuery<CategoriasCausasView> ObtenerParaGrilla()
		{
			return this.oCategoriasCausasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCategoriasCausasAD.ObtenerOptions(filtro);
		}

		public void Guardar(CategoriasCausas Objeto)
		{
			try
			{
			this.oCategoriasCausasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasCausas Objeto)
		{
			try
			{
			this.oCategoriasCausasAD.Actualizar(Objeto);
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
			this.oCategoriasCausasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCategoriasCausasAD.Dispose();
		}
		public DbQuery<CategoriasCausasViewT> JsonT(string term)
		{
			return (DbQuery<CategoriasCausasViewT>)this.oCategoriasCausasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
