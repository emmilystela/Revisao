using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5]; // declarando a quantidade de array
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario) //ToDo é o que ele faz.
                {
                    case "1":
                        //ToDo: adicionar aluno
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno(); //instanciando; aqui que cai um array
                        aluno.Nome = Console.ReadLine(); //setando o nome no console

                        Console.WriteLine("Insira aqui a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))//tryparse retorna um valor booleando (consegue ou nao retornar o valor da string em decimal)
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno; // o array alunos, coloco a posição indiceAluno e pega o aluno e coloca nessa posição
                        indiceAluno++; // aqui ele vai pra proxima posição do array quando for acrescentado um novo aluno
                        break;

                    case "2":
                        //ToDo: listar alunos
                        foreach (var a in alunos)//pra cada a (aluno) vai imprimir o nome do aluno e a nota 
                        {
                            if (!string.IsNullOrEmpty(a.Nome)) //é um método de string que passará o valor de uma string e ele retornara se é vazio mostrando true or false. 
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}"); // esse $ antes chama string interpolation
                            }
                        }
                        break;

                    case "3":
                        //ToDo: calcular media geral
                        decimal notaTotal = 0;
                        var nrAlunos =0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                             if (!string.IsNullOrEmpty(alunos[i].Nome))
                             {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++; //aqui ele incrementa o numero de alunos pra divisão do final 
                             }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral <= 2)
                        {
                            conceitoGeral = Conceito.E;
                        } else if (mediaGeral <= 4)
                        {
                            conceitoGeral = Conceito.D;
                        }else if (mediaGeral <= 6)
                        {
                            conceitoGeral = Conceito.C;
                        }else if (mediaGeral <= 8)
                        {
                            conceitoGeral = Conceito.B;
                        }else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"Média geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(); // vai desparar uma exceção que o valor informado está fora dos cases de opção.
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario() //vai cair aqui depois do siwtch pra dar opção pro usuario escolher novamente
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();// vai deixar uma linha em branco

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
