namespace Biblioteca;

class Program
{
	static void Main(string[] args)
	{
		Biblioteca biblioteca= new Biblioteca();
		
		// adicionar cliente
		biblioteca.AdicionarCliente("Jorge e Mateus", "62999999",
		01, 01, 1980);
		
		// adicionar livro
		biblioteca.AdicionarLivro("Dom Casmurro", 
		"Machado de Assis");

		biblioteca.MostrarLivro(1);

		biblioteca.MostrarCliente(1);
		
		// Emprestar livro
		biblioteca.EmprestarLivro(1, 1);
		biblioteca.DevolverLivro(1, 1);
		biblioteca.EmprestarLivro(1, 2);
		
	}
}
