
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ProveedoresAD
	{
		private BDEntities db = new BDEntities();

		public Proveedores ObtenerPorId(int Id)
		{
			return db.Proveedores.Single(c => c.Id == Id);
		}

		public DbQuery<Proveedores> ObtenerTodo()
		{
			return (DbQuery<Proveedores>)db.Proveedores;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Proveedores
                      where x.Nombre.Contains(filtro)
				select new SelectOptionsView {text = x.Nombre, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<Proveedores> GetAutocomplete(string filtro)
        {
            var res = from x in db.Proveedores
                      where x.Nombre.Contains(filtro)
                      select x;
            return (DbQuery<Proveedores>)res;
        }

		public DbQuery<ProveedoresView> ObtenerParaGrilla()
		{
			var x = from c in db.Proveedores
					select new ProveedoresView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 RazonSocial = c.RazonSocial,
						 DomicilioReal = c.DomicilioReal,
						 CodigoPostal = c.CodigoPostal,
						 CUIT = c.CUIT,
						 IngresosBrutos = c.IngresosBrutos,
						 Estado = c.Estado,
					};
			return (DbQuery<ProveedoresView>)x;
		}

		public void Guardar(Proveedores Objeto)
		{
			try
			{
				db.Proveedores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Proveedores Objeto)
		{
			try
			{
				db.Proveedores.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				Proveedores Objeto = this.ObtenerPorId(IdObjeto);
				db.Proveedores.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		public DbQuery<ProveedoresViewT> JsonT(string term)
		{
			var x = from c in db.Proveedores
					select new ProveedoresViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 NumeroAcreedor = c.NumeroAcreedor,
						 RazonSocial = c.RazonSocial,
						 NombreFantasia = c.NombreFantasia,
						 DomicilioReal = c.DomicilioReal,
						 CodigoPostal = c.CodigoPostal,
						 CUIT = c.CUIT,
						 IngresosBrutos = c.IngresosBrutos,
						 ExentoGanancias = c.ExentoGanancias,
						 ExentoIngresosBrutos = c.ExentoIngresosBrutos,
						 InscriptoEnGanancias = c.InscriptoEnGanancias,
						 Estado = c.Estado,
						 FechaInscripcion = c.FechaInscripcion,
						 FechaReInscripcion = c.FechaReInscripcion,
						 FechaFinExentoSellado = c.FechaFinExentoSellado,
						 FechaFinSuspension = c.FechaFinSuspension,
						 FechaFinExentoGanancias = c.FechaFinExentoGanancias,
						 FechaFinExentoIngresosBrutos = c.FechaFinExentoIngresosBrutos,
						 FechaBaja = c.FechaBaja,
						 ExentoSellos = c.ExentoSellos,
						 AjustePorInflacion = c.AjustePorInflacion,
						 FormaDePago = c.FormaDePago,
						 NumeroDeCuenta = c.NumeroDeCuenta,
						 CBU = c.CBU,
						 TipoDeCuenta = c.TipoDeCuenta,
						 FechaAlta = c.FechaAlta,
						 FechaModifica = c.FechaModifica,
						 UsuarioAlta = c.UsuarioAlta,
						 UsuarioBaja = c.UsuarioBaja,
						 UsuarioModifica = c.UsuarioModifica,
					};
			return (DbQuery<ProveedoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
