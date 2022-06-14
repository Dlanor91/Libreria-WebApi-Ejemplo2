using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Libreria.Dominio.EntidadesNegocio;

namespace Libreria.AccesoDatos.EF
{
	public class LibreriaContext:DbContext
	{
 
		public DbSet<Autor> Autores{ get; set; }


		/// <summary>
		/// Constructor necesario para inyectar la dependencia a LibreriaContext
		/// </summary>
		/// <param name="options">Opciones de configuración del contexto. Las configura el framework</param>
		public LibreriaContext(DbContextOptions<LibreriaContext> options)
			:base(options)
		{
			 
		}
	}
}
