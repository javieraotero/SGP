
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
    public partial class ExpedientesadmAD
    {
        private BDEntities db = new BDEntities();

        public Expedientesadm ObtenerPorId(int Id)
        {
            return db.Expedientesadm.Single(c => c.Id == Id);
        }

        public Expedientesadm ObtenerPorNumero(string numero)
        {
            return db.Expedientesadm.Where(c => c.Numero == numero).FirstOrDefault();
        }

        public DbQuery<Expedientesadm> ObtenerTodo()
        {
            return (DbQuery<Expedientesadm>)db.Expedientesadm;
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
        {
            var res = from x in db.Expedientesadm
                      where x.Numero.Contains(filtro) && !x.Archivado
                      select new SelectOptionsView { text = x.Numero, value = x.Id };
            return (DbQuery<SelectOptionsView>)res;
        }

        public DbQuery<ExpedientesadmView> ObtenerParaGrilla()
        {
            var x = from c in db.Expedientesadm
                    where !c.Archivado
                    select new ExpedientesadmView
                    {
                        Id = c.Id,
                        Numero = c.Numero,
                        Fecha = c.Fecha,
                        Caratula = c.Caratula
                    };
            return (DbQuery<ExpedientesadmView>)x;
        }

        public DbQuery<ExpedientesadmView> ObtenerParaGrillaArchivados()
        {
            var x = from c in db.Expedientesadm
                    where c.Archivado
                    select new ExpedientesadmView
                    {
                        Id = c.Id,
                        Numero = c.Numero,
                        Fecha = c.Fecha,
                        Caratula = c.Caratula
                    };
            return (DbQuery<ExpedientesadmView>)x;
        }

        public DbQuery<ExpedientesContablesView> ObtenerExpedientesContables()
        {
            var x = from c in db.Expedientesadm
                    where !c.Archivado
                    select new ExpedientesContablesView
                    {
                        Id = c.Id,
                        Numero = c.Numero,
                        Fecha = c.Fecha,
                        Caratula = c.Caratula,
                        Facturas = (c.Facturas.Count() > 0) ? "S" : "N",
                        Asignado = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 1 select i.Id).Count() > 0 ? "S" : "N",
                        Afectado = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 2 select i.Id).Count() > 0 ? "S" : "N",
                        OrdenadoAPagr = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 4 select i.Id).Count() > 0 ? "S" : "N",
                    };
            return (DbQuery<ExpedientesContablesView>)x;
        }

        public DbQuery<ExpedientesContablesView> ObtenerExpedientesSinAsignar()
        {
            var x = from c in db.Expedientesadm
                    where (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 1 select i.Id).Count() == 0
                    && !c.Archivado
                    select new ExpedientesContablesView
                    {
                        Id = c.Id,
                        Numero = c.Numero,
                        Fecha = c.Fecha,
                        Caratula = c.Caratula,
                        Facturas = (c.Facturas.Count() > 0) ? "S" : "N",
                        Asignado = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 1 select i.Id).Count() > 0 ? "S" : "N",
                        Afectado = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 2 select i.Id).Count() > 0 ? "S" : "N",
                        OrdenadoAPagr = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 4 select i.Id).Count() > 0 ? "S" : "N",
                    };
            return (DbQuery<ExpedientesContablesView>)x;
        }

        public DbQuery<ExpedientesContablesView> ObtenerExpedientesConCargoPendiente(int organismo)
        {
            var x = from c in db.Expedientesadm
                    where c.Actuacionesadm.Any(a=>a.OrganismoCargo == organismo && !a.FechaCargo.HasValue) && !c.Archivado
                    select new ExpedientesContablesView
                    {
                        Id = c.Id,
                        Numero = c.Numero,
                        Fecha = c.Fecha,
                        Caratula = c.Caratula,
                        Facturas = (c.Facturas.Count() > 0) ? "S" : "N",
                        Asignado = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 1 select i.Id).Count() > 0 ? "S" : "N",
                        Afectado = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 2 select i.Id).Count() > 0 ? "S" : "N",
                        OrdenadoAPagr = (from i in db.ImputacionesContables where i.ExpedienteAImputar == c.Id && i.Operacion == 4 select i.Id).Count() > 0 ? "S" : "N",
                    };
            return (DbQuery<ExpedientesContablesView>)x;
        }

        public void Guardar(Expedientesadm Objeto)
        {
            try
            {
                db.Expedientesadm.Add(Objeto);
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }

        public void Actualizar(Expedientesadm Objeto)
        {
            try
            {
                db.Expedientesadm.Attach(Objeto);
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
                Expedientesadm Objeto = this.ObtenerPorId(IdObjeto);
                db.Expedientesadm.Remove(Objeto);
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

        public DbQuery<ExpedientesadmViewT> JsonT(string term)
        {
            var x = from c in db.Expedientesadm
                    select new ExpedientesadmViewT
                    {
                        Id = c.Id,
                        Tipo = c.Tipo,
                        Categoria = c.Categoria,
                        Numero = c.Numero,
                        NumeroDeTramite = c.NumeroDeTramite,
                        NumeroDeCorresponde = c.NumeroDeCorresponde,
                        FechaDeAlta = c.FechaDeAlta,
                        Fecha = c.Fecha,
                        UsuarioAlta = c.UsuarioAlta,
                        UsuarioBaja = c.UsuarioBaja,
                        FechaDeBaja = c.FechaDeBaja,
                        Caratula = c.Caratula,
                        OrganismoIniciador = c.OrganismoIniciador,
                        TextoIniciador = c.TextoIniciador,
                        ExpedienteAcumulado = c.ExpedienteAcumulado,
                        FechaAcumulado = c.FechaAcumulado,
                        UsuarioAcumulado = c.UsuarioAcumulado,
                        ExpedientePadre = c.ExpedientePadre,
                        UltimoCorresponde = c.UltimoCorresponde,
                        Archivado = c.Archivado,
                        FechaArchivado = c.FechaArchivado,
                        UsuarioArchiva = c.UsuarioArchiva,
                        AnioContable = c.AnioContable,
                    };
            return (DbQuery<ExpedientesadmViewT>)x;
        }
        /*********************************************
		* Seccion Particular
		* *******************************************/

        public int poroximoCorresponde(int expediente)
        {

            var proximo = (from x in db.Expedientesadm
                           where x.Id == expediente
                           select x).Single().UltimoCorresponde + 1;

            return proximo;
        }

        public DbQuery<ImputacionesContablesDetalle> obtenerAsignacion(int expediente)
        {

            var res = from x in db.ImputacionesContablesDetalle
                      where x.ImputacionContables.ExpedienteAImputar == expediente && x.ImputacionContables.Operacion == (int)eOperacionesContables.Asignacion
                      && x.FechaElimina == null
                      select x;

            return (DbQuery<ImputacionesContablesDetalle>)res;

        }

        public DbQuery<ImputacionesContablesDetalle> obtenerImputacionCompromiso(int expediente)
        {

            var res = from x in db.ImputacionesContablesDetalle
                      where x.ImputacionContables.ExpedienteAImputar == expediente && x.ImputacionContables.Operacion == (int)eOperacionesContables.Compromiso
                      && x.FechaElimina == null
                      select x;

            return (DbQuery<ImputacionesContablesDetalle>)res;

        }

        public DbQuery<ImputacionesContablesDetalle> obtenerImputacionOrdenadoAPagar(int expediente)
        {

            var res = from x in db.ImputacionesContablesDetalle
                      where x.ImputacionContables.ExpedienteAImputar == expediente && x.ImputacionContables.Operacion == (int)eOperacionesContables.OrdenadoAPagar
                      && x.FechaElimina == null
                      select x;

            return (DbQuery<ImputacionesContablesDetalle>)res;

        }

        public DbQuery<CustomImputacionJ> obtenerAfectaciones(int expediente)
        {

            var res = from x in db.ImputacionesContablesDetalle
                      where x.ImputacionContables.ExpedienteAImputar == expediente && (x.ImputacionContables.Operacion == (int)eOperacionesContables.Afectacion || x.ImputacionContables.Operacion == (int)eOperacionesContables.Desafectacion || x.ImputacionContables.Operacion == (int)eOperacionesContables.SobreAfectacion)
                      && x.FechaElimina == null
                      select new CustomImputacionJ
                      {
                          Descripcion = x.Partidas.Descripcion,
                          Partida = x.Partida,
                          Division = x.Division,
                          Importe = x.ImputacionContables.Operacion == (int)eOperacionesContables.Desafectacion ? x.Importe*(-1) : x.Importe
                      };

            var res2 = from x in res
                      group x by new { x.Partida, x.Division, x.Descripcion } into g
                       select new CustomImputacionJ
                       {
                           Descripcion = g.Key.Descripcion,
                           Partida = g.Key.Partida,
                          Division = g.Key.Division,
                          Importe = g.Sum(_ => _.Importe)
                      };

            return (DbQuery<CustomImputacionJ>)res2;

        }

        public DbQuery<CustomImputacionJ> obtenerOrdenadosAPagar(int expediente)
        {

            var res = from x in db.ImputacionesContablesDetalle
                      where x.ImputacionContables.ExpedienteAImputar == expediente && x.ImputacionContables.Operacion == (int)eOperacionesContables.OrdenadoAPagar
                      && x.FechaElimina == null
                      select new CustomImputacionJ
                      {
                          Descripcion = x.Partidas.Descripcion,
                          Partida = x.Partida,
                          Division = x.Division,
                          Importe = x.Importe
                      };

            var res2 = from x in res
                       group x by new { x.Partida, x.Division, x.Descripcion } into g
                       select new CustomImputacionJ
                       {
                           Descripcion = g.Key.Descripcion,
                           Partida = g.Key.Partida,
                           Division = g.Key.Division,
                           Importe = g.Sum(_ => _.Importe)
                       };

            return (DbQuery<CustomImputacionJ>)res2;

        }

        public ExpedientesClientModel obtenerModeloCliente(int expediente)
        {

            var res = (from x in db.Expedientesadm
                       where x.Id == expediente
                       select new ExpedientesClientModel
                       {
                           id = expediente,
                           fecha = x.Fecha,
                           caratula = x.Caratula,
                           numero = x.Numero,
                           facturas = (from f in db.Facturas
                                       where f.Expediente == expediente
                                       select new FacturasClient
                                       {
                                           id = f.Id,
                                           fecha = f.Fecha,
                                           concepto = f.Descripcion,
                                           importe = f.Importe,
                                           numero = f.NumeroDeFactura,
                                           nombre_proveedor = f.Proveedors.Nombre
                                       }),
                           iniciador = x.OrganismoIniciadors.Descripcion,
                           imputaciones = (from i in db.ImputacionesContables
                                           where i.ExpedienteAImputar == expediente
                                           select new ImputacionContableClient
                                           {
                                               fecha = i.Fecha,
                                               operacion = i.Operacion,
                                               id = i.Id,
                                               total = (from di in i.ImputacionesContablesDetalle
                                                        select new DetalleImputacionClient()
                                                        {
                                                            division = di.Divisions.Nombre,
                                                            partida = di.Partidas.Mnemo,
                                                            numero_partida = di.Partidas.NumeroDePartida,
                                                            nombre_partida = di.Partidas.Descripcion,
                                                            importe = di.Importe,
                                                            id = di.Id
                                                        }).Sum(f=>f.importe),
                                               //total_en_letras = (from f in db.Facturas
                                               //                   where f.Imputacion == i.Id
                                               //                   select new FacturasClient
                                               //                   {
                                               //                       id = f.Id,
                                               //                       fecha = f.Fecha,
                                               //                       concepto = f.Descripcion,
                                               //                       importe = f.Importe,
                                               //                       numero = f.NumeroDeFactura,
                                               //                       nombre_proveedor = f.Proveedors.Nombre
                                               //                   })
                                               facturas = (from f in db.Facturas
                                                           where f.Imputacion == i.Id
                                                           select new FacturasClient
                                                           {
                                                               id = f.Id,
                                                               fecha = f.Fecha,
                                                               concepto = f.Descripcion,
                                                               importe = f.Importe,
                                                               numero = f.NumeroDeFactura,
                                                               nombre_proveedor = f.Proveedors.Nombre
                                                           }),
                                               detalle = (from di in db.ImputacionesContablesDetalle
                                                          where di.ImputacionContable == i.Id
                                                          select new DetalleImputacionClient()
                                                          {
                                                              division = di.Divisions.Nombre,
                                                              partida = di.Partidas.Mnemo,
                                                              numero_partida = di.Partidas.NumeroDePartida,
                                                              nombre_partida = di.Partidas.Descripcion,
                                                              importe = di.Importe,
                                                              id = di.Id
                                                          })
                                           })
                       }).FirstOrDefault();

            //var z = from x in db.ImputacionesContablesDetalle
            //        where x.ImputacionContable == 16
            //        select x;


            return (ExpedientesClientModel)res;

        }

        public ExpedientesClientModel obtenerModeloCliente(int expediente, int imputacion)
        {

            var res = (from x in db.Expedientesadm
                       where x.Id == expediente
                       select new ExpedientesClientModel
                       {
                           id = expediente,
                           fecha = x.Fecha,
                           caratula = x.Caratula,
                           numero = x.Numero,
                           facturas = (from f in db.Facturas
                                       where f.Expediente == expediente
                                       select new FacturasClient
                                       {
                                           id = f.Id,
                                           fecha = f.Fecha,
                                           concepto = f.Descripcion,
                                           importe = f.Importe,
                                           numero = f.NumeroDeFactura,
                                           nombre_proveedor = f.Proveedors.Nombre
                                       }),
                           iniciador = x.OrganismoIniciadors.Descripcion,
                           imputaciones = (from i in db.ImputacionesContables
                                           where i.ExpedienteAImputar == expediente && i.Id == imputacion
                                           select new ImputacionContableClient
                                           {
                                               fecha = i.Fecha,
                                               operacion = i.Operacion,
                                               id = i.Id,
                                               anio_contable = i.Fecha.Year,    
                                               total = (from di in i.ImputacionesContablesDetalle
                                                        select new DetalleImputacionClient()
                                                        {
                                                            division = di.Divisions.Nombre,
                                                            partida = di.Partidas.Mnemo,
                                                            numero_partida = di.Partidas.NumeroDePartida,
                                                            nombre_partida = di.Partidas.Descripcion,
                                                            importe = di.Importe,
                                                            id = di.Id
                                                        }).Sum(f => f.importe),
                                               //total_en_letras = (from f in db.Facturas
                                               //                   where f.Imputacion == i.Id
                                               //                   select new FacturasClient
                                               //                   {
                                               //                       id = f.Id,
                                               //                       fecha = f.Fecha,
                                               //                       concepto = f.Descripcion,
                                               //                       importe = f.Importe,
                                               //                       numero = f.NumeroDeFactura,
                                               //                       nombre_proveedor = f.Proveedors.Nombre
                                               //                   })
                                               facturas = (from f in db.Facturas
                                                           where f.Imputacion == i.Id
                                                           select new FacturasClient
                                                           {
                                                               id = f.Id,
                                                               fecha = f.Fecha,
                                                               concepto = f.Descripcion,
                                                               importe = f.Importe,
                                                               numero = f.NumeroDeFactura,
                                                               nombre_proveedor = f.Proveedors.Nombre
                                                           }),
                                               detalle = (from di in db.ImputacionesContablesDetalle
                                                          where di.ImputacionContable == i.Id
                                                          select new DetalleImputacionClient()
                                                          {
                                                              division = di.Divisions.Nombre,
                                                              partida = di.Partidas.Mnemo,
                                                              numero_partida = di.Partidas.NumeroDePartida,
                                                              nombre_partida = di.Partidas.Descripcion,
                                                              importe = di.Importe,
                                                              id = di.Id
                                                          })
                                           })
                       }).FirstOrDefault();

            //var z = from x in db.ImputacionesContablesDetalle
            //        where x.ImputacionContable == 16
            //        select x;


            return (ExpedientesClientModel)res;

        }

    }

    public class Conversor
    {
        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try

            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }

    }

}
