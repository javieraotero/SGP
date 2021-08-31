
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
	public partial class TiposModelosEscritoadmRefRN
	{
		TiposModelosEscritoadmRefAD oTiposModelosEscritoadmRefAD = new TiposModelosEscritoadmRefAD();

		public TiposModelosEscritoadmRef ObtenerPorId(int Id)
		{
			return this.oTiposModelosEscritoadmRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposModelosEscritoadmRef> ObtenerTodo()
		{
			return this.oTiposModelosEscritoadmRefAD.ObtenerTodo();
		}


		public DbQuery<TiposModelosEscritoadmRefView> ObtenerParaGrilla()
		{
			return this.oTiposModelosEscritoadmRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposModelosEscritoadmRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposModelosEscritoadmRef Objeto)
		{
			try
			{
			this.oTiposModelosEscritoadmRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposModelosEscritoadmRef Objeto)
		{
			try
			{
			this.oTiposModelosEscritoadmRefAD.Actualizar(Objeto);
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
			this.oTiposModelosEscritoadmRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposModelosEscritoadmRefAD.Dispose();
		}
		public DbQuery<TiposModelosEscritoadmRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposModelosEscritoadmRefViewT>)this.oTiposModelosEscritoadmRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
