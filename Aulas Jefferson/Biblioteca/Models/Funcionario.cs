using System;

namespace Biblioteca;

public class Funcionario : Pessoa
{
	public int Id { get; set; }
	public string Cargo{ get; set; }
	public DateTime DataAdmissao { get; set; }
}
