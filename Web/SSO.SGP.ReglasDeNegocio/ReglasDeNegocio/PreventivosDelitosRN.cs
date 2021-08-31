
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
	public partial class PreventivosDelitosRN
	{
		PreventivosDelitosAD oPreventivosDelitosAD = new PreventivosDelitosAD();

		public PreventivosDelitos ObtenerPorId(int Id)
		{
			return this.oPreventivosDelitosAD.ObtenerPorId(Id);
		}

		public DbQuery<PreventivosDelitos> ObtenerTodo()
		{
			return this.oPreventivosDelitosAD.ObtenerTodo();
		}


		public DbQuery<PreventivosDelitosView> ObtenerParaGrilla()
		{
			return this.oPreventivosDelitosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPreventivosDelitosAD.ObtenerOptions(filtro);
		}

		public void Guardar(PreventivosDelitos Objeto)
		{
			try
			{
			this.oPreventivosDelitosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PreventivosDelitos Objeto)
		{
			try
			{
			this.oPreventivosDelitosAD.Actualizar(Objeto);
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
			this.oPreventivosDelitosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPreventivosDelitosAD.Dispose();
		}
		public DbQuery<PreventivosDelitosViewT> JsonT(string term)
		{
			return (DbQuery<PreventivosDelitosViewT>)this.oPreventivosDelitosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
