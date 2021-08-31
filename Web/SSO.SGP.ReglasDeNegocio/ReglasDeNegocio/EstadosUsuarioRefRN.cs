
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
	public partial class EstadosUsuarioRefRN
	{
		EstadosUsuarioRefAD oEstadosUsuarioRefAD = new EstadosUsuarioRefAD();

		public EstadosUsuarioRef ObtenerPorId(int Id)
		{
			return this.oEstadosUsuarioRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosUsuarioRef> ObtenerTodo()
		{
			return this.oEstadosUsuarioRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosUsuarioRefView> ObtenerParaGrilla()
		{
			return this.oEstadosUsuarioRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosUsuarioRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosUsuarioRef Objeto)
		{
			try
			{
			this.oEstadosUsuarioRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosUsuarioRef Objeto)
		{
			try
			{
			this.oEstadosUsuarioRefAD.Actualizar(Objeto);
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
			this.oEstadosUsuarioRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosUsuarioRefAD.Dispose();
		}
		public DbQuery<EstadosUsuarioRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosUsuarioRefViewT>)this.oEstadosUsuarioRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
