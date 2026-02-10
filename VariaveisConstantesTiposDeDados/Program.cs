using System.Runtime.InteropServices.JavaScript;

namespace VariaveisConstantesTiposDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Declarando Váriaveis
            /*
             *  declaração básica de váriavel 
             *  <tipo> <identificador> = <valor>
             */
            int numero = 0;
            string nome = "Antonio";
            string[] nomes = { "antonio", "pedro", "paulo" };
            List<string> lista = new List<string>();
            double preco = 10.50;

            /*
             * o var não muda o tipo da variável em tempo de execução. 
             * O C# continua sendo uma linguagem fortemente tipada.
             * Inicialização imediata: Você não pode apenas declarar a variável; precisa atribuir um valor na mesma linha.
             * Não pode ser nulo na atribuição: O compilador não consegue adivinhar o tipo se você passar null logo de cara.
             * Apenas escopo local: Ele funciona dentro de métodos, loops e blocos using.
             * Você não pode usar var para declarar campos de uma classe (atributos) ou parâmetros de funções.
             */
            var mensagem = "Olá";
            var precoUnit = 19.90m;


            #endregion

            #region Tipos numéricos integrais (Inteiros)
            // Inteiros com sinal
            sbyte num1 = 1; // 8 bits, de -128 a 127
            short num2 = 2; // 16 bits, - 32.768 a 32.768
            int num3 = 3; // 32 bitys, -2.147.483.648 a 2.147.483.647
            long num4 = 4; // 64 bits, -9.223.372.036.854.775.808 a 9223.372.036.854.775.807 

            // Inteiros sem sinal
            byte num5 = 5; // 8 bits intervalo de 0 a 255
            ushort num6 = 6; //16 bits, intervalo de 0 a 65.535
            uint num7 = 7; // 32 bits, intervalo de 0 a 4.294.967.295
            ulong num8 = 8; // 64 bits,intervalo de 0 a 0 a 18.446.744.073.709.551.615 

            #endregion

            #region Tipos numéricos de ponto flutuante (reais)
            /*
             * O sufixo em um literal real determina seu tipo:
             *      Um literal sem sufixo ou com o d sufixo é D um double.
             *      Um literal com o f sufixo ou F é um float.
             *      Um literal com o m sufixo ou M é um decimal.
             */

            float num9 = 9; // 32 bits, de 1,5 x 10^45 a 3,4 x 10^38, precisão de 7 dígitos
            double num10 = 10; // 64 bits, de 5.0 × 10^324 a 1.7 × 10^308, precisão de 16 dígitos
            decimal num11 = 11; // 128 bits,  de 1,0 x 10^28 a 7.9228 x 10^28, precisão de 28 dígitos 
            #endregion

            #region Tipo Char (caractere)
            char letra = 'A';
            /*
             * um literal de caractere.
             * uma sequência de escape Unicode, que é \u seguida pela representação hexadecimal de quatro símbolos 
             *  de um código de caractere.
             * uma sequência de escape hexadecimal, que é \x seguida pela representação hexadecimal de um código de caractere.
             */
            var chars = new[]
            {
                'j',
                '\u006A',
                '\x006A',
                (char)106,
            };
            Console.WriteLine(string.Join(" ", chars));  // output: j j j j
            Console.ReadKey();
            #endregion

            #region Tipo Boolean (Verdadeiro | Falso)
            /*
             * Valores possíveis: true ou false.
             * Tamanho: Ocupa 1 byte (8 bits) de memória. Embora um bit bastasse, 
               o processador lida melhor com endereços de bytes inteiros.
             * Valor padrão: O valor default de um bool é false.
             */
            bool estaChovendo = true;
            bool usuarioLogado = false;

            //Operador Descrição   Exemplo
            //5 == 5(true)
            //5 != 3(true)
            //10 > 20(false)
            //10 <= 10(true)

            // Operadores Lógicos
            //Você pode combinar múltiplos valores booleanos para criar lógicas complexas usando a álgebra booleana.
            //AND(&&): Retorna true apenas se ambos forem verdadeiros.
            //OR(||): Retorna true se pelo menos um for verdadeiro.
            //NOT(!): Inverte o valor(o que é true vira false).
            bool temIdade = true;
            bool temAutorizacao = false;

            // Precisa de ambos para entrar
            bool podeEntrar = temIdade && temAutorizacao; // false

            /*
             * O Booleano Anulável (bool?)
             * Em cenários como integração com bancos de dados, você pode precisar de um terceiro estado: 
                o desconhecido ou nulo. Para isso, usamos o bool?.
             */

            bool? respostaPesquisa = null; // Pode ser true, false ou null

            if (respostaPesquisa == true)
            {
                // Código para Sim
            }
            else if (respostaPesquisa == false)
            {
                // Código para Não
            }
            else
            {
                // Usuário não respondeu
            }

            bool check = true;
            Console.WriteLine(check ? "Checked" : "Not checked");  // output: Checked

            Console.WriteLine(false ? "Checked" : "Not checked");  // output: Not checked

            Console.ReadKey();
            #endregion

            #region Tipo String
            /*
             * Características Principais
             *      Tipo de Referência: Diferente de um int ou bool, a string vive na Heap da memória.
             *      Imutabilidade: Este é o conceito mais importante. Uma vez criada, uma string não pode ser alterada. 
             *      Toda operação que parece "mudar" a string (como Replace ou ToUpper) na verdade cria uma nova string na memória.
             *      Iterável: Você pode tratar uma string como uma coleção de caracteres (char). Ex: minhaString[0].
             */
            string texto = "Cadeia de Caracteres \n aqui é uam nova linha";
            string testoDois = null;
            string caminhoMelhor = @"C:\Users\Documentos"; // O @ mantém as barras como estão

            /*
             * Manipulação e Formatação
             *   Existem três formas principais de "montar" strings:
             *      Concatenação: string nomeCompleto = nome + " " + sobrenome; (Ineficiente em loops).
             *      String.Format: string s = string.Format("Olá, {0}", nome);
             *      Interpolação ($): A forma moderna e mais legível.
             *      Literais Regulares e de Escape
                        Usam aspas duplas e caracteres de escape (como \n para nova linha ou \t para tabulação).

            Comparação e Busca
Para comparar strings, evite usar apenas == se precisar ignorar maiúsculas/minúsculas. Use o método Equals:

Busca: texto.Contains("termo"), texto.StartsWith("A"), texto.EndsWith("Z").

Comparação Segura: string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);

Limpeza: texto.Trim() (remove espaços em branco nas pontas).
            */

            string saudacao = $"Olá, {nome}. Hoje é {DateTime.Now:dd/MM/yyyy}";
            //Console.WriteLine(saudacao);

            string json = """
            {
                "usuario": "Gemini",
                "status": "Ativo"
            }
            """;
            Console.WriteLine(json);



            Console.ReadKey();

            #endregion
            #region Tipos estrutura (struct)


            #endregion

        }
    }
}
