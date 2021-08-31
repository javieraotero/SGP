
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
	public partial class ProtocolosCategoriasRN
	{
		ProtocolosCategoriasAD oProtocolosCategoriasAD = new ProtocolosCategoriasAD();

		public ProtocolosCategorias ObtenerPorId(int Id)
		{
			return this.oProtocolosCategoriasAD.ObtenerPorId(Id);
		}

		public DbQuery<ProtocolosCategorias> ObtenerTodo()
		{
			return this.oProtocolosCategoriasAD.ObtenerTodo();
		}


		public DbQuery<ProtocolosCategoriasView> ObtenerParaGrilla()
		{
			return this.oProtocolosCategoriasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oProtocolosCategoriasAD.ObtenerOptions(filtro);
		}

		public void Guardar(ProtocolosCategorias Objeto)
		{
			try
			{
			this.oProtocolosCategoriasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ProtocolosCategorias Objeto)
		{
			try
			{
			this.oProtocolosCategoriasAD.Actualizar(Objeto);
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
			this.oProtocolosCategoriasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oProtocolosCategoriasAD.Dispose();
		}
		public DbQuery<ProtocolosCategoriasViewT> JsonT(string term)
		{
			return (DbQuery<ProtocolosCategoriasViewT>)this.oProtocolosCategoriasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
