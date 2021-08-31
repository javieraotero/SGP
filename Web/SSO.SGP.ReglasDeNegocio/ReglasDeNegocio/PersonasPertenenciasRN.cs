
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
	public partial class PersonasPertenenciasRN
	{
		PersonasPertenenciasAD oPersonasPertenenciasAD = new PersonasPertenenciasAD();

		public PersonasPertenencias ObtenerPorId(int Id)
		{
			return this.oPersonasPertenenciasAD.ObtenerPorId(Id);
		}

		public DbQuery<PersonasPertenencias> ObtenerTodo()
		{
			return this.oPersonasPertenenciasAD.ObtenerTodo();
		}


		public DbQuery<PersonasPertenenciasView> ObtenerParaGrilla()
		{
			return this.oPersonasPertenenciasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPersonasPertenenciasAD.ObtenerOptions(filtro);
		}

		public void Guardar(PersonasPertenencias Objeto)
		{
			try
			{
			this.oPersonasPertenenciasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasPertenencias Objeto)
		{
			try
			{
			this.oPersonasPertenenciasAD.Actualizar(Objeto);
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
			this.oPersonasPertenenciasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPersonasPertenenciasAD.Dispose();
		}
		public DbQuery<PersonasPertenenciasViewT> JsonT(string term)
		{
			return (DbQuery<PersonasPertenenciasViewT>)this.oPersonasPertenenciasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
