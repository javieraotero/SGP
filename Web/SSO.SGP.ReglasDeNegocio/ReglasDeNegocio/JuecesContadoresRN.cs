
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
	public partial class JuecesContadoresRN
	{
		JuecesContadoresAD oJuecesContadoresAD = new JuecesContadoresAD();

		public JuecesContadores ObtenerPorId(int Id)
		{
			return this.oJuecesContadoresAD.ObtenerPorId(Id);
		}

		public DbQuery<JuecesContadores> ObtenerTodo()
		{
			return this.oJuecesContadoresAD.ObtenerTodo();
		}


		public DbQuery<JuecesContadoresView> ObtenerParaGrilla()
		{
			return this.oJuecesContadoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oJuecesContadoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(JuecesContadores Objeto)
		{
			try
			{
			this.oJuecesContadoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(JuecesContadores Objeto)
		{
			try
			{
			this.oJuecesContadoresAD.Actualizar(Objeto);
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
			this.oJuecesContadoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oJuecesContadoresAD.Dispose();
		}
		public DbQuery<JuecesContadoresViewT> JsonT(string term)
		{
			return (DbQuery<JuecesContadoresViewT>)this.oJuecesContadoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
