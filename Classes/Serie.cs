using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
		private Genero Genero { get; set; }
		private FaixaEtaria FaixaEtaria { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Serie(int id, Genero genero, FaixaEtaria faixaEtaria, string titulo, string descricao, int ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.FaixaEtaria = faixaEtaria;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
			retorno += "Faixa Etária: " + this.FaixaEtaria + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }

		public Genero retornaGenero()
		{
			return this.Genero;
		}

		public FaixaEtaria retornaFaixaEtaria()
		{
			return this.FaixaEtaria;
		}
    }
}