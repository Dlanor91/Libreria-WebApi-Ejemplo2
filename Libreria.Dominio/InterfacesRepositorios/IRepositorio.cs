using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;

namespace Libreria.Dominio.InterfacesRepositorios
{
	public interface IRepositorio<T> where T:class
	{
		public bool Add(T obj);
		public bool Remove(object Clave);
		public bool Update(T obj);
		public T FindById(int id);
		public IEnumerable<T> FindAll();

	}
}
