using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;

namespace Libreria.Dominio.InterfacesRepositorios
{
	public interface IRepositorioAutor
		:IRepositorio<Autor>
	{
		public IEnumerable<Autor> GetAutoresNacionalidad(string nacionalidad);
		public IEnumerable<Autor> GetAutoresNombreIncluye(string textoBuscado);

	}
}
