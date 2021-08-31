
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
	public partial class CausasResponsableRN
	{
		CausasResponsableAD oCausasResponsableAD = new CausasResponsableAD();

		public CausasResponsable ObtenerPorId(int Id)
		{
			return this.oCausasResponsableAD.ObtenerPorId(Id);
		}

		public DbQuery<CausasResponsable> ObtenerTodo()
		{
			return this.oCausasResponsableAD.ObtenerTodo();
		}


		public DbQuery<CausasResponsableView> ObtenerParaGrilla()
		{
			return this.oCausasResponsableAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCausasResponsableAD.ObtenerOptions(filtro);
		}

		public void Guardar(CausasResponsable Objeto)
		{
			try
			{
			this.oCausasResponsableAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasResponsable Objeto)
		{
			try
			{
			this.oCausasResponsableAD.Actualizar(Objeto);
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
			this.oCausasResponsableAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCausasResponsableAD.Dispose();
		}
		public DbQuery<CausasResponsableViewT> JsonT(string term)
		{
			return (DbQuery<CausasResponsableViewT>)this.oCausasResponsableAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
