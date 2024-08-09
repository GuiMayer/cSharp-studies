using System;

namespace Biblioteca;

public class Livro
{
	private static int counterId = 0;
	private int _id;
	public int Id
	{
		get
		{
			return _id;
		}
	}
	private string _titulo;
	public string Titulo
	{
		get
		{
			return _titulo;
		}
		set
		{
			if (value == "") {
				throw new ArgumentException("O titulo não pode ser vazio.");
			}
			_titulo = value;
		}
	}	
	private string _autor;
	public string Autor
	{
		get
		{
			return _autor;
		}
		set
		{
			if (value == "") {
				throw new ArgumentException("O autor não pode ser vazio.");
			}
			_autor = value;
		}
	}
	public bool Disponivel{ get; private set; }

	public Livro(string titulo, string autor)
	{
		counterId += 1;
		_id = counterId;

		_titulo = titulo;
		_autor = autor;

		AlternarDisponivel(true);
	}

	public void AlternarDisponivel()
	{
		Disponivel = !Disponivel;
	}
	public void AlternarDisponivel(bool valor)
	{
		Disponivel = valor;
	}

	public void MostrarLivro()
	{
		Console.WriteLine($"ID: {Id} Titulo: {Titulo} Autor: {Autor}");
	}
}