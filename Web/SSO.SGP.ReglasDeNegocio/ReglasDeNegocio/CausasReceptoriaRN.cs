
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
	public partial class CausasReceptoriaRN
	{
		CausasReceptoriaAD oCausasReceptoriaAD = new CausasReceptoriaAD();

		public CausasReceptoria ObtenerPorId(int Id)
		{
			return this.oCausasReceptoriaAD.ObtenerPorId(Id);
		}

		public DbQuery<CausasReceptoria> ObtenerTodo()
		{
			return this.oCausasReceptoriaAD.ObtenerTodo();
		}


		public DbQuery<CausasReceptoriaView> ObtenerParaGrilla()
		{
			return this.oCausasReceptoriaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCausasReceptoriaAD.ObtenerOptions(filtro);
		}

		public void Guardar(CausasReceptoria Objeto)
		{
			try
			{
			this.oCausasReceptoriaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasReceptoria Objeto)
		{
			try
			{
			this.oCausasReceptoriaAD.Actualizar(Objeto);
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
			this.oCausasReceptoriaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCausasReceptoriaAD.Dispose();
		}
		public DbQuery<CausasReceptoriaViewT> JsonT(string term)
		{
			return (DbQuery<CausasReceptoriaViewT>)this.oCausasReceptoriaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
