using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;
using Libreria.Dominio.InterfacesRepositorios;
using Libreria.AccesoDatos.EF;
using System.Linq;

namespace Libreria.AccesoDatos.EF
{
	public class RepositorioAutor : IRepositorioAutor
	{
        public LibreriaContext Contexto { get; set; }
        
		public RepositorioAutor(LibreriaContext db)
		{
			Contexto = db;
		}
		public bool Add(Autor nuevoAutor)
		{
			bool ok = false;
            try
            {
                if (nuevoAutor == null || !nuevoAutor.Validar())
                    return false;
                Contexto.Add(nuevoAutor);
                Contexto.SaveChanges();
                ok = true;
            }
            catch
            {
                throw;
            }

			return ok;
		}

		public IEnumerable<Autor> FindAll()
		{
			return Contexto.Autores.ToList();
		}		

		public IEnumerable<Autor> GetAutoresNacionalidad(string nacionalidad)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Autor> GetAutoresNombreIncluye(string textoBuscado)
		{
			throw new NotImplementedException();
		}

		public bool Remove(object clave)
		{
			bool ok = false;
			try
			{
				Autor a = Contexto.Autores.Find((int)clave);
				if (a == null) return false;
				Contexto.Autores.Remove(a);
				ok = Contexto.SaveChanges() == 1;
			}
			catch 
			{
				throw;
			}

			return ok;
		}

		public bool Update(Autor autor)
		{
			bool ok = false;
			if (autor != null && autor.Validar() == true)
            {
				try
				{
					Contexto.Update(autor);
					/*Contexto.Entry(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;*/
					Contexto.SaveChanges();
					ok = true;
				}
				catch
				{
					throw;
				}
			}

			return ok;
		}

        public Autor FindById(int id)
        {
			return Contexto.Autores.Find(id); 
        }
    }
}
