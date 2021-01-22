using Microsoft.EntityFrameworkCore;
using Primer_Registro_Aplicada1.DAL;
using Primer_Registro_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Primer_Registro_Aplicada1.BLL
{
   public class RolesBLL
    {
        public static bool Guardar(Roles rol)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Roles.Add(rol) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Roles rol)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(rol).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Roles.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Roles Buscar(int id)
        {
            Contexto db = new Contexto();
            Roles rol = new Roles();
            try
            {
                rol = db.Roles.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return rol;
        }

        public static List<Roles> GetList(Expression<Func<Roles, bool>> evaluacion)
        {
            var lista = new List<Roles>();
            var db = new Contexto();
            try
            {
                lista = db.Roles.Where(evaluacion).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
