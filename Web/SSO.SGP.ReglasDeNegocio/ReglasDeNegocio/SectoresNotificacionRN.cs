
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
	public partial class SectoresNotificacionRN
	{
		SectoresNotificacionAD oSectoresNotificacionAD = new SectoresNotificacionAD();

		public SectoresNotificacion ObtenerPorId(int Id)
		{
			return this.oSectoresNotificacionAD.ObtenerPorId(Id);
		}

		public DbQuery<SectoresNotificacion> ObtenerTodo()
		{
			return this.oSectoresNotificacionAD.ObtenerTodo();
		}


		public DbQuery<SectoresNotificacionView> ObtenerParaGrilla()
		{
			return this.oSectoresNotificacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oSectoresNotificacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(SectoresNotificacion Objeto)
		{
			try
			{
			this.oSectoresNotificacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SectoresNotificacion Objeto)
		{
			try
			{
			this.oSectoresNotificacionAD.Actualizar(Objeto);
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
			this.oSectoresNotificacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oSectoresNotificacionAD.Dispose();
		}
		public DbQuery<SectoresNotificacionViewT> JsonT(string term)
		{
			return (DbQuery<SectoresNotificacionViewT>)this.oSectoresNotificacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
