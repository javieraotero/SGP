
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
	public partial class FormulariosModulosRelRN
	{
		FormulariosModulosRelAD oFormulariosModulosRelAD = new FormulariosModulosRelAD();

		public FormulariosModulosRel ObtenerPorId(int Id)
		{
			return this.oFormulariosModulosRelAD.ObtenerPorId(Id);
		}

		public DbQuery<FormulariosModulosRel> ObtenerTodo()
		{
			return this.oFormulariosModulosRelAD.ObtenerTodo();
		}


		public DbQuery<FormulariosModulosRelView> ObtenerParaGrilla()
		{
			return this.oFormulariosModulosRelAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFormulariosModulosRelAD.ObtenerOptions(filtro);
		}

		public void Guardar(FormulariosModulosRel Objeto)
		{
			try
			{
			this.oFormulariosModulosRelAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FormulariosModulosRel Objeto)
		{
			try
			{
			this.oFormulariosModulosRelAD.Actualizar(Objeto);
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
			this.oFormulariosModulosRelAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFormulariosModulosRelAD.Dispose();
		}
		public DbQuery<FormulariosModulosRelViewT> JsonT(string term)
		{
			return (DbQuery<FormulariosModulosRelViewT>)this.oFormulariosModulosRelAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
