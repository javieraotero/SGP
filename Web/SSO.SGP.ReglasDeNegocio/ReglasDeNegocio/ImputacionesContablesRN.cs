
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
	public partial class ImputacionesContablesRN
	{
		ImputacionesContablesAD oImputacionesContablesAD = new ImputacionesContablesAD();

		public ImputacionesContables ObtenerPorId(int Id)
		{
			return this.oImputacionesContablesAD.ObtenerPorId(Id);
		}

		public DbQuery<ImputacionesContables> ObtenerTodo()
		{
			return this.oImputacionesContablesAD.ObtenerTodo();
		}


		public DbQuery<ImputacionesContablesView> ObtenerParaGrilla()
		{
			return this.oImputacionesContablesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oImputacionesContablesAD.ObtenerOptions(filtro);
		}

		public void Guardar(ImputacionesContables Objeto)
		{
			try
			{
			this.oImputacionesContablesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ImputacionesContables Objeto)
		{
			try
			{
			this.oImputacionesContablesAD.Actualizar(Objeto);
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
			this.oImputacionesContablesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oImputacionesContablesAD.Dispose();
		}
		public DbQuery<ImputacionesContablesViewT> JsonT(string term)
		{
			return (DbQuery<ImputacionesContablesViewT>)this.oImputacionesContablesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
