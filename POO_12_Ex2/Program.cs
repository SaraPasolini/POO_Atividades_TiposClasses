using System;
using System.Collections.Generic;

public class Compra
{
    public string Produto { get; set; } = string.Empty;
    public double Valor { get; set; }
}

public class Cliente
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public List<Compra> Compras { get; set; } = new List<Compra>();
}

class Program
{
    static void Main()
    {
        Cliente cliente = new Cliente();

        cliente.Nome = "Anthony";
        cliente.Email = "anthony@gmail.com";
        cliente.Telefone = "(31)99999-9999";

        cliente.Compras.Add(new Compra
        {
            Produto = "Notebook",
            Valor = 3500
        });

        cliente.Compras.Add(new Compra
        {
            Produto = "Mouse",
            Valor = 120
        });

        Console.WriteLine("DADOS DO CLIENTE");
        Console.WriteLine("----------------------");
        Console.WriteLine($"Nome: {cliente.Nome}");
        Console.WriteLine($"Email: {cliente.Email}");
        Console.WriteLine($"Telefone: {cliente.Telefone}");

        Console.WriteLine("\nHISTÓRICO DE COMPRAS");

        foreach (var compra in cliente.Compras)
        {
            Console.WriteLine($"Produto: {compra.Produto} - R$ {compra.Valor:F2}");
        }
    }
}