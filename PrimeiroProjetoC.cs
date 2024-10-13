// Screen Sound
using System.Net;

string mensagemDeBoasVindas = "Bem vindos ao Screen Sound";
//List<string> listaDasBandas = new List<string> {"Skillet", "Linkin Park", "Paramore"};
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6});
bandasRegistradas.Add("Skillet", new List<int>());

void ExibirLogo() 
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");   
}

void ExibirMenu()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\n" + mensagemDeBoasVindas + "\n");
    ExibirOpcoesDoMenuInicial();
    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);


    switch(opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: ExibirBandasRegistradas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: ExibirMediaDaBanda();
            break;
        case 5: SairDoPrograma();
            break;
        default: Console.WriteLine("Opção inválida.");
            break;
    };
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda para registro: ");
    string nomeDaBanda = Console.ReadLine()!;
    //listaDasBandas.Add(nomeDaBanda);
    if (bandasRegistradas.ContainsKey(nomeDaBanda)) 
    {
        Console.WriteLine($"Já existe uma banda com o nome {nomeDaBanda} cadastrada. Por favor, cadastre uma banda com nome diferente.");
        Thread.Sleep(2000);
        RegistrarBanda();
    }
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(1000);
    ExibirMenu();
};

void ExibirBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Bandas cadastradas");
    //for (int i = 0; i < listaDasBandas.Count; i++) 
    //{
    //    Console.WriteLine($"\nBanda: {listaDasBandas[i]}");
    //}
    //foreach(string banda in listaDasBandas)
    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}\n");
    }
    RetornarAoMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        try
        {
            int nota = int.Parse(Console.ReadLine()!);
            if (nota >= 0 && nota <= 10)
            {
                bandasRegistradas[nomeDaBanda].Add(nota);
                Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
                Thread.Sleep(1000);
                ExibirMenu();
            }
            else
            {
                Console.WriteLine("Para avaliar uma banda somente são permitidos número inteiros de 0 a 10");
                Thread.Sleep(2000);
                AvaliarBanda();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Por favor, insira um número inteiro válido.");
            Thread.Sleep(2000);
            AvaliarBanda();
        }
    } 
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        RetornarAoMenu();
    }
}

void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Nota média da banda");
    Console.Write("Digite o nome da banda que deseja ver a média das notas: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        if (notasDaBanda.Count > 0) 
        {
            double media = notasDaBanda.Average();
            Console.WriteLine($"A média de notas da banda {nomeDaBanda} é: {media:F2}");
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não tem notas registradas.");
        }
        RetornarAoMenu();
    } 
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        RetornarAoMenu();
    }
}

void SairDoPrograma()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nTchau tchau!\n");
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void RetornarAoMenu()
{
    Console.Write("\nDigite qualquer tecla para retornar ao menu principal ");
    Console.ReadKey();
    ExibirMenu();
}

void ExibirOpcoesDoMenuInicial()
{
    Console.WriteLine("Digite 1 para resgistrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 exibir a média de uma banda");
    Console.WriteLine("Digite 5 para sair");
}

ExibirMenu();
