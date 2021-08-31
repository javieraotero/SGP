
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
	public partial class AgentesBonificacionesRN
	{
		AgentesBonificacionesAD oAgentesBonificacionesAD = new AgentesBonificacionesAD();

		public AgentesBonificaciones ObtenerPorId(int Id)
		{
			return this.oAgentesBonificacionesAD.ObtenerPorId(Id);
		}

		public DbQuery<AgentesBonificaciones> ObtenerTodo()
		{
			return this.oAgentesBonificacionesAD.ObtenerTodo();
		}


		public DbQuery<AgentesBonificacionesView> ObtenerParaGrilla()
		{
			return this.oAgentesBonificacionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAgentesBonificacionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(AgentesBonificaciones Objeto)
		{
			try
			{
			this.oAgentesBonificacionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AgentesBonificaciones Objeto)
		{
			try
			{
			this.oAgentesBonificacionesAD.Actualizar(Objeto);
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
			this.oAgentesBonificacionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAgentesBonificacionesAD.Dispose();
		}
		public DbQuery<AgentesBonificacionesViewT> JsonT(string term)
		{
			return (DbQuery<AgentesBonificacionesViewT>)this.oAgentesBonificacionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
