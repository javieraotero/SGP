
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
	public partial class PeritosContadoresRN
	{
		PeritosContadoresAD oPeritosContadoresAD = new PeritosContadoresAD();

		public PeritosContadores ObtenerPorId(int Id)
		{
			return this.oPeritosContadoresAD.ObtenerPorId(Id);
		}

		public DbQuery<PeritosContadores> ObtenerTodo()
		{
			return this.oPeritosContadoresAD.ObtenerTodo();
		}


		public DbQuery<PeritosContadoresView> ObtenerParaGrilla()
		{
			return this.oPeritosContadoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosContadoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(PeritosContadores Objeto)
		{
			try
			{
			this.oPeritosContadoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosContadores Objeto)
		{
			try
			{
			this.oPeritosContadoresAD.Actualizar(Objeto);
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
			this.oPeritosContadoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosContadoresAD.Dispose();
		}
		public DbQuery<PeritosContadoresViewT> JsonT(string term)
		{
			return (DbQuery<PeritosContadoresViewT>)this.oPeritosContadoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
