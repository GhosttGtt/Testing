using App.Entidades;

namespace Tests
{
    public class Tests
    {
        private Biblioteca _biblioteca;
        private Libro _libro1;
        private Libro _libro2;

        [SetUp]
        public void Setup()
        {
            _biblioteca = new Biblioteca();
            _libro1 = new Libro("1984", "George Orwell");
            _libro2 = new Libro("El Principito", "Antoine de Saint-Exupéry");
            _biblioteca.AgregarLibro(_libro1);
            _biblioteca.AgregarLibro(_libro2);
        }

        [Test(Author = "Alexander Cheguen", Description = "Prestar libro disponible correctamente")]
        public void PrestarLibro_LibroDisponible_PrestaLibroCorrectamente()
        {
            // Act
            _biblioteca.PrestarLibro("1984");

            // Assert
            Assert.That(_biblioteca._libros.Count, Is.EqualTo(2));
            Assert.That(_biblioteca._libros[0].Titulo, Is.EqualTo("1984"));
            Assert.That(_biblioteca._libros[0].EstaPrestado, Is.EqualTo(true));
            Assert.That(_biblioteca._libros[1].EstaPrestado, Is.EqualTo(false));
        }

        [Test(Author = "Alexander Cheguen", Description = "Prestar libro no disponible")]
        public void PrestarLibro_LibroNoDisponible_LanzaExcepcion()
        {

            //Arrange
            _biblioteca.PrestarLibro("El Principito");

            // Act

            var Prestado = Assert.Throws<InvalidOperationException>(() => _biblioteca.PrestarLibro("El Principito"));


            // Assert

            Assert.That(Prestado.Message, Is.EqualTo("El libro ya está prestado."));
        }

        [Test(Author = "Alexander Cheguen", Description = "Devolver Libro Prestado correctamente")]
        public void DevolverLibro_LibroPrestado_DevolveLibroCorrectamente()
        {
            //Arrange
            _biblioteca.PrestarLibro("El Principito");

            // Act
            _biblioteca.DevolverLibro("El Principito");

            // Assert
            Assert.That(_biblioteca._libros[0].EstaPrestado, Is.EqualTo(false));
        }

        [Test(Author = "Alexander Cheguen", Description = "Devolver Libro No Prestado")]
        public void DevolverLibro_LibroNoPrestado_LanzaExcepcion()
        {
            
            // Act
            var DevolverLibroNoPrestado = Assert.Throws<InvalidOperationException>(() => _biblioteca.DevolverLibro("El Principito"));

            // Assert

            Assert.That(DevolverLibroNoPrestado.Message, Is.EqualTo("El libro no está prestado."));
        }

        [Test(Author = "Alexander Cheguen", Description = "Retornar Lista de Libros")]
        public void ObtenerLibros_RetornaListaDeLibros()
        {

            // Act

            List<Libro> libros = _biblioteca.ObtenerLibros();

            //Asert
           
            Assert.That(libros, Is.EqualTo(new List<Libro> { _libro1, _libro2 }));
            Assert.That(libros, Is.EquivalentTo(new List<Libro> { _libro2, _libro1 }));
            Assert.That(libros, Has.Exactly(2).Items);
            Assert.That(libros[0].Titulo, Is.EqualTo("1984"));

        }
    }
}