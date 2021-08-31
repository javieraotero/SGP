
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
	public partial class FuerosRefRN
	{
		FuerosRefAD oFuerosRefAD = new FuerosRefAD();

		public FuerosRef ObtenerPorId(int Id)
		{
			return this.oFuerosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<FuerosRef> ObtenerTodo()
		{
			return this.oFuerosRefAD.ObtenerTodo();
		}


		public DbQuery<FuerosRefView> ObtenerParaGrilla()
		{
			return this.oFuerosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFuerosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(FuerosRef Objeto)
		{
			try
			{
			this.oFuerosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FuerosRef Objeto)
		{
			try
			{
			this.oFuerosRefAD.Actualizar(Objeto);
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
			this.oFuerosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFuerosRefAD.Dispose();
		}
		public DbQuery<FuerosRefViewT> JsonT(string term)
		{
			return (DbQuery<FuerosRefViewT>)this.oFuerosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
