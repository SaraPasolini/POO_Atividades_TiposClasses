using System;
using System.Collections.Generic;

// Classe Abstrata
abstract class Funcionario
{
    public string Nome;

    public abstract double CalcularSalario();

    public virtual void ExibirInfo()
    {
        Console.WriteLine($"Funcionário genérico: {Nome}");
    }
}

// Classe Professor
class Professor : Funcionario
{
    public int HorasAula;
    public double ValorHora;

    public override double CalcularSalario()
    {
        return HorasAula * ValorHora;
    }

    public sealed override void ExibirInfo()
    {
        Console.WriteLine(
            $"Professor: {Nome} - Salário: R$ {CalcularSalario():F2}"
        );
    }
}

// Classe Selada
sealed class Coordenador : Professor
{
    public double Bonus;

    public void ExibirBonus()
    {
        Console.WriteLine(
            $"Bônus de coordenação: R$ {Bonus:F2}"
        );
    }
}

// Classe Parcial - Parte 1
partial class Escola
{
    public string Nome;
    public string Endereco;
}

// Classe Parcial - Parte 2
partial class Escola
{
    public List<Funcionario> Funcionarios = new List<Funcionario>();

    public void ListarFuncionarios()
    {
        foreach (Funcionario funcionario in Funcionarios)
        {
            funcionario.ExibirInfo();

            if (funcionario is Coordenador coordenador)
            {
                coordenador.ExibirBonus();
            }

            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Professor professor = new Professor();
        professor.Nome = "Carlos Silva";
        professor.HorasAula = 80;
        professor.ValorHora = 50;

        Coordenador coordenador = new Coordenador();
        coordenador.Nome = "Fernanda Souza";
        coordenador.HorasAula = 100;
        coordenador.ValorHora = 60;
        coordenador.Bonus = 1500;

        Escola escola = new Escola();
        escola.Nome = "PUC Minas";
        escola.Endereco = "Contagem - MG";

        escola.Funcionarios.Add(professor);
        escola.Funcionarios.Add(coordenador);

        Console.WriteLine("=== DADOS DA ESCOLA ===");
        Console.WriteLine($"Nome: {escola.Nome}");
        Console.WriteLine($"Endereço: {escola.Endereco}");

        Console.WriteLine("\n=== FUNCIONÁRIOS ===");
        escola.ListarFuncionarios();
    }
}


// DESAFIO

// Se tentarmos criar:

// class Diretor : Coordenador
// {
// }

// O compilador apresentará erro porque a classe
// Coordenador foi declarada com a palavra-chave
// 'sealed'.

// Classes seladas não podem ser herdadas por
// outras classes.

// Da mesma forma, o método ExibirInfo() foi
// declarado como 'sealed override' na classe
// Professor. Portanto, nenhuma classe derivada
// pode sobrescrever esse método novamente.
