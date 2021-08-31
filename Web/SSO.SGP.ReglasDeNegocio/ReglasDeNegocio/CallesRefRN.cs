
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
	public partial class CallesRefRN
	{
		CallesRefAD oCallesRefAD = new CallesRefAD();

		public CallesRef ObtenerPorId(int Id)
		{
			return this.oCallesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<CallesRef> ObtenerTodo()
		{
			return this.oCallesRefAD.ObtenerTodo();
		}


		public DbQuery<CallesRefView> ObtenerParaGrilla()
		{
			return this.oCallesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCallesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(CallesRef Objeto)
		{
			try
			{
			this.oCallesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CallesRef Objeto)
		{
			try
			{
			this.oCallesRefAD.Actualizar(Objeto);
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
			this.oCallesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCallesRefAD.Dispose();
		}
		public DbQuery<CallesRefViewT> JsonT(string term)
		{
			return (DbQuery<CallesRefViewT>)this.oCallesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
