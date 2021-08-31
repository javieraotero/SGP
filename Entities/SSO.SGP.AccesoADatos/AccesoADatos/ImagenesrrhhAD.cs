
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
	public partial class ImagenesrrhhAD
	{
		private BDEntities db = new BDEntities();

		public Imagenesrrhh ObtenerPorId(int Id)
		{
			return db.Imagenesrrhh.Single(c => c.Id == Id);
		}

		public DbQuery<Imagenesrrhh> ObtenerTodo()
		{
			return (DbQuery<Imagenesrrhh>)db.Imagenesrrhh;
		}

        public List<Imagenesrrhh> ObtenerPorAgente(int id)
        {            
            return (db.Imagenesrrhh.Where(x=>x.Agente == id)).ToList();
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Imagenesrrhh
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ImagenesrrhhView> ObtenerParaGrilla(int id)
		{
			var x = from c in db.Imagenesrrhh
                    where c.Agente == id
					select new ImagenesrrhhView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Categoria = c.Categoria,
						 FechaDeCarga = c.FechaDeCarga,						
						 Imagen = c.Imagen,		
                         Descripcion = c.Descripcion				 
					};
			return (DbQuery<ImagenesrrhhView>)x;
		}

		public void Guardar(Imagenesrrhh Objeto)
		{
			try
			{
				db.Imagenesrrhh.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Imagenesrrhh Objeto)
		{
			try
			{
				db.Imagenesrrhh.Attach(Objeto);
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
				Imagenesrrhh Objeto = this.ObtenerPorId(IdObjeto);
				db.Imagenesrrhh.Remove(Objeto);
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

		public DbQuery<ImagenesrrhhViewT> JsonT(string term)
		{
			var x = from c in db.Imagenesrrhh
					select new ImagenesrrhhViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Categoria = c.Categoria,
						 FechaDeCarga = c.FechaDeCarga,
						 FechaUltimaActualizacion = c.FechaUltimaActualizacion,
						 Usuario = c.Usuario,
						 Agente = c.Agente,
						 Imagen = c.Imagen,
						 Firma = c.Firma,
					};
			return (DbQuery<ImagenesrrhhViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
