
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
	public partial class CategoriasCausasCivilRN
	{
		CategoriasCausasCivilAD oCategoriasCausasCivilAD = new CategoriasCausasCivilAD();

		public CategoriasCausasCivil ObtenerPorId(int Id)
		{
			return this.oCategoriasCausasCivilAD.ObtenerPorId(Id);
		}

		public DbQuery<CategoriasCausasCivil> ObtenerTodo()
		{
			return this.oCategoriasCausasCivilAD.ObtenerTodo();
		}


		public DbQuery<CategoriasCausasCivilView> ObtenerParaGrilla()
		{
			return this.oCategoriasCausasCivilAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCategoriasCausasCivilAD.ObtenerOptions(filtro);
		}

		public void Guardar(CategoriasCausasCivil Objeto)
		{
			try
			{
			this.oCategoriasCausasCivilAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasCausasCivil Objeto)
		{
			try
			{
			this.oCategoriasCausasCivilAD.Actualizar(Objeto);
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
			this.oCategoriasCausasCivilAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCategoriasCausasCivilAD.Dispose();
		}
		public DbQuery<CategoriasCausasCivilViewT> JsonT(string term)
		{
			return (DbQuery<CategoriasCausasCivilViewT>)this.oCategoriasCausasCivilAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
