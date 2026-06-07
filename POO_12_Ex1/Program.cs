using System;

class Animal
{
    public virtual void FazerSom()
    {
        Console.WriteLine("Animal faz um som");
    }
}

class Cachorro : Animal
{
    public sealed override void FazerSom()
    {
        Console.WriteLine("Cachorro late: Au Au!");
    }
}

sealed class PastorAlemao : Cachorro
{
    public void MostrarRaca()
    {
        Console.WriteLine("Raça: Pastor Alemão");
    }
}

class Program
{
    static void Main()
    {
        PastorAlemao pastor = new PastorAlemao();

        pastor.FazerSom();
        pastor.MostrarRaca();
    }
}


// Tentativas que geram erro:

// class Filhote : PastorAlemao
// {
// }

// Erro:
// Não é possível herdar de uma classe marcada como sealed.

// ===============================================

// class PastorAlemao : Cachorro
// {
//     public override void FazerSom()
//     {
//     }
// }

// Erro:
// O método FazerSom() foi marcado como sealed
// na classe Cachorro, impedindo novas sobrescritas.
