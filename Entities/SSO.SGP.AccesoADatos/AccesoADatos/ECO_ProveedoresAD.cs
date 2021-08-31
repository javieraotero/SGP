
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ECO_ProveedoresAD
	{
		private BDEntities db = new BDEntities();

		public ECO_Proveedores ObtenerPorId(int Id)
		{
			return db.ECO_Proveedores.Single(c => c.Id == Id);
		}

		public ECO_Proveedores ObtenerPorCUIT(string cuit)
		{

			return db.ECO_Proveedores.Where(c => c.CUIT == cuit.Trim()).FirstOrDefault();
		}

		public DbQuery<ECO_ProveedoresView> ObtenerProveedoresxIdUsuarioView(int id)
        {
            try
            {
				var res = from x in db.ECO_Proveedores
						  where x.IdUsuario == id
						  select new ECO_ProveedoresView
						  {
							  Id = x.Id,
							  RazonSocial = x.RazonSocial,
							  TipoProveedor = x.TipoProveedor,
							  CUIT = x.CUIT,
							  Provincia = x.Provincia,
							  Localidad = x.Localidad,
							  DomicilioElectronico = x.DomicilioElectronico,
							  DomicilioPostal = x.DomicilioPostal,
							  TelefonoMovil = x.TelefonoMovil,
							  InscriptoLaPampa = x.InscriptoLaPampa,
							  FechaAlta = x.FechaAlta,
							  IdUsuario = x.IdUsuario
						  };
				return (DbQuery<ECO_ProveedoresView>)res;
			}
			catch(Exception msg)
            {
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
        }

		public int ObtenerPorCUITSoloId(string cuit)
		{

			try
			{
				var res = (from x in db.ECO_Proveedores
						   where x.CUIT == cuit
						   select x.Id).FirstOrDefault();
				return res;
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public DbQuery<ECO_ProveedoresEconomiaView> ObtenerParaGrilla(eEstadosProveedores? estado, string razonSocial, int provincia, string cuit)
		{
			try
			{
				var res = from x in db.ECO_Proveedores
						  where ((estado.HasValue && x.Estado == estado) || !estado.HasValue)
						  && ((!string.IsNullOrEmpty(cuit) && x.CUIT.Contains(cuit)) || string.IsNullOrEmpty(cuit))
						  && ((!string.IsNullOrEmpty(razonSocial) && (x.RazonSocial.Contains(razonSocial) || x.NombreFantasia.Contains(razonSocial))) || string.IsNullOrEmpty(razonSocial))
						  orderby x.Id descending
						  select new ECO_ProveedoresEconomiaView
						  {
							  Id = x.Id,
							  RazonSocial = x.RazonSocial == "" ? x.NombreFantasia : x.RazonSocial,
							  TipoProveedor = x.TipoProveedor == eTiposProveedores.Fisica ? "<span class='badge badge-info'>Fisica</span>" : "<span class='badge badge-warning'>Juridica</span>",
							  CUIT = x.CUIT,
							  Provincia = x.Provincia_.Descripcion,
							  Localidad = x.Localidad_.Descripcion,
							  DomicilioElectronico = x.DomicilioElectronico,
							  DomicilioPostal = x.DomicilioPostal,
							  TelefonoMovil = x.TelefonoMovil,
							  InscriptoLaPampa = x.InscriptoLaPampa ? "<span class='badge badge-success'>Si</span>" : "<span class='badge badge-danger'>No</span>",
							  FechaAlta = x.FechaAlta,
							  /*Rubro = x.IdRubro.HasValue ? x.IdRubro_.Descripcion : "-",
							  SubRubro = x.IdSubRubro.HasValue ? x.IdSubRubro_.Descripcion : "-",*/
							  Estado = x.Estado == eEstadosProveedores.Pendiente ? "<span class='badge badge-warning'>Pendiente</span>" :
												x.Estado == eEstadosProveedores.Confirmado ? "<span class='badge badge-success'>Confirmado</span>" :
												x.Estado == eEstadosProveedores.Rechazado ? "<span class='badge badge-danger'>Rechazado</span>" :
												"<span class='badge badge-info'>Revisar</span>",
							  operaciones = "<a href='#' onclick='ver(this)'><img src='/assets/img/icons/16x16/detail.fw.png' />&nbsp;</a><a href='#' onclick='historial(this)'><img src='/assets/img/icons/16x16/refresh.fw.png' /></a>"
							  //operaciones = "<a href='#' onclick='ver(this)'><i class='fas fa-search' title='Ver detalles de proveedor'style='color: #797979' aria-hidden='true'></i></a>&nbsp;"
							  //operaciones = "<a href='#' onclick='ver(this)'><i class='fas fa-search' title='Ver detalles de proveedor'style='color: #797979' aria-hidden='true'></i></a>&nbsp;<a href='#' data-tipo='23' onclick='quitar(this)' title='Quitar del listado'><i class='fas fa-trash-alt' style='color: #797979' aria-hidden='true'></i></a>"
						  };
				return (DbQuery<ECO_ProveedoresEconomiaView>)res;
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public DbQuery<ECO_ProveedoresView> ObtenerPorCUITView(string cuit)
        {
			try
			{
				var res = from x in db.ECO_Proveedores
						  where x.CUIT == cuit
						  select new ECO_ProveedoresView
						  {
							  Id = x.Id,
							  RazonSocial = x.RazonSocial,
							  TipoProveedor = x.TipoProveedor,
							  CUIT = x.CUIT,
							  Provincia = x.Provincia,
							  Localidad = x.Localidad,
							  DomicilioElectronico = x.DomicilioElectronico,
							  DomicilioPostal = x.DomicilioPostal,
							  TelefonoMovil = x.TelefonoMovil,
							  InscriptoLaPampa = x.InscriptoLaPampa,
							  FechaAlta = x.FechaAlta,
							  IdUsuario = x.IdUsuario,

						  };
				return (DbQuery<ECO_ProveedoresView>)res;
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

        public DbQuery<ECO_Proveedores> ObtenerTodo()
		{
			return (DbQuery<ECO_Proveedores>)db.ECO_Proveedores;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ECO_Proveedores
					  where x.RazonSocial.Contains(filtro)
				select new SelectOptionsView {text = x.RazonSocial, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ECO_Proveedores> GetAutocomplete(string filtro)
        {
            var res = from x in db.ECO_Proveedores
					  where x.RazonSocial.Contains(filtro)
                      select x;
            return (DbQuery<ECO_Proveedores>)res;
        }


		public void Guardar(ECO_Proveedores Objeto)
		{
			try
			{
				db.ECO_Proveedores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ECO_Proveedores Objeto)
		{
			try
			{
				db.ECO_Proveedores.Attach(Objeto);
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
				ECO_Proveedores Objeto = this.ObtenerPorId(IdObjeto);
				db.ECO_Proveedores.Remove(Objeto);
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
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
