
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Data.Objects;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class FacturasAD
	{
		private BDEntities db = new BDEntities();

		public Facturas ObtenerPorId(int Id)
		{
			return db.Facturas.Single(c => c.Id == Id);
		}

		public DbQuery<Facturas> ObtenerTodo()
		{
			return (DbQuery<Facturas>)db.Facturas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Facturas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FacturasDetalleView> ObtenerParaGrilla()
		{
			var x = from c in db.Facturas
                    where c.FechaElimina == null
					select new FacturasDetalleView
                    {
						 Id = c.Id,
						 NumeroDeFactura = c.NumeroDeFactura,
						 IdentificacionDeFactura = c.IdentificacionDeFactura,
						 //Tipo = c.Tipo,
                         Concepto = c.Descripcion,
                         Organismo = c.Organismos.Descripcion,
						 Expediente = c.Expedientes.Numero,
						 Proveedor = c.Proveedors.Nombre,
						 Fecha = c.Fecha,
						 Importe = c.Importe,				
					};
			return (DbQuery<FacturasDetalleView>)x;
		}

        public DbQuery<FacturasView> FacturasSinExpediente()
        {
            var x = from c in db.Facturas
                    where c.FechaElimina == null && !c.Expediente.HasValue
                    select new FacturasView
                    {
                        Id = c.Id,
                        NumeroDeFactura = c.NumeroDeFactura,
                        IdentificacionDeFactura = c.IdentificacionDeFactura,
                        Tipo = c.Tipo,
                        Expediente = c.Expedientes.Numero,
                        Proveedor = c.Proveedors.Nombre,
                        Fecha = c.Fecha,
                        Importe = c.Importe,
                    };
            return (DbQuery<FacturasView>)x;
        }

        public DbQuery<Facturas> FacturasSinExpedienteJson()
        {
            var x = from c in db.Facturas
                    where c.FechaElimina == null && !c.Expediente.HasValue
                    select c;
                    
            return (DbQuery<Facturas>)x;
        }

        public List<FacturasCustom> FacturasSinExpedienteJson2()
        {
            var facturas = (from c in db.Facturas
                    where c.FechaElimina == null && !c.Expediente.HasValue
                    select new FacturasCustom {
                       Id = c.Id,
                       Proveedor = c.Proveedors.RazonSocial,
                       Importe = c.Importe,
                       Fecha = c.Fecha,
                       Numero = c.NumeroDeFactura,
                       Descripcion = c.Descripcion,
                       Identificador = c.IdentificacionDeFactura
                    }).ToList();

            foreach (var f in facturas) {
                var a = (from x in db.FacturasImputadasDetalle
                         where x.FacturaImputadas.Factura == f.Id 
                         select new AsignacionCustom
                         {
                            Numero = x.Partidas.NumeroDePartida,
                            Partida = x.Partidas.NumeroDePartida + "-" + x.Partidas.Descripcion,
                            Importe = x.Importe
                        }).ToList();
                if (a.Count() > 0)
                    f.Asignacion = a;
            }

            return facturas;
        }

        public DbQuery<FacturasView> FacturasSinAsignar()
        {
            var x = from c in db.Facturas
                    where c.FechaElimina == null
                    && !c.EstaAsignada 
                    select new FacturasView
                    {
                        Id = c.Id,
                        NumeroDeFactura = c.NumeroDeFactura,
                        IdentificacionDeFactura = c.IdentificacionDeFactura,
                        Tipo = c.Tipo,
                        Expediente = c.Expedientes.Numero,
                        Proveedor = c.Proveedors.Nombre,
                        Fecha = c.Fecha,
                        Importe = c.Importe,
                    };
            return (DbQuery<FacturasView>)x;
        }

        public DbQuery<FacturasView> FacturasAfectadasSinOrdenDePago()
        {
            var x = from c in db.Facturas
                    where c.FechaElimina == null
                    && c.EstaAsignada
                    && !c.OrdenadoAPagar
                    select new FacturasView
                    {
                        Id = c.Id,
                        NumeroDeFactura = c.NumeroDeFactura,
                        IdentificacionDeFactura = c.IdentificacionDeFactura,
                        Tipo = c.Tipo,
                        Expediente = c.Expedientes.Numero,
                        Proveedor = c.Proveedors.Nombre,
                        Fecha = c.Fecha,
                        Importe = c.Importe,
                    };
            return (DbQuery<FacturasView>)x;
        }

        //public List<CustomImputacion> DetalleDePartidasSinAfectar(int expediente)
        //{

        //    var fid = from c in db.FacturasImputadasDetalle
        //              where c.FacturaImputadas.Facturas.Expediente == expediente
        //             && !c.FacturaImputadas.Facturas.FechaElimina.HasValue
        //             && !c.FacturaImputadas.Facturas.Afectada
        //             && c.FacturaImputadas.Facturas.EstaAsignada
        //              select new CustomImputacion 
        //              {
        //                  Partida = c.Partida,
        //                  Importe = c.Importe,
        //                  Division = c.Division
        //              };



        //    return (List<CustomImputacion>)fid;
        //}

        public DbQuery<FacturasView> FacturasDeExpediente(int expediente)
        {
            var x = from c in db.Facturas
                    where c.FechaElimina != null && c.Expediente == expediente
                    select new FacturasView
                    {
                        Id = c.Id,
                        NumeroDeFactura = c.NumeroDeFactura,
                        IdentificacionDeFactura = c.IdentificacionDeFactura,
                        Tipo = c.Tipo,
                        Expediente = c.Expedientes.Numero,
                        Proveedor = c.Proveedors.Nombre,
                        Fecha = c.Fecha,
                        Importe = c.Importe,
                    };
            return (DbQuery<FacturasView>)x;
        }

		public void Guardar(Facturas Objeto)
		{
			try
			{
				db.Facturas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Facturas Objeto)
		{
			try
			{
				db.Facturas.Attach(Objeto);
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
				Facturas Objeto = this.ObtenerPorId(IdObjeto);
				db.Facturas.Remove(Objeto);
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

		public DbQuery<FacturasViewT> JsonT(string term)
		{
			var x = from c in db.Facturas
					select new FacturasViewT
					{
						 Id = c.Id,
						 NumeroDeFactura = c.NumeroDeFactura,
						 IdentificacionDeFactura = c.IdentificacionDeFactura,
						 Tipo = c.Tipo,
						 Expediente = c.Expediente,
						 Proveedor = c.Proveedors.Nombre,
						 Fecha = c.Fecha,
						 Descripcion = c.Descripcion,
						 Importe = c.Importe
					};
			return (DbQuery<FacturasViewT>)x;
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/
        public DbQuery<FacturasImputadas> ObtenerAsignacion(int id)
        {
            var res = from x in db.FacturasImputadas
                      where x.Factura == id && !x.FechaElimina.HasValue 
                      select x;
            return (DbQuery<FacturasImputadas>)res;
        }

        public DbQuery<FacturasImputadasDetalle> AsignacionPendiente(int expediente)
        {
            var res = from x in db.FacturasImputadasDetalle
                      where x.FacturaImputadas.Facturas.Expediente == expediente
                      && x.FacturaImputadas.Facturas.FechaElimina == null
                      && !x.FacturaImputadas.Facturas.Afectada
                      && x.FacturaImputadas.Facturas.EstaAsignada && !x.FacturaImputadas.FechaElimina.HasValue
                      select x;

            return (DbQuery<FacturasImputadasDetalle>)res;
        }

        public DbQuery<FacturasView> FacturasSinAfectar(int expediente)
        {
            var x = from c in db.Facturas
                    where !c.FechaElimina.HasValue && c.Expediente == expediente && !c.Afectada 
                    select new FacturasView
                    {
                        Id = c.Id,
                        NumeroDeFactura = c.NumeroDeFactura,
                        IdentificacionDeFactura = c.IdentificacionDeFactura,
                        Tipo = c.Tipo,
                        Expediente = c.Expedientes.Numero,
                        Proveedor = c.Proveedors.Nombre,
                        Fecha = c.Fecha,
                        Importe = c.Importe
                    };
            return (DbQuery<FacturasView>)x;
        }

        public DbQuery<FacturasView> FacturasSinOrdenDePago(int expediente)
        {
            var x = from c in db.Facturas
                    where !c.FechaElimina.HasValue && c.Expediente == expediente && !c.OrdenadoAPagar
                    select new FacturasView
                    {
                        Id = c.Id,
                        NumeroDeFactura = c.NumeroDeFactura,
                        IdentificacionDeFactura = c.IdentificacionDeFactura,
                        Tipo = c.Tipo,
                        Expediente = c.Expedientes.Numero,
                        Proveedor = c.Proveedors.Nombre,
                        Fecha = c.Fecha,
                        Importe = c.Importe
                    };
            return (DbQuery<FacturasView>)x;
        }

    }
}
