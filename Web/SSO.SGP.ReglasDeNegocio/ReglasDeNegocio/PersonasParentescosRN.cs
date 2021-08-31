
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
	public partial class PersonasParentescosRN
	{
		PersonasParentescosAD oPersonasParentescosAD = new PersonasParentescosAD();

		public PersonasParentescos ObtenerPorId(int Id)
		{
			return this.oPersonasParentescosAD.ObtenerPorId(Id);
		}

		public DbQuery<PersonasParentescos> ObtenerTodo()
		{
			return this.oPersonasParentescosAD.ObtenerTodo();
		}


		public DbQuery<PersonasParentescosView> ObtenerParaGrilla()
		{
			return this.oPersonasParentescosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPersonasParentescosAD.ObtenerOptions(filtro);
		}

		public void Guardar(PersonasParentescos Objeto)
		{
			try
			{
			this.oPersonasParentescosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasParentescos Objeto)
		{
			try
			{
			this.oPersonasParentescosAD.Actualizar(Objeto);
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
			this.oPersonasParentescosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPersonasParentescosAD.Dispose();
		}
		public DbQuery<PersonasParentescosViewT> JsonT(string term)
		{
			return (DbQuery<PersonasParentescosViewT>)this.oPersonasParentescosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
