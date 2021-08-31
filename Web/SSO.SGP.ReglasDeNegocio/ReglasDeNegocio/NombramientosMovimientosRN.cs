
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
	public partial class NombramientosMovimientosRN
	{
		NombramientosMovimientosAD oNombramientosMovimientosAD = new NombramientosMovimientosAD();

		public NombramientosMovimientos ObtenerPorId(int Id)
		{
			return this.oNombramientosMovimientosAD.ObtenerPorId(Id);
		}

		public DbQuery<NombramientosMovimientos> ObtenerTodo()
		{
			return this.oNombramientosMovimientosAD.ObtenerTodo();
		}


		public DbQuery<NombramientosMovimientosView> ObtenerParaGrilla()
		{
			return this.oNombramientosMovimientosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oNombramientosMovimientosAD.ObtenerOptions(filtro);
		}

		public void Guardar(NombramientosMovimientos Objeto)
		{
			try
			{
			this.oNombramientosMovimientosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(NombramientosMovimientos Objeto)
		{
			try
			{
			this.oNombramientosMovimientosAD.Actualizar(Objeto);
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
			this.oNombramientosMovimientosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oNombramientosMovimientosAD.Dispose();
		}
		public DbQuery<NombramientosMovimientosViewT> JsonT(int movimiento)
		{
			return (DbQuery<NombramientosMovimientosViewT>)this.oNombramientosMovimientosAD.JsonT(movimiento);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
