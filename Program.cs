using System.Collections.Generic;

abstract class Relatorio
{
    public abstract void GerarCabecalho();
    public abstract void GerarCorpo(List<string> dados);
    public abstract void GerarRodape();
    public abstract void ExportarRelatorio(string caminho);
}

class RelatorioPDF : Relatorio
{
    public override void GerarCabecalho()
    {
        Console.WriteLine("=== RELATÓRIO PDF ===");
    }

    public override void GerarCorpo(List<string> dados)
    {
        foreach (var item in dados)
            Console.WriteLine(item);
    }

    public override void GerarRodape()
    {
        Console.WriteLine("Fim PDF");
    }

    public override void ExportarRelatorio(string caminho)
    {
        Console.WriteLine($"PDF exportado para {caminho}");
    }
}

class RelatorioHTML : Relatorio
{
    public override void GerarCabecalho()
    {
        Console.WriteLine("<html><body>");
    }

    public override void GerarCorpo(List<string> dados)
    {
        foreach (var item in dados)
            Console.WriteLine($"<p>{item}</p>");
    }

    public override void GerarRodape()
    {
        Console.WriteLine("</body></html>");
    }

    public override void ExportarRelatorio(string caminho)
    {
        Console.WriteLine($"HTML exportado para {caminho}");
    }
}

class RelatorioCSV : Relatorio
{
    public override void GerarCabecalho()
    {
        Console.WriteLine("DADOS");
    }

    public override void GerarCorpo(List<string> dados)
    {
        foreach (var item in dados)
            Console.WriteLine(item);
    }

    public override void GerarRodape()
    {
        Console.WriteLine("FIM");
    }

    public override void ExportarRelatorio(string caminho)
    {
        Console.WriteLine($"CSV exportado para {caminho}");
    }
}

class FabricaRelatorios
{
    public Relatorio CriarRelatorio(string formato)
    {
        switch (formato.ToLower())
        {
            case "pdf":
                return new RelatorioPDF();

            case "html":
                return new RelatorioHTML();

            case "csv":
                return new RelatorioCSV();

            default:
                return null;
        }
    }
}

class Program
{
    static void Main()
    {
        List<string> dados = new List<string>();

        Console.WriteLine("Digite os dados do relatório:");
        Console.WriteLine("Digite FIM para terminar.");

        string entrada;

        do
        {
            entrada = Console.ReadLine();

            if (entrada.ToUpper() != "FIM")
                dados.Add(entrada);

        } while (entrada.ToUpper() != "FIM");

        FabricaRelatorios fabrica = new FabricaRelatorios();

        string continuar;

        do
        {
            Console.Write("Formato (PDF, HTML, CSV): ");
            string formato = Console.ReadLine();

            Relatorio relatorio = fabrica.CriarRelatorio(formato);

            if (relatorio != null)
            {
                relatorio.GerarCabecalho();
                relatorio.GerarCorpo(dados);
                relatorio.GerarRodape();

                relatorio.ExportarRelatorio($"arquivo.{formato.ToLower()}");
            }
            else
            {
                Console.WriteLine("Formato inválido.");
            }

            Console.Write("Gerar outro relatório? (s/n): ");
            continuar = Console.ReadLine();

        } while (continuar.ToLower() == "s");
    }
}