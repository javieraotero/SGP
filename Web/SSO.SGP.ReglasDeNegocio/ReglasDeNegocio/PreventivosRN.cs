
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
	public partial class PreventivosRN
	{
		PreventivosAD oPreventivosAD = new PreventivosAD();

		public Preventivos ObtenerPorId(int Id)
		{
			return this.oPreventivosAD.ObtenerPorId(Id);
		}

		public DbQuery<Preventivos> ObtenerTodo()
		{
			return this.oPreventivosAD.ObtenerTodo();
		}


		public DbQuery<PreventivosView> ObtenerParaGrilla()
		{
			return this.oPreventivosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPreventivosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Preventivos Objeto)
		{
			try
			{
			this.oPreventivosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Preventivos Objeto)
		{
			try
			{
			this.oPreventivosAD.Actualizar(Objeto);
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
			this.oPreventivosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPreventivosAD.Dispose();
		}
		public DbQuery<PreventivosViewT> JsonT(string term)
		{
			return (DbQuery<PreventivosViewT>)this.oPreventivosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
