
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
	public partial class DivisionesExtraPresupuestariasRN
	{
		DivisionesExtraPresupuestariasAD oDivisionesExtraPresupuestariasAD = new DivisionesExtraPresupuestariasAD();

		public DivisionesExtraPresupuestarias ObtenerPorId(int Id)
		{
			return this.oDivisionesExtraPresupuestariasAD.ObtenerPorId(Id);
		}

		public DbQuery<DivisionesExtraPresupuestarias> ObtenerTodo()
		{
			return this.oDivisionesExtraPresupuestariasAD.ObtenerTodo();
		}


		public DbQuery<DivisionesExtraPresupuestariasView> ObtenerParaGrilla()
		{
			return this.oDivisionesExtraPresupuestariasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oDivisionesExtraPresupuestariasAD.ObtenerOptions(filtro);
		}

		public void Guardar(DivisionesExtraPresupuestarias Objeto)
		{
			try
			{
			this.oDivisionesExtraPresupuestariasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DivisionesExtraPresupuestarias Objeto)
		{
			try
			{
			this.oDivisionesExtraPresupuestariasAD.Actualizar(Objeto);
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
			this.oDivisionesExtraPresupuestariasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oDivisionesExtraPresupuestariasAD.Dispose();
		}
		public DbQuery<DivisionesExtraPresupuestariasViewT> JsonT(string term)
		{
			return (DbQuery<DivisionesExtraPresupuestariasViewT>)this.oDivisionesExtraPresupuestariasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
