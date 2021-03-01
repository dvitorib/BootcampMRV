using DIO.Series.Domain.Entities;
using DIO.Series.Domain.Enums;
using DIO.Series.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Utils
{
    public class InsertUpdate
    {
        private SerieRepository repository = new SerieRepository();

        public void UserInsertUpdate()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha um gênero listado acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Digite o titulo da série:");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite o nome do diretor:");
            string entradaDiretor = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite a data de lançamento: ");
            int entradaLancamento = int.Parse(Console.ReadLine());
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Plataforma), i));
            }
            Console.WriteLine();
            Console.WriteLine("Escolha uma plataforma listada acima: ");
            int entradaPlataforma = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Descreva a série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.NextId(),
                genero: (Genero)entradaGenero,
                diretor: entradaDiretor, titulo: entradaTitulo,
                plataforma: (Plataforma)entradaPlataforma,
                dataLancamento: entradaLancamento,
                descricao: entradaDescricao);

            repository.Insert(novaSerie);
        }
    }
}