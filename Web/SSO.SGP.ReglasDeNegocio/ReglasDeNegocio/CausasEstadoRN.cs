
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
	public partial class CausasEstadoRN
	{
		CausasEstadoAD oCausasEstadoAD = new CausasEstadoAD();

		public CausasEstado ObtenerPorId(int Id)
		{
			return this.oCausasEstadoAD.ObtenerPorId(Id);
		}

		public DbQuery<CausasEstado> ObtenerTodo()
		{
			return this.oCausasEstadoAD.ObtenerTodo();
		}


		public DbQuery<CausasEstadoView> ObtenerParaGrilla()
		{
			return this.oCausasEstadoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCausasEstadoAD.ObtenerOptions(filtro);
		}

		public void Guardar(CausasEstado Objeto)
		{
			try
			{
			this.oCausasEstadoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasEstado Objeto)
		{
			try
			{
			this.oCausasEstadoAD.Actualizar(Objeto);
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
			this.oCausasEstadoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCausasEstadoAD.Dispose();
		}
		public DbQuery<CausasEstadoViewT> JsonT(string term)
		{
			return (DbQuery<CausasEstadoViewT>)this.oCausasEstadoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
