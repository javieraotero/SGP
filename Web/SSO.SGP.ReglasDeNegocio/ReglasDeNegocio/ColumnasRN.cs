
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
	public partial class ColumnasRN
	{
		ColumnasAD oColumnasAD = new ColumnasAD();

		public Columnas ObtenerPorId(int Id)
		{
			return this.oColumnasAD.ObtenerPorId(Id);
		}

		public DbQuery<Columnas> ObtenerTodo()
		{
			return this.oColumnasAD.ObtenerTodo();
		}


		public DbQuery<ColumnasView> ObtenerParaGrilla()
		{
			return this.oColumnasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oColumnasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Columnas Objeto)
		{
			try
			{
			this.oColumnasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Columnas Objeto)
		{
			try
			{
			this.oColumnasAD.Actualizar(Objeto);
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
			this.oColumnasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oColumnasAD.Dispose();
		}
		public DbQuery<ColumnasViewT> JsonT(string term)
		{
			return (DbQuery<ColumnasViewT>)this.oColumnasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
