using System;

interface ISeguro
{
    double CalcularSeguro();
}

abstract class Veiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }

    public Veiculo(string marca, string modelo)
    {
        Marca = marca;
        Modelo = modelo;
    }
}

class Carro : Veiculo
{
    public int Portas { get; set; }

    public Carro(string marca, string modelo, int portas)
        : base(marca, modelo)
    {
        Portas = portas;
    }
}

class Moto : Veiculo
{
    public int Cilindradas { get; set; }

    public Moto(string marca, string modelo, int cilindradas)
        : base(marca, modelo)
    {
        Cilindradas = cilindradas;
    }
}

class Sedan : Carro, ISeguro
{
    public Sedan(string marca, string modelo, int portas)
        : base(marca, modelo, portas) { }

    public double CalcularSeguro()
    {
        return 1200;
    }
}

class Picape : Carro, ISeguro
{
    public Picape(string marca, string modelo, int portas)
        : base(marca, modelo, portas) { }

    public double CalcularSeguro()
    {
        return 1800;
    }
}

class Scooter : Moto, ISeguro
{
    public Scooter(string marca, string modelo, int cilindradas)
        : base(marca, modelo, cilindradas) { }

    public double CalcularSeguro()
    {
        return 500;
    }
}

class Motocross : Moto, ISeguro
{
    public Motocross(string marca, string modelo, int cilindradas)
        : base(marca, modelo, cilindradas) { }

    public double CalcularSeguro()
    {
        return 900;
    }
}

class Program
{
    static void Main()
    {
        Sedan sedan = new Sedan("Toyota", "Corolla", 4);

        Console.WriteLine($"Marca: {sedan.Marca}");
        Console.WriteLine($"Modelo: {sedan.Modelo}");
        Console.WriteLine($"Seguro: R$ {sedan.CalcularSeguro()}");
    }
}