
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
	public partial class ContadoresRN
	{
		ContadoresAD oContadoresAD = new ContadoresAD();

		public Contadores ObtenerPorId(int Id)
		{
			return this.oContadoresAD.ObtenerPorId(Id);
		}

		public DbQuery<Contadores> ObtenerTodo()
		{
			return this.oContadoresAD.ObtenerTodo();
		}


		public DbQuery<ContadoresView> ObtenerParaGrilla()
		{
			return this.oContadoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oContadoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(Contadores Objeto)
		{
			try
			{
			this.oContadoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Contadores Objeto)
		{
			try
			{
			this.oContadoresAD.Actualizar(Objeto);
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
			this.oContadoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oContadoresAD.Dispose();
		}
		public DbQuery<ContadoresViewT> JsonT(string term)
		{
			return (DbQuery<ContadoresViewT>)this.oContadoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
