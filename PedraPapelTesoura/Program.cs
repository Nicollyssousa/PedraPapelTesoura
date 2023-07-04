using System;

class Program
{

    static int rodadas;

    public static void Main(string[] args)
    {
        Start();
    }

    public static void Start()
    {
        DesenhaCabecalho(3);
        Console.WriteLine("* Digite \"1\" para começar:");

        int iniciar;
        iniciar = Int32.Parse(Console.ReadLine());

        while (iniciar != 1)
        {
            DesenhaCabecalho(3);
            Console.WriteLine("* Opção inválida! Digite 1 para começar:");
            iniciar = Int32.Parse(Console.ReadLine());
        }

        DefineRodadas();
    }

    public static void DesenhaCabecalho(int linhasExtras)
    {
        Console.Clear();
        Console.WriteLine("************************************");
        Console.WriteLine("**    Pedra, Papel ou Tesoura     **");
        Console.WriteLine("************************************");

        for (int i = 0; i < linhasExtras; i++)
        {
            Console.WriteLine("\n");
        }
    }

    public static void DefineRodadas()
    {
        DesenhaCabecalho(3);
        Console.WriteLine("* Quantas rodadas você quer jogar 3, 5, ou 7?");
        rodadas = Int32.Parse(Console.ReadLine());

        while (rodadas != 3 && rodadas != 5 && rodadas != 7)
        {
            DesenhaCabecalho(3);

            Console.WriteLine("* Você digitou um valor inválido. Escolha entre os números 3, 5 ou 7:");
            rodadas = Int32.Parse(Console.ReadLine());
        }
        ControlaRodadas();
    }
    public static void ControlaRodadas()
    {
        int rodadaAtual = 1;
        int pontosUsuario = 0;
        int pontosComputador = 0;
        bool fimDeJogo = false;

        while (fimDeJogo != true)
        {
            DesenhaCabecalho(0);
            Console.WriteLine("              Rodada" + rodadaAtual.ToString() + "/" + rodadas.ToString() + "          ");
            Console.WriteLine();
            Console.WriteLine("*[User: " + pontosUsuario.ToString() + " pontos  |  CPU: " + pontosComputador.ToString() + " pontos]*");

            switch (ExibeRodada())
            {
                case 0:
                    break;
                case 1:
                    pontosUsuario++;
                    rodadaAtual++;
                    if (pontosUsuario > rodadas / 2)
                    {
                        Console.WriteLine("Usuário venceu");
                        fimDeJogo = true;
                    }

                    break;
                case 2:
                    pontosComputador++;
                    rodadaAtual++;
                    if (pontosComputador > rodadas / 2)
                    {
                        Console.WriteLine("O programa venceu");
                        fimDeJogo = true;
                    }

                    break;
            }
            if (fimDeJogo == true)
            {
                DesenhaCabecalho(3);
                if (pontosUsuario > pontosComputador)
                {
                    Console.WriteLine("Parabéns, você venceu!");
                }
                else
                {
                    Console.WriteLine("Você perdeu!");
                }
                Console.WriteLine();
                Console.WriteLine("Digite qaulquer tecla para continuar");
                Console.ReadLine();
                Start();

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Digite 1 para continuar ou 0 para sair");
                if (Int32.Parse(Console.ReadLine()) == 0)
                {
                    Start();
                }
            }
        }

    }
    public static int ExibeRodada()
    {
        string escolhaDoUsuario;
        string escolhaDoPrograma;
        int numero;

        string[] opcoes =  {
      "PEDRA",
      "PAPEL",
      "TESOURA"
    };
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Escolha entre pedra, papel ou tesoura:");
        escolhaDoUsuario = Console.ReadLine().ToUpper();


        Random rand = new Random();
        numero = rand.Next(3);
        escolhaDoPrograma = opcoes[numero];
        Console.WriteLine();
        Console.WriteLine("O programa escolheu: " + escolhaDoPrograma);


        if
        (escolhaDoPrograma == escolhaDoUsuario)
        {
            Console.WriteLine("Empate");
            return 0;
        }
        else if
      (escolhaDoUsuario == "PAPEL" && escolhaDoPrograma == "PEDRA")
        {
            Console.WriteLine("Parabéns! você venceu!");
            return 1;
        }
        else if
      (escolhaDoUsuario == "PEDRA" && escolhaDoPrograma == "TESOURA")
        {
            Console.WriteLine("Parabéns, você venceu!");
            return 1;
        }
        else if
        (escolhaDoUsuario == "TESOURA" && escolhaDoPrograma == "PAPEL")
        {
            Console.WriteLine("Parabéns, você venceu!");
            return 1;
        }
        else
        {
            Console.WriteLine("Você perdeu!");
            return 2;
        }
    }
}