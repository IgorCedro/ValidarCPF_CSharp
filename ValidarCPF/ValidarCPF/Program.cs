using System;

namespace ValidarCPF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaração de variáveis
            //Soma e Verificador são long para evitar ter que convertar um int para long
            long cpf, soma, verificador;
            long[] digito = new long[11];
            int cont;

            //Loop do programa
            do
            {
                //Atribuindo o valor de Soma fora da declaração para que quando o programa reincie, a variável volta a ser zero.
                soma = 0;

                //Entrada de dados
                do
                {
                    Console.WriteLine("Digite um CPF: ");
                    cpf = long.Parse(Console.ReadLine());

                    if (cpf < 0)
                    {
                        Console.Write("\n");
                        Console.WriteLine("Não existe CPF negativo");
                        Console.Write("\n");
                    }
                }
                while (cpf < 0);

                Console.Write("\n");

                //Separando o CPF digitado em digítos armazenados em um vetor
                for (int i = 0; i < 11; i++)
                {
                    digito[i] = cpf % 10;
                    cpf /= 10;
                }

                //Operação para encontrar o primeiro dígito verificador
                //Multiplicações e soma de todos os resultados
                for (int i = 2; i < 11; i++)
                {
                    soma += digito[i] * i;
                }
                //Primeiro dígito verificador é resultado da subtração entre 11 e o resultado da divisão com resto da Soma por 11
                verificador = 11 - (soma % 11);
                //Se o resultado da conta for 10 é por que o dígito é 0
                if (verificador == 10)
                {
                    verificador = 0;
                }

                //Verifica se o primeiro dígito verificador é válido
                if (verificador != digito[1])
                {
                    Console.WriteLine("CPF Inválido!");
                }
                else
                {
                    //Operação para encontrar o segundo dígito verificador
                    //Multiplicações e soma de todos os resultados
                    
                    //Limpando a variavél Soma
                    soma = 0;

                    for (int i = 1; i < 11; i++)
                    {
                        soma += digito[i] * (i + 1);
                    }
                    //Segundo dígito verificador é resultado da subtração entre 11 e o resultado da divisão com resto da Soma por 11
                    verificador = 11 - (soma % 11);
                    //Se o resultado da conta for 10 é por que o dígito é 0
                    if (verificador == 10)
                    {
                        verificador = 0;
                    }

                    //Verifica se o segundo dígito verificador é válido
                    if (verificador != digito[0])
                    {
                        Console.WriteLine("CPF Inválido!");
                    }
                    else
                    {
                        Console.WriteLine("CPF Válido!");
                    }
                }

                Console.Write("\n");

                //Loop de verificação de dados, para sair/continuar o programa
                do
                {
                    Console.WriteLine("Se deseja continuar, digite '1'.");
                    Console.WriteLine("Se deseja sair, digite '0'.");
                    cont = int.Parse(Console.ReadLine());
                }
                while (cont != 0 && cont != 1);

                Console.Clear();
            }
            while (cont == 1);
        }
    }
}
