using System;

abstract class PersonagemAbstrato
{
    protected string nome;
    protected string raca;
    protected string profissao;
    protected int FOR;
    protected int DEF;
    protected int LP;
    public abstract int Atacar(IInimigo inimigo);
    public abstract int Defender();

    public PersonagemAbstrato(string nome)
    {
        this.nome = nome;
    }
}