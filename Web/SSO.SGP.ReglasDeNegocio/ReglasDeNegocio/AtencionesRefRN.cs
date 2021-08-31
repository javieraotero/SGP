
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
	public partial class AtencionesRefRN
	{
		AtencionesRefAD oAtencionesRefAD = new AtencionesRefAD();

		public AtencionesRef ObtenerPorId(int Id)
		{
			return this.oAtencionesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<AtencionesRef> ObtenerTodo()
		{
			return this.oAtencionesRefAD.ObtenerTodo();
		}


		public DbQuery<AtencionesRefView> ObtenerParaGrilla()
		{
			return this.oAtencionesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAtencionesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(AtencionesRef Objeto)
		{
			try
			{
			this.oAtencionesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AtencionesRef Objeto)
		{
			try
			{
			this.oAtencionesRefAD.Actualizar(Objeto);
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
			this.oAtencionesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAtencionesRefAD.Dispose();
		}
		public DbQuery<AtencionesRefViewT> JsonT(string term)
		{
			return (DbQuery<AtencionesRefViewT>)this.oAtencionesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
