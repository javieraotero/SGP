
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
	public partial class CoMediadoresInscripcionRN
	{
		CoMediadoresInscripcionAD oCoMediadoresInscripcionAD = new CoMediadoresInscripcionAD();

		public CoMediadoresInscripcion ObtenerPorId(int Id)
		{
			return this.oCoMediadoresInscripcionAD.ObtenerPorId(Id);
		}

		public DbQuery<CoMediadoresInscripcion> ObtenerTodo()
		{
			return this.oCoMediadoresInscripcionAD.ObtenerTodo();
		}


		public DbQuery<CoMediadoresInscripcionView> ObtenerParaGrilla()
		{
			return this.oCoMediadoresInscripcionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCoMediadoresInscripcionAD.ObtenerOptions(filtro);
		}

		public void Guardar(CoMediadoresInscripcion Objeto)
		{
			try
			{
			this.oCoMediadoresInscripcionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadoresInscripcion Objeto)
		{
			try
			{
			this.oCoMediadoresInscripcionAD.Actualizar(Objeto);
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
			this.oCoMediadoresInscripcionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCoMediadoresInscripcionAD.Dispose();
		}
		public DbQuery<CoMediadoresInscripcionViewT> JsonT(string term)
		{
			return (DbQuery<CoMediadoresInscripcionViewT>)this.oCoMediadoresInscripcionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
