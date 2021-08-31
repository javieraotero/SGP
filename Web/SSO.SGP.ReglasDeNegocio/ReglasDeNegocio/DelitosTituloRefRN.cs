
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
	public partial class DelitosTituloRefRN
	{
		DelitosTituloRefAD oDelitosTituloRefAD = new DelitosTituloRefAD();

		public DelitosTituloRef ObtenerPorId(int Id)
		{
			return this.oDelitosTituloRefAD.ObtenerPorId(Id);
		}

		public DbQuery<DelitosTituloRef> ObtenerTodo()
		{
			return this.oDelitosTituloRefAD.ObtenerTodo();
		}


		public DbQuery<DelitosTituloRefView> ObtenerParaGrilla()
		{
			return this.oDelitosTituloRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oDelitosTituloRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(DelitosTituloRef Objeto)
		{
			try
			{
			this.oDelitosTituloRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DelitosTituloRef Objeto)
		{
			try
			{
			this.oDelitosTituloRefAD.Actualizar(Objeto);
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
			this.oDelitosTituloRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oDelitosTituloRefAD.Dispose();
		}
		public DbQuery<DelitosTituloRefViewT> JsonT(string term)
		{
			return (DbQuery<DelitosTituloRefViewT>)this.oDelitosTituloRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
