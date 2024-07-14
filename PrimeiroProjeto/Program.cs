// Screen Sound - Alura Aula 1 - Sabrina Costa 
// O C# é uma linguagem fortemente tipada, ou seja, precisa-se declarar o tipo e nome da vaviável
string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound"; //nome de variavem sempre em camelCase

//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso"}; //List para criar uma lista e dentro os <> o tipo da lista, se é um valor inteiro, uma string, etc

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); // o nome das bandas será a chave e suas notas será uma lista para cada chave
bandasRegistradas.Add("Link Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()//void usado para funções que não tem retorno e nome de função é sempre em PascalCase
{
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀");//o @ antes das aspas se chama Verbatin Literal, serve para ver como uma linha muito longa vai ficar no terminal
    //se não usasse o @ ficaria:
    //Console.WriteLine("\r\n█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄...); e ficaria muito feio e ilegivel na nossa aplicação.
    Console.WriteLine(mensagemDeBoasVindas); //Console.WriteLine: imprimir algo na tela 
}

void ExibirOpçõesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda.");
    Console.WriteLine("Digite 2 para mostrar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média de uma banda.");
    Console.WriteLine("Digite 0 para sair.");

    Console.Write("\nDigite a sua opção: ");//usa somente o Write para não pular de linha
    string opcaoEscolhida = Console.ReadLine()!; //ReadLine: ler uma informação que o usuario nos passou 
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); //int.Parse: transforma a variavel string em número inteiro

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBandas(); 
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: MediaDeBandas();
            break;
        case 0: Console.WriteLine("Tchau tchau :)");
            break;
        default: Console.WriteLine("Opção invalida.");
            break;
    }

}

void RegistrarBandas()
{
    Console.Clear();
    ExibirTitulodaOpcao("Registro das Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    //listaDasBandas.Add(nomeDaBanda); //.Add para adicionar o que foi escrito na variavel nomeDaBanda na lista listaDasBandas
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada!");//Interpolação de string: ao inicias a string colocar o $ e envoolver a variavel em chaves
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpçõesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTitulodaOpcao("Bandas Registradas");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys) //o foreach é como se fosse o for anterior mas muito mais simples 
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite qualquer tela para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpçõesDoMenu();
}

void ExibirTitulodaOpcao(string titulo)//quando está função for chamada, precisará passar um valor do tipo string entre os parenteses
{
    int quantidadeDeLetras = titulo.Length; //conta quantos caracteres tem na variavel titulo
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*'); //Empty adiciona caracteres e PadLeft adiciona-os na esquerda 
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digitr qual banda deseja avaliar
    //se a banda existir >> atribuir uma nota
    //senão, volta ao menu

    Console.Clear();
    ExibirTitulodaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso a banda {nomeDaBanda}");
        Thread.Sleep(2500);
        Console.Clear();
        ExibirOpçõesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    }
}

void MediaDeBandas()
{
    Console.Clear();
    ExibirTitulodaOpcao("Média da Banda");
    Console.Write("Digite o nome da banda que deseja saber a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"A banda escolhida foi {nomeDaBanda}");
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    }else{
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    }

}

ExibirOpçõesDoMenu();