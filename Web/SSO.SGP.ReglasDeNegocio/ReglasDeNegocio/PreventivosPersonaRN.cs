
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
	public partial class PreventivosPersonaRN
	{
		PreventivosPersonaAD oPreventivosPersonaAD = new PreventivosPersonaAD();

		public PreventivosPersona ObtenerPorId(int Id)
		{
			return this.oPreventivosPersonaAD.ObtenerPorId(Id);
		}

		public DbQuery<PreventivosPersona> ObtenerTodo()
		{
			return this.oPreventivosPersonaAD.ObtenerTodo();
		}


		public DbQuery<PreventivosPersonaView> ObtenerParaGrilla()
		{
			return this.oPreventivosPersonaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPreventivosPersonaAD.ObtenerOptions(filtro);
		}

		public void Guardar(PreventivosPersona Objeto)
		{
			try
			{
			this.oPreventivosPersonaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PreventivosPersona Objeto)
		{
			try
			{
			this.oPreventivosPersonaAD.Actualizar(Objeto);
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
			this.oPreventivosPersonaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPreventivosPersonaAD.Dispose();
		}
		public DbQuery<PreventivosPersonaViewT> JsonT(string term)
		{
			return (DbQuery<PreventivosPersonaViewT>)this.oPreventivosPersonaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
