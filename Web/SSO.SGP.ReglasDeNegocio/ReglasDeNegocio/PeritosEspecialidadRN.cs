
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
	public partial class PeritosEspecialidadRN
	{
		PeritosEspecialidadAD oPeritosEspecialidadAD = new PeritosEspecialidadAD();

		public PeritosEspecialidad ObtenerPorId(int Id)
		{
			return this.oPeritosEspecialidadAD.ObtenerPorId(Id);
		}

		public DbQuery<PeritosEspecialidad> ObtenerTodo()
		{
			return this.oPeritosEspecialidadAD.ObtenerTodo();
		}


		public DbQuery<PeritosEspecialidadView> ObtenerParaGrilla()
		{
			return this.oPeritosEspecialidadAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosEspecialidadAD.ObtenerOptions(filtro);
		}

		public void Guardar(PeritosEspecialidad Objeto)
		{
			try
			{
			this.oPeritosEspecialidadAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosEspecialidad Objeto)
		{
			try
			{
			this.oPeritosEspecialidadAD.Actualizar(Objeto);
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
			this.oPeritosEspecialidadAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosEspecialidadAD.Dispose();
		}
		public DbQuery<PeritosEspecialidadViewT> JsonT(string term)
		{
			return (DbQuery<PeritosEspecialidadViewT>)this.oPeritosEspecialidadAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
