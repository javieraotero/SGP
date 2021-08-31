
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
	public partial class TurnosRN
	{
		TurnosAD oTurnosAD = new TurnosAD();

		public Turnos ObtenerPorId(int Id)
		{
			return this.oTurnosAD.ObtenerPorId(Id);
		}

		public DbQuery<Turnos> ObtenerTodo()
		{
			return this.oTurnosAD.ObtenerTodo();
		}


		public DbQuery<TurnosView> ObtenerParaGrilla()
		{
			return this.oTurnosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTurnosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Turnos Objeto)
		{
			try
			{
			this.oTurnosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Turnos Objeto)
		{
			try
			{
			this.oTurnosAD.Actualizar(Objeto);
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
			this.oTurnosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTurnosAD.Dispose();
		}
		public DbQuery<TurnosViewT> JsonT(string term)
		{
			return (DbQuery<TurnosViewT>)this.oTurnosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
