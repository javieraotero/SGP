
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
	public partial class ParametrosTrabajoRefRN
	{
		ParametrosTrabajoRefAD oParametrosTrabajoRefAD = new ParametrosTrabajoRefAD();

		public ParametrosTrabajoRef ObtenerPorId(int Id)
		{
			return this.oParametrosTrabajoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<ParametrosTrabajoRef> ObtenerTodo()
		{
			return this.oParametrosTrabajoRefAD.ObtenerTodo();
		}


		public DbQuery<ParametrosTrabajoRefView> ObtenerParaGrilla()
		{
			return this.oParametrosTrabajoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oParametrosTrabajoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(ParametrosTrabajoRef Objeto)
		{
			try
			{
			this.oParametrosTrabajoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosTrabajoRef Objeto)
		{
			try
			{
			this.oParametrosTrabajoRefAD.Actualizar(Objeto);
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
			this.oParametrosTrabajoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oParametrosTrabajoRefAD.Dispose();
		}
		public DbQuery<ParametrosTrabajoRefViewT> JsonT(string term)
		{
			return (DbQuery<ParametrosTrabajoRefViewT>)this.oParametrosTrabajoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
