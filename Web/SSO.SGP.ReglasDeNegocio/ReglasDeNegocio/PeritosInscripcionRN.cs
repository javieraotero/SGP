
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
	public partial class PeritosInscripcionRN
	{
		PeritosInscripcionAD oPeritosInscripcionAD = new PeritosInscripcionAD();

		public PeritosInscripcion ObtenerPorId(int Id)
		{
			return this.oPeritosInscripcionAD.ObtenerPorId(Id);
		}

		public DbQuery<PeritosInscripcion> ObtenerTodo()
		{
			return this.oPeritosInscripcionAD.ObtenerTodo();
		}


		public DbQuery<PeritosInscripcionView> ObtenerParaGrilla()
		{
			return this.oPeritosInscripcionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosInscripcionAD.ObtenerOptions(filtro);
		}

		public void Guardar(PeritosInscripcion Objeto)
		{
			try
			{
			this.oPeritosInscripcionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosInscripcion Objeto)
		{
			try
			{
			this.oPeritosInscripcionAD.Actualizar(Objeto);
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
			this.oPeritosInscripcionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosInscripcionAD.Dispose();
		}
		public DbQuery<PeritosInscripcionViewT> JsonT(string term)
		{
			return (DbQuery<PeritosInscripcionViewT>)this.oPeritosInscripcionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
