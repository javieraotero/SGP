
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
	public partial class PermisosRN
	{
		PermisosAD oPermisosAD = new PermisosAD();

		public Permisos ObtenerPorId(int Id)
		{
			return this.oPermisosAD.ObtenerPorId(Id);
		}

		public DbQuery<Permisos> ObtenerTodo()
		{
			return this.oPermisosAD.ObtenerTodo();
		}


		public DbQuery<PermisosView> ObtenerParaGrilla()
		{
			return this.oPermisosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPermisosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Permisos Objeto)
		{
			try
			{
			this.oPermisosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Permisos Objeto)
		{
			try
			{
			this.oPermisosAD.Actualizar(Objeto);
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
			this.oPermisosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPermisosAD.Dispose();
		}
		public DbQuery<PermisosViewT> JsonT(string term)
		{
			return (DbQuery<PermisosViewT>)this.oPermisosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
