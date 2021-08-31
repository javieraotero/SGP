
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
	public partial class SituacionesDeRevistaRN
	{
		SituacionesDeRevistaAD oSituacionesDeRevistaAD = new SituacionesDeRevistaAD();

		public SituacionesDeRevista ObtenerPorId(int Id)
		{
			return this.oSituacionesDeRevistaAD.ObtenerPorId(Id);
		}

		public DbQuery<SituacionesDeRevista> ObtenerTodo()
		{
			return this.oSituacionesDeRevistaAD.ObtenerTodo();
		}


		public DbQuery<SituacionesDeRevistaView> ObtenerParaGrilla()
		{
			return this.oSituacionesDeRevistaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSituacionesDeRevistaAD.ObtenerOptions(filtro);
		}

		public void Guardar(SituacionesDeRevista Objeto)
		{
			try
			{
			this.oSituacionesDeRevistaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SituacionesDeRevista Objeto)
		{
			try
			{
			this.oSituacionesDeRevistaAD.Actualizar(Objeto);
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
			this.oSituacionesDeRevistaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSituacionesDeRevistaAD.Dispose();
		}
		public DbQuery<SituacionesDeRevistaViewT> JsonT(string term)
		{
			return (DbQuery<SituacionesDeRevistaViewT>)this.oSituacionesDeRevistaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
