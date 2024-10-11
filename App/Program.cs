using App.Entidades;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            // Agregar libros a la biblioteca
            biblioteca.AgregarLibro(new Libro("1984", "George Orwell"));
            biblioteca.AgregarLibro(new Libro("El Principito", "Antoine de Saint-Exupéry"));

            // Prestar un libro
            try
            {
                biblioteca.PrestarLibro("1984");
                Console.WriteLine("Libro '1984' prestado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Intentar prestar el mismo libro nuevamente
            try
            {
                biblioteca.PrestarLibro("1984");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Debería indicar que el libro ya está prestado.
            }

            // Devolver el libro
            try
            {
                biblioteca.DevolverLibro("1984");
                Console.WriteLine("Libro '1984' devuelto con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Mostrar todos los libros en la biblioteca
            foreach (var libro in biblioteca.ObtenerLibros())
            {
                Console.WriteLine($"Título: {libro.Titulo}, Autor: {libro.Autor}, Prestado: {libro.EstaPrestado}");
            }
        }
    }
}
