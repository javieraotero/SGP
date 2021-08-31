
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
	public partial class SustitucionesRN
	{
		SustitucionesAD oSustitucionesAD = new SustitucionesAD();

		public Sustituciones ObtenerPorId(int Id)
		{
			return this.oSustitucionesAD.ObtenerPorId(Id);
		}

		public DbQuery<Sustituciones> ObtenerTodo()
		{
			return this.oSustitucionesAD.ObtenerTodo();
		}


		public DbQuery<SustitucionesView> ObtenerParaGrilla()
		{
			return this.oSustitucionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSustitucionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Sustituciones Objeto)
		{
			try
			{
			this.oSustitucionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Sustituciones Objeto)
		{
			try
			{
			this.oSustitucionesAD.Actualizar(Objeto);
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
			this.oSustitucionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSustitucionesAD.Dispose();
		}
		public DbQuery<SustitucionesViewT> JsonT(int agente, bool activos)
		{
            return (DbQuery<SustitucionesViewT>)this.oSustitucionesAD.JsonT(agente, activos);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
