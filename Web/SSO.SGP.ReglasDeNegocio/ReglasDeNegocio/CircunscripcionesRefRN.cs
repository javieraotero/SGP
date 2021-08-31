
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
	public partial class CircunscripcionesRefRN
	{
		CircunscripcionesRefAD oCircunscripcionesRefAD = new CircunscripcionesRefAD();

		public CircunscripcionesRef ObtenerPorId(int Id)
		{
			return this.oCircunscripcionesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<CircunscripcionesRef> ObtenerTodo()
		{
			return this.oCircunscripcionesRefAD.ObtenerTodo();
		}


		public DbQuery<CircunscripcionesRefView> ObtenerParaGrilla()
		{
			return this.oCircunscripcionesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCircunscripcionesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(CircunscripcionesRef Objeto)
		{
			try
			{
			this.oCircunscripcionesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CircunscripcionesRef Objeto)
		{
			try
			{
			this.oCircunscripcionesRefAD.Actualizar(Objeto);
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
			this.oCircunscripcionesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCircunscripcionesRefAD.Dispose();
		}
		public DbQuery<CircunscripcionesRefViewT> JsonT(string term)
		{
			return (DbQuery<CircunscripcionesRefViewT>)this.oCircunscripcionesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
