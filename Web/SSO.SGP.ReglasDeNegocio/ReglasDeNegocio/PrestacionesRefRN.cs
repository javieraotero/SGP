
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
	public partial class PrestacionesRefRN
	{
		PrestacionesRefAD oPrestacionesRefAD = new PrestacionesRefAD();

		public PrestacionesRef ObtenerPorId(int Id)
		{
			return this.oPrestacionesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<PrestacionesRef> ObtenerTodo()
		{
			return this.oPrestacionesRefAD.ObtenerTodo();
		}


		public DbQuery<PrestacionesRefView> ObtenerParaGrilla()
		{
			return this.oPrestacionesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPrestacionesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(PrestacionesRef Objeto)
		{
			try
			{
			this.oPrestacionesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PrestacionesRef Objeto)
		{
			try
			{
			this.oPrestacionesRefAD.Actualizar(Objeto);
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
			this.oPrestacionesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPrestacionesRefAD.Dispose();
		}
		public DbQuery<PrestacionesRefViewT> JsonT(string term)
		{
			return (DbQuery<PrestacionesRefViewT>)this.oPrestacionesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
