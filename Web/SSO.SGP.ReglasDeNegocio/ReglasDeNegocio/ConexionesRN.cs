
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
	public partial class ConexionesRN
	{
		ConexionesAD oConexionesAD = new ConexionesAD();

		public Conexiones ObtenerPorId(int Id)
		{
			return this.oConexionesAD.ObtenerPorId(Id);
		}

		public DbQuery<Conexiones> ObtenerTodo()
		{
			return this.oConexionesAD.ObtenerTodo();
		}


		public DbQuery<ConexionesView> ObtenerParaGrilla()
		{
			return this.oConexionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oConexionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Conexiones Objeto)
		{
			try
			{
			this.oConexionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Conexiones Objeto)
		{
			try
			{
			this.oConexionesAD.Actualizar(Objeto);
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
			this.oConexionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oConexionesAD.Dispose();
		}
		public DbQuery<ConexionesViewT> JsonT(string term)
		{
			return (DbQuery<ConexionesViewT>)this.oConexionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
