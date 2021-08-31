
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
	public partial class PreventivosElementosRN
	{
		PreventivosElementosAD oPreventivosElementosAD = new PreventivosElementosAD();

		public PreventivosElementos ObtenerPorId(int Id)
		{
			return this.oPreventivosElementosAD.ObtenerPorId(Id);
		}

		public DbQuery<PreventivosElementos> ObtenerTodo()
		{
			return this.oPreventivosElementosAD.ObtenerTodo();
		}


		public DbQuery<PreventivosElementosView> ObtenerParaGrilla()
		{
			return this.oPreventivosElementosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPreventivosElementosAD.ObtenerOptions(filtro);
		}

		public void Guardar(PreventivosElementos Objeto)
		{
			try
			{
			this.oPreventivosElementosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PreventivosElementos Objeto)
		{
			try
			{
			this.oPreventivosElementosAD.Actualizar(Objeto);
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
			this.oPreventivosElementosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPreventivosElementosAD.Dispose();
		}
		public DbQuery<PreventivosElementosViewT> JsonT(string term)
		{
			return (DbQuery<PreventivosElementosViewT>)this.oPreventivosElementosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
