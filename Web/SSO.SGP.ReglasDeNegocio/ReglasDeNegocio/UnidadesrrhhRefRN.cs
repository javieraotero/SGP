
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
	public partial class UnidadesrrhhRefRN
	{
		UnidadesrrhhRefAD oUnidadesrrhhRefAD = new UnidadesrrhhRefAD();

		public UnidadesrrhhRef ObtenerPorId(int Id)
		{
			return this.oUnidadesrrhhRefAD.ObtenerPorId(Id);
		}

		public DbQuery<UnidadesrrhhRef> ObtenerTodo()
		{
			return this.oUnidadesrrhhRefAD.ObtenerTodo();
		}


		public DbQuery<UnidadesrrhhRefView> ObtenerParaGrilla()
		{
			return this.oUnidadesrrhhRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oUnidadesrrhhRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(UnidadesrrhhRef Objeto)
		{
			try
			{
			this.oUnidadesrrhhRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UnidadesrrhhRef Objeto)
		{
			try
			{
			this.oUnidadesrrhhRefAD.Actualizar(Objeto);
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
			this.oUnidadesrrhhRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oUnidadesrrhhRefAD.Dispose();
		}
		public DbQuery<UnidadesrrhhRefViewT> JsonT(string term)
		{
			return (DbQuery<UnidadesrrhhRefViewT>)this.oUnidadesrrhhRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
