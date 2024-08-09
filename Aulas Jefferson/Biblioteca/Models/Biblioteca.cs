using System;
using System.Collections.Generic;

namespace Biblioteca;

public class Biblioteca
{
	private List<Cliente> clientes = new List<Cliente>();
	private List<Livro> livros = new List<Livro>();
	private List<Emprestimo> emprestimos = new List<Emprestimo>();
	
	public void EmprestarLivro(int idCliente, int idLivro)
	{
		Livro? livro = livros.Find(l => l.Id == idLivro && l.Disponivel == true);
		
		if (livro == null)
		{
			Console.WriteLine("Livro não encontrado ou indisponível.");
			return;
		}
		
		Cliente? cliente = clientes.Find(c => c.Id == idCliente);
		
		if (cliente == null)
		{
			Console.WriteLine("Cliente não encontrado");
			return;
		}
		
		Emprestimo emprestimo = new Emprestimo
		{
			Id = emprestimos.Count + 1,
			ClienteEmprestimo = cliente,
			LivroEmprestado = livro,
			DataDoEmprestimo = DateTime.Today,
			DataDevolucaoPrevista = DateTime.Today.AddDays(15)
		};
		
		livro.AlternarDisponivel();
		emprestimos.Add(emprestimo);
		
		Console.WriteLine("Livro emprestado com sucesso!");
	}
	
	public void DevolverLivro(int idCliente, int idLivro)
	{
		Livro? livro = livros.Find(l => l.Id == idLivro);
		
		if (livro == null)
		{
			Console.WriteLine("Livro não encontrado"); 
			return;
		}
		
		Emprestimo? emprestimo = emprestimos.Find(e => e.ClienteEmprestimo.Id == idCliente
		&& e.LivroEmprestado.Id == idLivro);
		
		if (emprestimo == null)
		{
			Console.WriteLine("Empréstimo não encontrado.");
			return;
		}
		
		emprestimo.LivroEmprestado.AlternarDisponivel();
		emprestimo.DataDevolucao = DateTime.Today;
		
		Console.WriteLine("Livro Devolvido com sucesso.");
	}	

	public void AdicionarCliente(string nome, string telefoene, int dia, int mes, int ano)
	{
		clientes.Add(new Cliente(nome, telefoene, dia, mes, ano));
	}

	public void AdicionarLivro(string titulo, string autor)
	{
		livros.Add(new Livro(titulo, autor));
	}

	public void MostrarLivro(int id)
	{
		try
		{
			livros[id-1].MostrarLivro();
		}
		catch (ArgumentOutOfRangeException)
		{
			Console.WriteLine($"O id {id} não pôde ser encontrado.");
		}
	}
	public void MostrarCliente(int id)
	{
		try
		{
			clientes[id-1].MostrarCliente();
		}
		catch (ArgumentOutOfRangeException)
		{
			Console.WriteLine($"O id {id} não pôde ser encontrado.");
		}
		
	}
}