
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
	public partial class ProveedoresRN
	{
		ProveedoresAD oProveedoresAD = new ProveedoresAD();

		public Proveedores ObtenerPorId(int Id)
		{
			return this.oProveedoresAD.ObtenerPorId(Id);
		}

		public DbQuery<Proveedores> ObtenerTodo()
		{
			return this.oProveedoresAD.ObtenerTodo();
		}


		public DbQuery<ProveedoresView> ObtenerParaGrilla()
		{
			return this.oProveedoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oProveedoresAD.ObtenerOptions(filtro);
		}

        public DbQuery<Proveedores> GetAutocomplete(String filtro)
        {
            return this.oProveedoresAD.GetAutocomplete(filtro);
        }

		public void Guardar(Proveedores Objeto)
		{
			try
			{
			this.oProveedoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Proveedores Objeto)
		{
			try
			{
			this.oProveedoresAD.Actualizar(Objeto);
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
			this.oProveedoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oProveedoresAD.Dispose();
		}
		public DbQuery<ProveedoresViewT> JsonT(string term)
		{
			return (DbQuery<ProveedoresViewT>)this.oProveedoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
