
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
	public partial class CoMediadoresEspecialidadRN
	{
		CoMediadoresEspecialidadAD oCoMediadoresEspecialidadAD = new CoMediadoresEspecialidadAD();

		public CoMediadoresEspecialidad ObtenerPorId(int Id)
		{
			return this.oCoMediadoresEspecialidadAD.ObtenerPorId(Id);
		}

		public DbQuery<CoMediadoresEspecialidad> ObtenerTodo()
		{
			return this.oCoMediadoresEspecialidadAD.ObtenerTodo();
		}


		public DbQuery<CoMediadoresEspecialidadView> ObtenerParaGrilla()
		{
			return this.oCoMediadoresEspecialidadAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCoMediadoresEspecialidadAD.ObtenerOptions(filtro);
		}

		public void Guardar(CoMediadoresEspecialidad Objeto)
		{
			try
			{
			this.oCoMediadoresEspecialidadAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadoresEspecialidad Objeto)
		{
			try
			{
			this.oCoMediadoresEspecialidadAD.Actualizar(Objeto);
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
			this.oCoMediadoresEspecialidadAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCoMediadoresEspecialidadAD.Dispose();
		}
		public DbQuery<CoMediadoresEspecialidadViewT> JsonT(string term)
		{
			return (DbQuery<CoMediadoresEspecialidadViewT>)this.oCoMediadoresEspecialidadAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
