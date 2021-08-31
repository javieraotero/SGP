
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
	public partial class ProtocolosRN
	{
		ProtocolosAD oProtocolosAD = new ProtocolosAD();

		public Protocolos ObtenerPorId(int Id)
		{
			return this.oProtocolosAD.ObtenerPorId(Id);
		}

		public DbQuery<Protocolos> ObtenerTodo()
		{
			return this.oProtocolosAD.ObtenerTodo();
		}


		public DbQuery<ProtocolosView> ObtenerParaGrilla()
		{
			return this.oProtocolosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oProtocolosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Protocolos Objeto)
		{
			try
			{
			this.oProtocolosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Protocolos Objeto)
		{
			try
			{
			this.oProtocolosAD.Actualizar(Objeto);
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
			this.oProtocolosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oProtocolosAD.Dispose();
		}
		public DbQuery<ProtocolosViewT> JsonT(string term)
		{
			return (DbQuery<ProtocolosViewT>)this.oProtocolosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
