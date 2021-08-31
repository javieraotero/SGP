
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
	public partial class CategoriasRefRN
	{
		CategoriasRefAD oCategoriasRefAD = new CategoriasRefAD();

		public CategoriasRef ObtenerPorId(int Id)
		{
			return this.oCategoriasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<CategoriasRef> ObtenerTodo()
		{
			return this.oCategoriasRefAD.ObtenerTodo();
		}


		public DbQuery<CategoriasRefView> ObtenerParaGrilla()
		{
			return this.oCategoriasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCategoriasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(CategoriasRef Objeto)
		{
			try
			{
			this.oCategoriasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasRef Objeto)
		{
			try
			{
			this.oCategoriasRefAD.Actualizar(Objeto);
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
			this.oCategoriasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCategoriasRefAD.Dispose();
		}
		public DbQuery<CategoriasRefViewT> JsonT(string term)
		{
			return (DbQuery<CategoriasRefViewT>)this.oCategoriasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
