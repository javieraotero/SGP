
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
	public partial class MotivosDemoraRefRN
	{
		MotivosDemoraRefAD oMotivosDemoraRefAD = new MotivosDemoraRefAD();

		public MotivosDemoraRef ObtenerPorId(int Id)
		{
			return this.oMotivosDemoraRefAD.ObtenerPorId(Id);
		}

		public DbQuery<MotivosDemoraRef> ObtenerTodo()
		{
			return this.oMotivosDemoraRefAD.ObtenerTodo();
		}


		public DbQuery<MotivosDemoraRefView> ObtenerParaGrilla()
		{
			return this.oMotivosDemoraRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMotivosDemoraRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(MotivosDemoraRef Objeto)
		{
			try
			{
			this.oMotivosDemoraRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosDemoraRef Objeto)
		{
			try
			{
			this.oMotivosDemoraRefAD.Actualizar(Objeto);
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
			this.oMotivosDemoraRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMotivosDemoraRefAD.Dispose();
		}
		public DbQuery<MotivosDemoraRefViewT> JsonT(string term)
		{
			return (DbQuery<MotivosDemoraRefViewT>)this.oMotivosDemoraRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
