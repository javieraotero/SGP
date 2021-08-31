
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
	public partial class CoMediadoresRN
	{
		CoMediadoresAD oCoMediadoresAD = new CoMediadoresAD();

		public CoMediadores ObtenerPorId(int Id)
		{
			return this.oCoMediadoresAD.ObtenerPorId(Id);
		}

		public DbQuery<CoMediadores> ObtenerTodo()
		{
			return this.oCoMediadoresAD.ObtenerTodo();
		}


		public DbQuery<CoMediadoresView> ObtenerParaGrilla()
		{
			return this.oCoMediadoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCoMediadoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(CoMediadores Objeto)
		{
			try
			{
			this.oCoMediadoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadores Objeto)
		{
			try
			{
			this.oCoMediadoresAD.Actualizar(Objeto);
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
			this.oCoMediadoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCoMediadoresAD.Dispose();
		}
		public DbQuery<CoMediadoresViewT> JsonT(string term)
		{
			return (DbQuery<CoMediadoresViewT>)this.oCoMediadoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
