using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    abstract class PersonagemAbstrato
    {
        protected string nome;
        protected string raca;
        protected string classe;
        protected string profissao;

        public abstract void Atacar();
        public abstract void Defender();
    }
}
