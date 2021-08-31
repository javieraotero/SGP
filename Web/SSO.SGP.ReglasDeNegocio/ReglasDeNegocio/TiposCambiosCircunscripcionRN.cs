
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
	public partial class TiposCambiosCircunscripcionRN
	{
		TiposCambiosCircunscripcionAD oTiposCambiosCircunscripcionAD = new TiposCambiosCircunscripcionAD();

		public TiposCambiosCircunscripcion ObtenerPorId(int Id)
		{
			return this.oTiposCambiosCircunscripcionAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposCambiosCircunscripcion> ObtenerTodo()
		{
			return this.oTiposCambiosCircunscripcionAD.ObtenerTodo();
		}


		public DbQuery<TiposCambiosCircunscripcionView> ObtenerParaGrilla()
		{
			return this.oTiposCambiosCircunscripcionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposCambiosCircunscripcionAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposCambiosCircunscripcion Objeto)
		{
			try
			{
			this.oTiposCambiosCircunscripcionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposCambiosCircunscripcion Objeto)
		{
			try
			{
			this.oTiposCambiosCircunscripcionAD.Actualizar(Objeto);
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
			this.oTiposCambiosCircunscripcionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposCambiosCircunscripcionAD.Dispose();
		}
		public DbQuery<TiposCambiosCircunscripcionViewT> JsonT(string term)
		{
			return (DbQuery<TiposCambiosCircunscripcionViewT>)this.oTiposCambiosCircunscripcionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
