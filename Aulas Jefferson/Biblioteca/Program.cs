namespace Biblioteca;

class Program
{
	static void Main(string[] args)
	{
		Biblioteca biblioteca= new Biblioteca();
		
		// adicionar cliente
		biblioteca.clientes.Add(new Cliente("Jorge e Mateus", "62999999",
		01, 01, 1980));
		
		// adicionar livro
		biblioteca.livros.Add(new Livro("Dom Casmurro", 
		"Machado de Assis"));

		biblioteca.livros[0].MostrarLivro();

		biblioteca.clientes[0].MostrarCliente();
		
		// Emprestar livro
		biblioteca.EmprestarLivro(1, 1);
		biblioteca.DevolverLivro(1, 1);
		biblioteca.EmprestarLivro(1, 2);
		
		/*static void IniciarBiblioteca(Biblioteca biblioteca)
		{
			biblioteca.EmprestarLivro(2,2);
		}*/
	}
}
