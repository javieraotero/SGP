
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
	public partial class FeriadosRefRN
	{
		FeriadosRefAD oFeriadosRefAD = new FeriadosRefAD();

		public FeriadosRef ObtenerPorId(int Id)
		{
			return this.oFeriadosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<FeriadosRef> ObtenerTodo()
		{
			return this.oFeriadosRefAD.ObtenerTodo();
		}


		public DbQuery<FeriadosRefView> ObtenerParaGrilla()
		{
			return this.oFeriadosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFeriadosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(FeriadosRef Objeto)
		{
			try
			{
			this.oFeriadosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FeriadosRef Objeto)
		{
			try
			{
			this.oFeriadosRefAD.Actualizar(Objeto);
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
			this.oFeriadosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFeriadosRefAD.Dispose();
		}
		public DbQuery<FeriadosRefViewT> JsonT(string term)
		{
			return (DbQuery<FeriadosRefViewT>)this.oFeriadosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
