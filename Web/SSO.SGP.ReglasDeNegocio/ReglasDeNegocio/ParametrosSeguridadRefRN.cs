
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
	public partial class ParametrosSeguridadRefRN
	{
		ParametrosSeguridadRefAD oParametrosSeguridadRefAD = new ParametrosSeguridadRefAD();

		public ParametrosSeguridadRef ObtenerPorId(int Id)
		{
			return this.oParametrosSeguridadRefAD.ObtenerPorId(Id);
		}

		public DbQuery<ParametrosSeguridadRef> ObtenerTodo()
		{
			return this.oParametrosSeguridadRefAD.ObtenerTodo();
		}


		public DbQuery<ParametrosSeguridadRefView> ObtenerParaGrilla()
		{
			return this.oParametrosSeguridadRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oParametrosSeguridadRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(ParametrosSeguridadRef Objeto)
		{
			try
			{
			this.oParametrosSeguridadRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosSeguridadRef Objeto)
		{
			try
			{
			this.oParametrosSeguridadRefAD.Actualizar(Objeto);
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
			this.oParametrosSeguridadRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oParametrosSeguridadRefAD.Dispose();
		}
		public DbQuery<ParametrosSeguridadRefViewT> JsonT(string term)
		{
			return (DbQuery<ParametrosSeguridadRefViewT>)this.oParametrosSeguridadRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
