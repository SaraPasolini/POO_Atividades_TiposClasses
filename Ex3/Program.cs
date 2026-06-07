using System;

class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }

    public Publicacao DadosPublicacao { get; set; }

    public class Publicacao
    {
        public string Editora { get; set; }
        public int Ano { get; set; }
    }
}

class Program
{
    static void Main()
    {
        Livro livro = new Livro();

        livro.Titulo = "Dom Casmurro";
        livro.Autor = "Machado de Assis";

        livro.DadosPublicacao = new Livro.Publicacao();
        livro.DadosPublicacao.Editora = "Ática";
        livro.DadosPublicacao.Ano = 2019;

        Console.WriteLine("DADOS DO LIVRO");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Título: {livro.Titulo}");
        Console.WriteLine($"Autor: {livro.Autor}");
        Console.WriteLine($"Editora: {livro.DadosPublicacao.Editora}");
        Console.WriteLine($"Ano: {livro.DadosPublicacao.Ano}");
    }
}


// Como acessar a classe interna?

// Utilizando o nome da classe externa seguido do nome da classe interna:

// Livro.Publicacao publicacao = new Livro.Publicacao();

// Como alterar a visibilidade da classe interna?

// Utilizando modificadores de acesso:

// public class Publicacao
// private class Publicacao
// protected class Publicacao
// internal class Publicacao

// O modificador define quem poderá acessar a classe aninhada.
