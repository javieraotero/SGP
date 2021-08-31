
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
	public partial class EventosRN
	{
		EventosAD oEventosAD = new EventosAD();

		public Eventos ObtenerPorId(int Id)
		{
			return this.oEventosAD.ObtenerPorId(Id);
		}

		public DbQuery<Eventos> ObtenerTodo()
		{
			return this.oEventosAD.ObtenerTodo();
		}


		public DbQuery<EventosView> ObtenerParaGrilla()
		{
			return this.oEventosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEventosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Eventos Objeto)
		{
			try
			{
			this.oEventosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Eventos Objeto)
		{
			try
			{
			this.oEventosAD.Actualizar(Objeto);
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
			this.oEventosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEventosAD.Dispose();
		}
		public DbQuery<EventosViewT> JsonT(string term)
		{
			return (DbQuery<EventosViewT>)this.oEventosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
