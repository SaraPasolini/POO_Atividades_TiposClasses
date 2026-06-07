using System;
using System.Collections.Generic;

abstract class Figura
{
    public abstract double CalcularArea();
}

class Retangulo : Figura
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public Retangulo(double b, double h)
    {
        Base = b;
        Altura = h;
    }

    public override double CalcularArea()
    {
        return Base * Altura;
    }
}

class Circulo : Figura
{
    public double Raio { get; set; }

    public Circulo(double raio)
    {
        Raio = raio;
    }

    public override double CalcularArea()
    {
        return Math.PI * Raio * Raio;
    }
}

class Program
{
    static void Main()
    {
        List<Figura> figuras = new List<Figura>();

        Console.Write("Quantas figuras deseja cadastrar? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nFigura {i + 1}");
            Console.Write("R = Retângulo | C = Círculo: ");
            char tipo = char.Parse(Console.ReadLine().ToUpper());

            if (tipo == 'R')
            {
                Console.Write("Base: ");
                double b = double.Parse(Console.ReadLine());

                Console.Write("Altura: ");
                double h = double.Parse(Console.ReadLine());

                figuras.Add(new Retangulo(b, h));
            }
            else if (tipo == 'C')
            {
                Console.Write("Raio: ");
                double r = double.Parse(Console.ReadLine());

                figuras.Add(new Circulo(r));
            }
        }

        Console.WriteLine("\nÁREAS:");

        foreach (Figura figura in figuras)
        {
            Console.WriteLine(figura.CalcularArea().ToString("F2"));
        }
    }
}