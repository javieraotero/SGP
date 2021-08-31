
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
	public partial class CoMediadoresContadoresRN
	{
		CoMediadoresContadoresAD oCoMediadoresContadoresAD = new CoMediadoresContadoresAD();

		public CoMediadoresContadores ObtenerPorId(int Id)
		{
			return this.oCoMediadoresContadoresAD.ObtenerPorId(Id);
		}

		public DbQuery<CoMediadoresContadores> ObtenerTodo()
		{
			return this.oCoMediadoresContadoresAD.ObtenerTodo();
		}


		public DbQuery<CoMediadoresContadoresView> ObtenerParaGrilla()
		{
			return this.oCoMediadoresContadoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCoMediadoresContadoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(CoMediadoresContadores Objeto)
		{
			try
			{
			this.oCoMediadoresContadoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadoresContadores Objeto)
		{
			try
			{
			this.oCoMediadoresContadoresAD.Actualizar(Objeto);
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
			this.oCoMediadoresContadoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCoMediadoresContadoresAD.Dispose();
		}
		public DbQuery<CoMediadoresContadoresViewT> JsonT(string term)
		{
			return (DbQuery<CoMediadoresContadoresViewT>)this.oCoMediadoresContadoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
