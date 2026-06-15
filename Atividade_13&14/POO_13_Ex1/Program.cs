using System;

abstract class Veiculo
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }

    public abstract void ExibirDetalhes();
    public abstract decimal CalcularCustoManutencao();
}

class Carro : Veiculo
{
    public int NumeroPortas { get; set; }
    public string TipoCombustivel { get; set; }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Carro: {Modelo} - {Ano} - {Cor}");
        Console.WriteLine($"Portas: {NumeroPortas}");
        Console.WriteLine($"Combustível: {TipoCombustivel}");
    }

    public override decimal CalcularCustoManutencao()
    {
        return 500;
    }
}

class Moto : Veiculo
{
    public int Cilindrada { get; set; }
    public string TipoPartida { get; set; }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Moto: {Modelo} - {Ano} - {Cor}");
        Console.WriteLine($"Cilindrada: {Cilindrada}");
        Console.WriteLine($"Partida: {TipoPartida}");
    }

    public override decimal CalcularCustoManutencao()
    {
        return 250;
    }
}

class Caminhao : Veiculo
{
    public double CapacidadeCarga { get; set; }
    public int NumeroEixos { get; set; }

    public override void ExibirDetalhes()
    {
        Console.WriteLine($"Caminhão: {Modelo} - {Ano} - {Cor}");
        Console.WriteLine($"Carga: {CapacidadeCarga} toneladas");
        Console.WriteLine($"Eixos: {NumeroEixos}");
    }

    public override decimal CalcularCustoManutencao()
    {
        return 1200;
    }
}

class FabricaVeiculos
{
    public Veiculo CriarVeiculo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "carro":
                return new Carro();

            case "moto":
                return new Moto();

            case "caminhao":
                return new Caminhao();

            default:
                return null;
        }
    }
}

class Program
{
    static void Main()
    {
        List<Veiculo> veiculos = new List<Veiculo>();
        FabricaVeiculos fabrica = new FabricaVeiculos();

        string resposta;

        do
        {
            Console.WriteLine("Escolha o veículo:");
            Console.WriteLine("Carro");
            Console.WriteLine("Moto");
            Console.WriteLine("Caminhao");

            string tipo = Console.ReadLine();

            Veiculo veiculo = fabrica.CriarVeiculo(tipo);

            if (veiculo == null)
            {
                Console.WriteLine("Tipo inválido!");
                continue;
            }

            Console.Write("Modelo: ");
            veiculo.Modelo = Console.ReadLine();

            Console.Write("Ano: ");
            veiculo.Ano = int.Parse(Console.ReadLine());

            Console.Write("Cor: ");
            veiculo.Cor = Console.ReadLine();

            if (veiculo is Carro carro)
            {
                Console.Write("Número de portas: ");
                carro.NumeroPortas = int.Parse(Console.ReadLine());

                Console.Write("Tipo combustível: ");
                carro.TipoCombustivel = Console.ReadLine();
            }
            else if (veiculo is Moto moto)
            {
                Console.Write("Cilindrada: ");
                moto.Cilindrada = int.Parse(Console.ReadLine());

                Console.Write("Tipo partida: ");
                moto.TipoPartida = Console.ReadLine();
            }
            else if (veiculo is Caminhao caminhao)
            {
                Console.Write("Capacidade carga: ");
                caminhao.CapacidadeCarga = double.Parse(Console.ReadLine());

                Console.Write("Número de eixos: ");
                caminhao.NumeroEixos = int.Parse(Console.ReadLine());
            }

            veiculos.Add(veiculo);

            Console.Write("Deseja adicionar outro veículo? (s/n): ");
            resposta = Console.ReadLine();

        } while (resposta.ToLower() == "s");

        decimal total = 0;

        Console.WriteLine("\nVEÍCULOS CADASTRADOS:");

        foreach (var v in veiculos)
        {
            v.ExibirDetalhes();

            decimal custo = v.CalcularCustoManutencao();

            Console.WriteLine($"Custo manutenção: R$ {custo}");
            Console.WriteLine("-----------------------");

            total += custo;
        }

        Console.WriteLine($"Custo total: R$ {total}");
    }
}