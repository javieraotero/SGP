
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
	public partial class VocesRN
	{
		VocesAD oVocesAD = new VocesAD();

		public Voces ObtenerPorId(int Id)
		{
			return this.oVocesAD.ObtenerPorId(Id);
		}

		public DbQuery<Voces> ObtenerTodo()
		{
			return this.oVocesAD.ObtenerTodo();
		}


		public DbQuery<VocesView> ObtenerParaGrilla()
		{
			return this.oVocesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oVocesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Voces Objeto)
		{
			try
			{
			this.oVocesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				//Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Voces Objeto)
		{
			try
			{
			this.oVocesAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				//Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oVocesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				//Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oVocesAD.Dispose();
		}
		public DbQuery<VocesViewT> JsonT(string term)
		{
			return (DbQuery<VocesViewT>)this.oVocesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
