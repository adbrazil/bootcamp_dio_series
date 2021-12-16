using System;
using DIO.Serie;
using DIO.Series.Classes;

namespace DIO.Serie
{

    public class MenuAPP
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        public void ExibeMenu(){
            string opcaoUsuario= ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        ListarFilmes();
                        break;
                    case "7":
                        InserirFilme();
                        break;
                    case "8":
                        AtualizarFilme();
                        break;
                    case "9":
                        ExcluirFilme();
                        break;
                    case "10":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario=ObterOpcaoUsuario();
            }

        }
    
     private static int SolicitaId(Produto produto){

            Console.Write(produto);

            if(produto.ToString()=="Serie"){
              Console.Write("Digite o id da série: ");
            }
            else{
                Console.Write("Digite o id do Filme: ");
            }
            
			int indice = int.Parse(Console.ReadLine());

            var lista= repositorio.Lista();

            if(lista.Count<indice){
                Console.WriteLine();
                Console.Write("ID Não encontrado, por favor insira um id válido! ");
                Console.WriteLine();
                indice=SolicitaId(produto);
            }

            return indice;
        }


        private static void ExcluirSerie()
		{
			repositorio.Exclui(SolicitaId(Produto.Serie));
		}

        private static void VisualizarSerie()
		{
			var serie = repositorio.RetornaPorId(SolicitaId(Produto.Serie));
			Console.WriteLine(serie);
		}

        public static int SelecionaGenero(){

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

            return entradaGenero;

        }

        public static Serie FormularioSerie(int indiceSerie,int entradaGenero){

            Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie serie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
            return serie;

        }

        public static Filme FormularioFilme(int indiceSerie,int entradaGenero){

            Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da  Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme filme = new Filme(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
            return filme;

        }

        private static void AtualizarSerie()
		{
			
            int indiceSerie= SolicitaId(Produto.Serie);


			int entradaGenero=SelecionaGenero();


            Serie atualizaSerie= FormularioSerie(indiceSerie,entradaGenero);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries(){
            Console.WriteLine("Listar séries");
            var lista= repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach( var serie in lista){
                Console.WriteLine("#ID {0}: - {1}",serie.retornaId(),serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

            int entradaGenero = SelecionaGenero();

            Serie novaSerie = FormularioSerie(repositorio.ProximoId(),entradaGenero);                        

			repositorio.Insere(novaSerie);
		}



        private static void ListarFilmes(){
            Console.WriteLine("Listar Filmes");
            var lista= repositorioFilme.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhum Filme cadastrada");
                return;
            }
            foreach( var filme in lista){
                Console.WriteLine("#ID {0}: - {1}",filme.retornaId(),filme.retornaTitulo());
            }
        }


        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo Filme");

            int entradaGenero = SelecionaGenero();

            Filme novoFilme = FormularioFilme(repositorioFilme.ProximoId(),entradaGenero);                        

			repositorioFilme.Insere(novoFilme);
		}

        private static void AtualizarFilme()
		{
			
            int indiceFilme= SolicitaId(Produto.Filme);


			int entradaGenero=SelecionaGenero();


            Filme atualizaFilme= FormularioFilme(indiceFilme,entradaGenero);

			repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
		}

        private static void ExcluirFilme()
		{
			repositorioFilme.Exclui(SolicitaId(Produto.Filme));
		}

        private static void VisualizarFilme()
		{
			var filme = repositorioFilme.RetornaPorId(SolicitaId(Produto.Filme));
			Console.WriteLine(filme);
		}

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor !!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Listar filmes");
            Console.WriteLine("7- Inserir nova filme");
            Console.WriteLine("8- Atualizar filme");
            Console.WriteLine("9- Excluir filme");
            Console.WriteLine("10- Visualizar filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario= Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }



    }
}