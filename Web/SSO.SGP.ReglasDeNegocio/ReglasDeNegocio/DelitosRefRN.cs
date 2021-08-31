
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
	public partial class DelitosRefRN
	{
		DelitosRefAD oDelitosRefAD = new DelitosRefAD();

		public DelitosRef ObtenerPorId(int Id)
		{
			return this.oDelitosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<DelitosRef> ObtenerTodo()
		{
			return this.oDelitosRefAD.ObtenerTodo();
		}


		public DbQuery<DelitosRefView> ObtenerParaGrilla()
		{
			return this.oDelitosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oDelitosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(DelitosRef Objeto)
		{
			try
			{
			this.oDelitosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DelitosRef Objeto)
		{
			try
			{
			this.oDelitosRefAD.Actualizar(Objeto);
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
			this.oDelitosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oDelitosRefAD.Dispose();
		}
		public DbQuery<DelitosRefViewT> JsonT(string term)
		{
			return (DbQuery<DelitosRefViewT>)this.oDelitosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
