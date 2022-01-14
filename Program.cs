using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeriesFilmes();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerieFilme();
						break;
					case "4":
						ExcluirSerieFilme();
						break;
					case "5":
						VisualizarSerieFilme();
						break;
					case "6":
						Conta();
						break;
					case "7":
						ListarSeriesFilmesGeneros();
						break;
					case "8":
						IdadesPermitidas();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerieFilme()
        {
            string opcFilmeSerie = OpcaoSerieFilme();
            if (opcFilmeSerie == "S")
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorioSerie.Exclui(indiceSerie);
            }
            else
            {
                Console.Write("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                repositorioFilme.Exclui(indiceFilme);
            }
        }

        private static string OpcaoSerieFilme()
        {
            System.Console.WriteLine("Selecione uma das opções abaixo:");
            System.Console.WriteLine("S - Serie");
            System.Console.WriteLine("F - Filme");
			System.Console.WriteLine();
            var opc = Console.ReadLine().ToUpper();
			System.Console.WriteLine();
            return opc;
        }

        private static void VisualizarSerieFilme()
		{
			string opcFilmeSerie = OpcaoSerieFilme();
			if (opcFilmeSerie == "S")
			{
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				var serie = repositorioSerie.RetornaPorId(indiceSerie);
		
				Console.WriteLine(serie);
			}
			else
			{
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				var filme = repositorioFilme.RetornaPorId(indiceFilme);
		
				Console.WriteLine(filme);
			}
		}

        private static void AtualizarSerieFilme()
		{
			string opcFilmeSerie = OpcaoSerieFilme();
			if (opcFilmeSerie == "S")
			{
				Console.Write("Digite o id da série: ");
				int indiceSerie = int.Parse(Console.ReadLine());

				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());
				
				System.Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(FaixaEtaria)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FaixaEtaria), i));
				}
				System.Console.WriteLine("Digite a faixa etaria entre as opções acima: ");
				int entradaFaixaEtaria = int.Parse(Console.ReadLine());

				Console.Write("Digite o Título da Série: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início da Série: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição da Série: ");
				string entradaDescricao = Console.ReadLine();

				Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										faixaEtaria: (FaixaEtaria)entradaFaixaEtaria,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

				repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
			}
			else
			{
				Console.Write("Digite o id do filme: ");
				int indiceFilme = int.Parse(Console.ReadLine());

				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());
				
				System.Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(FaixaEtaria)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FaixaEtaria), i));
				}
				System.Console.WriteLine("Digite a faixa etaria entre as opções acima: ");
				int entradaFaixaEtaria = int.Parse(Console.ReadLine());

				Console.Write("Digite o Título do Filme: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início do Filme: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição do Filme: ");
				string entradaDescricao = Console.ReadLine();

				Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										faixaEtaria: (FaixaEtaria)entradaFaixaEtaria,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

				repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
			}
		}
        private static void ListarSeriesFilmes()
		{
			string opcFilmeSerie = OpcaoSerieFilme();
			if (opcFilmeSerie == "S")
			{
				Console.WriteLine("Listar séries");

				var lista = repositorioSerie.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma série cadastrada.");
					return;
				}

				foreach (var serie in lista)
				{
                	var excluido = serie.retornaExcluido();
                
					Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				}
			}
			else
			{
				Console.WriteLine("Listar filmes");

				var lista = repositorioFilme.Lista();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhum filme cadastrado.");
					return;
				}

				foreach (var filme in lista)
				{
                	var excluido = filme.retornaExcluido();
                
					Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
				}
			}
		}

        private static void InserirSerie()
		{
			string opcFilmeSerie = OpcaoSerieFilme();
			if (opcFilmeSerie == "S")
			{
				Console.WriteLine("Inserir nova série");

				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
				// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				System.Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(FaixaEtaria)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FaixaEtaria), i));
				}
				System.Console.WriteLine("Digite a faixa etaria entre as opções acima: ");
				int entradaFaixaEtaria = int.Parse(Console.ReadLine());

				Console.Write("Digite o Título da Série: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início da Série: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição da Série: ");
				string entradaDescricao = Console.ReadLine();

				Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
											genero: (Genero)entradaGenero,
											faixaEtaria: (FaixaEtaria)entradaFaixaEtaria,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

				repositorioSerie.Insere(novaSerie);
			}
			else
			{
				Console.WriteLine("Inserir novo filme");

				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				System.Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(FaixaEtaria)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(FaixaEtaria), i));
				}
				System.Console.WriteLine("Digite a faixa etaria entre as opções acima: ");
				int entradaFaixaEtaria = int.Parse(Console.ReadLine());

				Console.Write("Digite o Título do Filme: ");
				string entradaTitulo = Console.ReadLine();

				Console.Write("Digite o Ano de Início do Filme: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição do Filme: ");
				string entradaDescricao = Console.ReadLine();

				Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
											genero: (Genero)entradaGenero,
											faixaEtaria: (FaixaEtaria)entradaFaixaEtaria,
											titulo: entradaTitulo,
											ano: entradaAno,
											descricao: entradaDescricao);

				repositorioFilme.Insere(novoFilme);
			}
		}

		//função que lista e conta quantas obras (séries e filmes) têm de um mesmo gênero
		private static void ListarSeriesFilmesGeneros()
		{
			int contSerie = 0;
			int contFilme = 0;

			System.Console.WriteLine("Selecione um gênero abaixo:");
			foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
			int entradaGenero = int.Parse(Console.ReadLine());

			System.Console.WriteLine("As séries com este gênero buscado:");
			foreach (Serie serie in repositorioSerie.Lista())
			{
				if(serie.retornaGenero() == (Genero)entradaGenero)
				{
					Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
					contSerie =+ 1;
				}
			}

			System.Console.WriteLine("Os filmes com este gênero buscado:");
			foreach (Filme filme in repositorioFilme.Lista())
			{
				if(filme.retornaGenero() == (Genero)entradaGenero)
				{
					Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
					contFilme =+ 1;
				}
			}

			if (contSerie == 0)
			{
				System.Console.WriteLine("Nenhuma série com este gênero foi encontrada.");
			}
			if (contFilme == 0)
			{
				System.Console.WriteLine("Nenhum filme com este gênero foi encontrado.");
			} 
		}

		//função que mostra a contagem total de séries e filmes cadastrados
		private static void Conta()
		{
			var listaSerie = repositorioSerie.Lista();
			System.Console.WriteLine($"Número total de séries cadastradas: {listaSerie.Count}");
			var listaFilme = repositorioFilme.Lista();
			System.Console.WriteLine($"Número total de filmes cadastrados: {listaFilme.Count}");
			System.Console.WriteLine($"Número total de cadastros: {listaSerie.Count + listaFilme.Count}");
		}

		//função que mostra as idades permitidas para ver uma série ou um filme
		private static void IdadesPermitidas()
		{
			string opcFilmeSerie = OpcaoSerieFilme();
			if (opcFilmeSerie == "S")
            {
                System.Console.WriteLine("Digite o id da série:");
                int idSerie = int.Parse(Console.ReadLine());

                var serie = repositorioSerie.RetornaPorId(idSerie);

                IdadesPermitidasSerie(serie);
            }
			else
			{
				System.Console.WriteLine("Digite o id do filme:");
				int idFilme = int.Parse(Console.ReadLine());

				var filme = repositorioFilme.RetornaPorId(idFilme);

				IdadesPermitidasFilme(filme);
			}

        }

        private static void IdadesPermitidasSerie(Serie serie)
        {
            if (serie.retornaFaixaEtaria() == (FaixaEtaria)1)
            {
                System.Console.WriteLine("A vizualização desta série é permitida para todos os públicos");
            }
            else if (serie.retornaFaixaEtaria() == (FaixaEtaria)2)
            {
                System.Console.WriteLine("A vizualização desta série é permitida apenas para pessoas entre 12 a 17 anos");
            }
            else
            {
                System.Console.WriteLine("A vizualização desta série é permitida apenas para pessoas maiores de 18 anos");
            }
        }

		private static void IdadesPermitidasFilme(Filme filme)
        {
            if (filme.retornaFaixaEtaria() == (FaixaEtaria)1)
            {
                System.Console.WriteLine("A vizualização deste filme e é permitida para todos os públicos");
            }
            else if (filme.retornaFaixaEtaria() == (FaixaEtaria)2)
            {
                System.Console.WriteLine("A vizualização deste filme é permitida apenas para pessoas entre 12 a 17 anos");
            }
            else
            {
                System.Console.WriteLine("A vizualização deste filme é permitida apenas para pessoas maiores de 18 anos");
            }
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries/filmes");
			Console.WriteLine("2- Inserir nova série/filme");
			Console.WriteLine("3- Atualizar série/filme");
			Console.WriteLine("4- Excluir série/filme");
			Console.WriteLine("5- Visualizar série/filme");
			Console.WriteLine("6- Mostrar quantidade de cadastros feitos");
			Console.WriteLine("7- Buscar séries/filmes de um genêro específico");
			Console.WriteLine("8- Verificar as idades permitidas para a vizualização de uma série/filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
