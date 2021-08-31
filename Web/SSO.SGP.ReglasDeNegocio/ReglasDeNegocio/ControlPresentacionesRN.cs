
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
	public partial class ControlPresentacionesRN
	{
		ControlPresentacionesAD oControlPresentacionesAD = new ControlPresentacionesAD();

		public ControlPresentaciones ObtenerPorId(int Id)
		{
			return this.oControlPresentacionesAD.ObtenerPorId(Id);
		}

		public DbQuery<ControlPresentaciones> ObtenerTodo()
		{
			return this.oControlPresentacionesAD.ObtenerTodo();
		}


		public DbQuery<ControlPresentacionesView> ObtenerParaGrilla()
		{
			return this.oControlPresentacionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oControlPresentacionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(ControlPresentaciones Objeto)
		{
			try
			{
			this.oControlPresentacionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ControlPresentaciones Objeto)
		{
			try
			{
			this.oControlPresentacionesAD.Actualizar(Objeto);
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
			this.oControlPresentacionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oControlPresentacionesAD.Dispose();
		}
		public DbQuery<ControlPresentacionesViewT> JsonT(string term)
		{
			return (DbQuery<ControlPresentacionesViewT>)this.oControlPresentacionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
