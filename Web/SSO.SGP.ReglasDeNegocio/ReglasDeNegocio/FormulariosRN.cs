
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
	public partial class FormulariosRN
	{
		FormulariosAD oFormulariosAD = new FormulariosAD();

		public Formularios ObtenerPorId(int Id)
		{
			return this.oFormulariosAD.ObtenerPorId(Id);
		}

		public DbQuery<Formularios> ObtenerTodo()
		{
			return this.oFormulariosAD.ObtenerTodo();
		}


		public DbQuery<FormulariosView> ObtenerParaGrilla()
		{
			return this.oFormulariosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFormulariosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Formularios Objeto)
		{
			try
			{
			this.oFormulariosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Formularios Objeto)
		{
			try
			{
			this.oFormulariosAD.Actualizar(Objeto);
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
			this.oFormulariosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFormulariosAD.Dispose();
		}
		public DbQuery<FormulariosViewT> JsonT(string term)
		{
			return (DbQuery<FormulariosViewT>)this.oFormulariosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
