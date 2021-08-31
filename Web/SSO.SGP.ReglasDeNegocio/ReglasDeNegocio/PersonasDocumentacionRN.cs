
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
	public partial class PersonasDocumentacionRN
	{
		PersonasDocumentacionAD oPersonasDocumentacionAD = new PersonasDocumentacionAD();

		public PersonasDocumentacion ObtenerPorId(int Id)
		{
			return this.oPersonasDocumentacionAD.ObtenerPorId(Id);
		}

		public DbQuery<PersonasDocumentacion> ObtenerTodo()
		{
			return this.oPersonasDocumentacionAD.ObtenerTodo();
		}


		public DbQuery<PersonasDocumentacionView> ObtenerParaGrilla()
		{
			return this.oPersonasDocumentacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPersonasDocumentacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(PersonasDocumentacion Objeto)
		{
			try
			{
			this.oPersonasDocumentacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasDocumentacion Objeto)
		{
			try
			{
			this.oPersonasDocumentacionAD.Actualizar(Objeto);
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
			this.oPersonasDocumentacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPersonasDocumentacionAD.Dispose();
		}
		public DbQuery<PersonasDocumentacionViewT> JsonT(string term)
		{
			return (DbQuery<PersonasDocumentacionViewT>)this.oPersonasDocumentacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
