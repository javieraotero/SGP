
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
	public partial class PersonasCaracteristicasRefRN
	{
		PersonasCaracteristicasRefAD oPersonasCaracteristicasRefAD = new PersonasCaracteristicasRefAD();

		public PersonasCaracteristicasRef ObtenerPorId(int Id)
		{
			return this.oPersonasCaracteristicasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<PersonasCaracteristicasRef> ObtenerTodo()
		{
			return this.oPersonasCaracteristicasRefAD.ObtenerTodo();
		}


		public DbQuery<PersonasCaracteristicasRefView> ObtenerParaGrilla()
		{
			return this.oPersonasCaracteristicasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPersonasCaracteristicasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(PersonasCaracteristicasRef Objeto)
		{
			try
			{
			this.oPersonasCaracteristicasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasCaracteristicasRef Objeto)
		{
			try
			{
			this.oPersonasCaracteristicasRefAD.Actualizar(Objeto);
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
			this.oPersonasCaracteristicasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPersonasCaracteristicasRefAD.Dispose();
		}
		public DbQuery<PersonasCaracteristicasRefViewT> JsonT(string term)
		{
			return (DbQuery<PersonasCaracteristicasRefViewT>)this.oPersonasCaracteristicasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
