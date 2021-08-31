
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
	public partial class CategoriasDeImagenesRefRN
	{
		CategoriasDeImagenesRefAD oCategoriasDeImagenesRefAD = new CategoriasDeImagenesRefAD();

		public CategoriasDeImagenesRef ObtenerPorId(int Id)
		{
			return this.oCategoriasDeImagenesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<CategoriasDeImagenesRef> ObtenerTodo()
		{
			return this.oCategoriasDeImagenesRefAD.ObtenerTodo();
		}


		public DbQuery<CategoriasDeImagenesRefView> ObtenerParaGrilla()
		{
			return this.oCategoriasDeImagenesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCategoriasDeImagenesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(CategoriasDeImagenesRef Objeto)
		{
			try
			{
			this.oCategoriasDeImagenesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasDeImagenesRef Objeto)
		{
			try
			{
			this.oCategoriasDeImagenesRefAD.Actualizar(Objeto);
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
			this.oCategoriasDeImagenesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCategoriasDeImagenesRefAD.Dispose();
		}
		public DbQuery<CategoriasDeImagenesRefViewT> JsonT(string term)
		{
			return (DbQuery<CategoriasDeImagenesRefViewT>)this.oCategoriasDeImagenesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
