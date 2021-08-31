
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
	public partial class LocalidadesRefRN
	{
		LocalidadesRefAD oLocalidadesRefAD = new LocalidadesRefAD();

		public LocalidadesRef ObtenerPorId(int Id)
		{
			return this.oLocalidadesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<LocalidadesRef> ObtenerTodo()
		{
			return this.oLocalidadesRefAD.ObtenerTodo();
		}


		public DbQuery<LocalidadesRefView> ObtenerParaGrilla()
		{
			return this.oLocalidadesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLocalidadesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(LocalidadesRef Objeto)
		{
			try
			{
			this.oLocalidadesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LocalidadesRef Objeto)
		{
			try
			{
			this.oLocalidadesRefAD.Actualizar(Objeto);
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
			this.oLocalidadesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLocalidadesRefAD.Dispose();
		}
		public DbQuery<LocalidadesRefViewT> JsonT(string term)
		{
			return (DbQuery<LocalidadesRefViewT>)this.oLocalidadesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
