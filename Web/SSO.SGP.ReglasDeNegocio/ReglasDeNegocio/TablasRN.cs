
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
	public partial class TablasRN
	{
		TablasAD oTablasAD = new TablasAD();

		public Tablas ObtenerPorId(int Id)
		{
			return this.oTablasAD.ObtenerPorId(Id);
		}

		public DbQuery<Tablas> ObtenerTodo()
		{
			return this.oTablasAD.ObtenerTodo();
		}


		public DbQuery<TablasView> ObtenerParaGrilla()
		{
			return this.oTablasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTablasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Tablas Objeto)
		{
			try
			{
			this.oTablasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Tablas Objeto)
		{
			try
			{
			this.oTablasAD.Actualizar(Objeto);
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
			this.oTablasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTablasAD.Dispose();
		}
		public DbQuery<TablasViewT> JsonT(string term)
		{
			return (DbQuery<TablasViewT>)this.oTablasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
