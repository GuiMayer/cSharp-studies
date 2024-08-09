using System;

namespace Biblioteca;

public class Cliente : Pessoa
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

	public string Telefone { get; set;}

	public Cliente(string nome, string telefone, int dia, int mes, int ano)
	{
		counterId += 1;
		_id = counterId;

		this.Telefone = telefone;
		this.Nome = nome;
		SetDataNascimento(dia, mes, ano);
	}

	public Cliente()
	{
		counterId += 1;
		_id = counterId;

		this.Telefone = "null";
	}

	public void MostrarCliente()
	{
		Console.WriteLine($"ID: {Id} Nome: {Nome} Telefone: {Telefone} Aniversario: {DataNascimento.Day}/{DataNascimento.Month}/{DataNascimento.Year}\n");
	}
}