using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entidades
{
    public class Biblioteca
    {
        public List<Libro> _libros;

        public Biblioteca()
        {
            _libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
        }

        public void PrestarLibro(string titulo)
        {
            var libro = _libros.Find(l => l.Titulo == titulo);
            if (libro == null)
                throw new InvalidOperationException("El libro no se encuentra en la biblioteca.");

            libro.Prestar();
        }

        public void DevolverLibro(string titulo)
        {
            var libro = _libros.Find(l => l.Titulo == titulo);
            if (libro == null)
                throw new InvalidOperationException("El libro no se encuentra en la biblioteca.");

            libro.Devolver();
        }

        public List<Libro> ObtenerLibros()
        {
            return _libros;
        }
    }
}
