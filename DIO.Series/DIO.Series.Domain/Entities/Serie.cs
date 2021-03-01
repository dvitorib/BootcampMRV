using DIO.Series.Domain.Enums;
using System;

namespace DIO.Series.Domain.Entities
{
    public class Serie : Entity
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Diretor { get; set; }
        private int DataLancamento { get; set; }
        private Plataforma Plataforma { get; set; }
        public string Descricao { get; set; }
        private bool Excluido { get; set; }

        public Serie(Genero genero, string titulo, string diretor, int dataLancamento, Plataforma plataforma, string descricao, int id)
        {
            Genero = genero;
            Titulo = titulo;
            Diretor = diretor;
            DataLancamento = dataLancamento;
            Plataforma = plataforma;
            Descricao = descricao;
            Id = id;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Nome: " + Titulo + Environment.NewLine;
            retorno += "Diretor: " + Diretor + Environment.NewLine;
            retorno += "Data de Lançamento: " + DataLancamento + Environment.NewLine;
            retorno += "Plataforma: " + Plataforma + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Excluido: " + Excluido + Environment.NewLine;
            return retorno;
        }

        public int ReturnId()
        {
            return Id;
        }

        public string ReturnTitulo()
        {
            return Titulo;
        }

        public bool ReturnExcluido()
        {
            return Excluido;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}