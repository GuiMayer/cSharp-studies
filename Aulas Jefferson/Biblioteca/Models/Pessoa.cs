using System;

namespace Biblioteca;

public class Pessoa
{
	private string _nome;
	public string Nome
	{
		get
		{
			return _nome;
		}
		set
		{
			if (value == "") {
				throw new ArgumentException("O nome não pode ser vazio.");
			}
			_nome = value;
		}
	}
	
	public DateTime DataNascimento{ get; private set; }

	public void SetDataNascimento(int dia, int mes, int ano)
	{
		try
		{
			DataNascimento = new DateTime(ano, mes, dia);
		}
		catch (ArgumentOutOfRangeException e)
		{
			throw new ArgumentException("Data inválida: ", e);
		}
	}
}