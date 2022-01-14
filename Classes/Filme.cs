using System;

namespace DIO.Series
{
    public class Filme : Serie
    {
        public Filme(int id, Genero genero, FaixaEtaria faixaEtaria, string titulo, string descricao, int ano) : base(id, genero, faixaEtaria, titulo, descricao, ano)
        {
        }
    }
}