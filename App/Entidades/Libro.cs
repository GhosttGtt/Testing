using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entidades
{
    public class Libro
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public bool EstaPrestado { get; private set; }

        public Libro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
            EstaPrestado = false;
        }

        public void Prestar()
        {
            if (EstaPrestado)
                throw new InvalidOperationException("El libro ya está prestado.");

            EstaPrestado = true;
        }

        public void Devolver()
        {
            if (!EstaPrestado)
                throw new InvalidOperationException("El libro no está prestado.");

            EstaPrestado = false;
        }
    }
}
