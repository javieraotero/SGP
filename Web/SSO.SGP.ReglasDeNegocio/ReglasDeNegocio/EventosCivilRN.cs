
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
	public partial class EventosCivilRN
	{
		EventosCivilAD oEventosCivilAD = new EventosCivilAD();

		public EventosCivil ObtenerPorId(int Id)
		{
			return this.oEventosCivilAD.ObtenerPorId(Id);
		}

		public DbQuery<EventosCivil> ObtenerTodo()
		{
			return this.oEventosCivilAD.ObtenerTodo();
		}


		public DbQuery<EventosCivilView> ObtenerParaGrilla()
		{
			return this.oEventosCivilAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEventosCivilAD.ObtenerOptions(filtro);
		}

		public void Guardar(EventosCivil Objeto)
		{
			try
			{
			this.oEventosCivilAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EventosCivil Objeto)
		{
			try
			{
			this.oEventosCivilAD.Actualizar(Objeto);
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
			this.oEventosCivilAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEventosCivilAD.Dispose();
		}
		public DbQuery<EventosCivilViewT> JsonT(string term)
		{
			return (DbQuery<EventosCivilViewT>)this.oEventosCivilAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
