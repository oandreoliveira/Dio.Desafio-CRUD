using System;

namespace Dio.Desafio
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Clear(); ListarSeries();
                        break;
                    case "2":
                        Console.Clear(); InserirSerie();
                        break;
                    case "3":
                        Console.Clear(); AtualizarSerie();
                        break;
                    case "4":
                        Console.Clear(); ExcluirSerie();
                        break;
                    case "5":
                        Console.Clear(); VisualizarSerie();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" ------ OPÇÃO INVÁLIDA ------");
                        break;
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine();
            Console.WriteLine(" OBRIGADO POR UTILIZAR NOSSOS SERVIÇOS!");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine(" Você tem certeza que desjea excluir uma Série?");
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(ConfirmaExclusao)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(ConfirmaExclusao), i)}");
            }
            int escolhaExclusao = int.Parse(Console.ReadLine()); Console.Clear();
            if (escolhaExclusao == 1)
            {
                Console.Write(" Digite o ID da Série: ");
                int indiceSerie = int.Parse(Console.ReadLine());
                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(" Impossível Excluir - Nenhuma série cadastrada ainda!");
                    Console.WriteLine(" ----------------------------------------------------");

                }
                foreach (var serie in lista)
                {
                    repositorio.Exclui(indiceSerie);
                    Console.WriteLine();
                    Console.WriteLine(" ------ SÉRIE EXCLUÍDA COM SUCESSO! ------");
                    Console.WriteLine();

                }

            }

        }
        private static void VisualizarSerie()
        {
            Console.WriteLine();
            Console.Write(" Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine()); Console.Clear();
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" Impossível Visualizar - Nenhuma série cadastrada ainda!");
                Console.WriteLine(" -------------------------------------------------------");

            }
            foreach (var serie in lista)
            {
                var visualizaSerie = repositorio.RetornaPorId(indiceSerie);

                Console.WriteLine();
                Console.WriteLine(visualizaSerie);
                Console.WriteLine();
            }


        }
        private static void AtualizarSerie()
        {

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" Impossível Atualizar - Nenhuma série cadastrada ainda!");
                Console.WriteLine(" ------------------------------------------------------");

            }
            else
            {
                Console.Write(" Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
                }
                Console.Write(" Digite o Gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write(" Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write(" Digite o Ano de Lançamento da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write(" Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Atualiza(indiceSerie, atualizaSerie);
            }

        }
        private static void ListarSeries()
        {

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" Nenhuma série cadastrada!");
                Console.WriteLine(" -------------------------");
                return;
            }
            else
            {
                Console.WriteLine(" Lista de Séries ");
                Console.WriteLine();
                foreach (var serie in lista)
                {
                    var excluido = serie.RetornaExcluido();

                    Console.WriteLine();
                    Console.WriteLine($"{ (excluido ? " SÉRIE EXCLUÍDA - " : "")} #ID: {serie.RetornaId()} | SÉRIE: { serie.RetornaTitulo()} | DESCRIÇÃO : {serie.RetornaDescricao()} |");
                }
            }

        }
        private static void InserirSerie()
        {
            Console.WriteLine(" Inserir nova série");
            Console.WriteLine();


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine();
            Console.Write(" Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" DIO Séries a seu dispor!!!");
            Console.WriteLine(" Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine(" 1- Listar Séries");
            Console.WriteLine(" 2- Inserir nova Série");
            Console.WriteLine(" 3- Atualizar Série");
            Console.WriteLine(" 4- Excluir Série");
            Console.WriteLine(" 5- Visualizar Série");
            Console.WriteLine(" X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
