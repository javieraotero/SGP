
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
	public partial class ExcusacionesRN
	{
		ExcusacionesAD oExcusacionesAD = new ExcusacionesAD();

		public Excusaciones ObtenerPorId(int Id)
		{
			return this.oExcusacionesAD.ObtenerPorId(Id);
		}

		public DbQuery<Excusaciones> ObtenerTodo()
		{
			return this.oExcusacionesAD.ObtenerTodo();
		}


		public DbQuery<ExcusacionesView> ObtenerParaGrilla()
		{
			return this.oExcusacionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oExcusacionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Excusaciones Objeto)
		{
			try
			{
			this.oExcusacionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Excusaciones Objeto)
		{
			try
			{
			this.oExcusacionesAD.Actualizar(Objeto);
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
			this.oExcusacionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oExcusacionesAD.Dispose();
		}
		public DbQuery<ExcusacionesViewT> JsonT(string term)
		{
			return (DbQuery<ExcusacionesViewT>)this.oExcusacionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
