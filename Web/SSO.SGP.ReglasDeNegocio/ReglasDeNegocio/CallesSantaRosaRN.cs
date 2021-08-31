
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
	public partial class CallesSantaRosaRN
	{
		CallesSantaRosaAD oCallesSantaRosaAD = new CallesSantaRosaAD();

		public CallesSantaRosa ObtenerPorId(int Id)
		{
			return this.oCallesSantaRosaAD.ObtenerPorId(Id);
		}

		public DbQuery<CallesSantaRosa> ObtenerTodo()
		{
			return this.oCallesSantaRosaAD.ObtenerTodo();
		}


		public DbQuery<CallesSantaRosaView> ObtenerParaGrilla()
		{
			return this.oCallesSantaRosaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCallesSantaRosaAD.ObtenerOptions(filtro);
		}

		public void Guardar(CallesSantaRosa Objeto)
		{
			try
			{
			this.oCallesSantaRosaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CallesSantaRosa Objeto)
		{
			try
			{
			this.oCallesSantaRosaAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oCallesSantaRosaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCallesSantaRosaAD.Dispose();
		}
		public DbQuery<CallesSantaRosaViewT> JsonT(string term)
		{
			return (DbQuery<CallesSantaRosaViewT>)this.oCallesSantaRosaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
