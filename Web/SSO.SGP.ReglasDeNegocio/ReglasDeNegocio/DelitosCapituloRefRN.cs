
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
	public partial class DelitosCapituloRefRN
	{
		DelitosCapituloRefAD oDelitosCapituloRefAD = new DelitosCapituloRefAD();

		public DelitosCapituloRef ObtenerPorId(int Id)
		{
			return this.oDelitosCapituloRefAD.ObtenerPorId(Id);
		}

		public DbQuery<DelitosCapituloRef> ObtenerTodo()
		{
			return this.oDelitosCapituloRefAD.ObtenerTodo();
		}


		public DbQuery<DelitosCapituloRefView> ObtenerParaGrilla()
		{
			return this.oDelitosCapituloRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oDelitosCapituloRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(DelitosCapituloRef Objeto)
		{
			try
			{
			this.oDelitosCapituloRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DelitosCapituloRef Objeto)
		{
			try
			{
			this.oDelitosCapituloRefAD.Actualizar(Objeto);
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
			this.oDelitosCapituloRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oDelitosCapituloRefAD.Dispose();
		}
		public DbQuery<DelitosCapituloRefViewT> JsonT(string term)
		{
			return (DbQuery<DelitosCapituloRefViewT>)this.oDelitosCapituloRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
