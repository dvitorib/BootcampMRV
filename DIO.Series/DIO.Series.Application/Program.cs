using DIO.Series.Domain.Entities;
using DIO.Series.Domain.Enums;
using DIO.Series.Repositories;
using System;

namespace DIO.Series.Application
{
    internal class Program
    {
        private static readonly SerieRepository repository = new SerieRepository();

        private static void Main()
        {
            string userOption = UserOptions();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListarSerie();
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

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = UserOptions();
            }
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries: ");
            var list = repository.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }
            foreach (var serie in list)
            {
                var excluido = serie.ReturnExcluido();

                Console.WriteLine("#ID: {0}: - {1} - {2}", serie.ReturnId(), serie.ReturnTitulo(), (excluido ? "* Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir séries: ");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Escolha um gênero listado acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Digite o titulo da série:");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite o nome do diretor:");
            string entradaDiretor = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite a data de lançamento: ");
            int entradaLancamento = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Plataforma), i));
            }
            Console.WriteLine();
            Console.Write("Escolha uma plataforma listada acima: ");
            int entradaPlataforma = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Descreva a série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.NextId(),
                genero: (Genero)entradaGenero,
                diretor: entradaDiretor, titulo: entradaTitulo,
                plataforma: (Plataforma)entradaPlataforma,
                dataLancamento: entradaLancamento,
                descricao: entradaDescricao);

            repository.Insert(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar nova série. ");
            Console.Write("Digite o id: ");
            int entradaId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Escolha um gênero listado acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Digite o titulo da série:");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite o nome do diretor:");
            string entradaDiretor = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite o ano de lançamento: ");
            int entradaLancamento = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Plataforma), i));
            }
            Console.WriteLine();
            Console.Write("Escolha uma plataforma listada acima: ");
            int entradaPlataforma = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Descreva a série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: entradaId,
                genero: (Genero)entradaGenero,
                diretor: entradaDiretor, titulo: entradaTitulo,
                plataforma: (Plataforma)entradaPlataforma,
                dataLancamento: entradaLancamento,
                descricao: entradaDescricao);

            repository.Insert(atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir séries ");
            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());
            repository.Delete(entradaId);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar séries: ");
            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repository.GetById(entradaId);
            Console.WriteLine(serie);
        }

        private static string UserOptions()
        {
            Console.WriteLine();
            Console.WriteLine(" Bem-Vindo ao Dio Séries.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Escolha a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1-Listar séries");
            Console.WriteLine("2-Inserir nova série");
            Console.WriteLine("3-Atualizar série");
            Console.WriteLine("4-Excluir série");
            Console.WriteLine("5-Visualizar série");
            Console.WriteLine("C-Limpar Tela");
            Console.WriteLine("X-Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}