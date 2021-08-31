
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
	public partial class PersonasRN
	{
		PersonasAD oPersonasAD = new PersonasAD();

		public Personas ObtenerPorId(int Id)
		{
			return this.oPersonasAD.ObtenerPorId(Id);
		}

		public DbQuery<Personas> ObtenerTodo()
		{
			return this.oPersonasAD.ObtenerTodo();
		}

        public bool ExisteDocumento(long? documento)
        {
            return this.oPersonasAD.ExisteDocumento(documento);
        }


		public DbQuery<PersonasView> ObtenerParaGrilla()
		{
			return this.oPersonasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPersonasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Personas Objeto)
		{
			try
			{
			this.oPersonasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Personas Objeto)
		{
			try
			{
			this.oPersonasAD.Actualizar(Objeto);
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
			this.oPersonasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPersonasAD.Dispose();
		}

		public DbQuery<PersonasViewT> JsonT(string term)
		{
			return (DbQuery<PersonasViewT>)this.oPersonasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/

        public DbQuery<PersonasViewT> BuscarPersona(long documento, string apellido, string nombre, int sexo)
        {
            return (DbQuery<PersonasViewT>)this.oPersonasAD.BuscarPersona(documento, apellido, nombre, sexo);
        }

	}
}
