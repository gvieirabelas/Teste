using System;
using System.Collections.Generic;
using System.Linq;

namespace Tijolos
{

    public class Program
    {

        static void Main(string[] args)
        {

            //exemplo de entrada
            int[][] marks = new int[][]
                {
                new int[]{1,2,1,1,1},
                new int[]{3,1,2},
                new int[]{1,3,2},
                new int[]{2,4},
                new int[]{3,1,2},
                new int[]{1,3,1,1},
                new int[]{3,3},
                new int[]{3,2,1},
                new int[]{3,1,2},
                new int[]{6},
                };

            var contadorTijolos = retornaContagemTijolos(marks);
            Console.WriteLine("Numero de Tijolos cortados : " + contadorTijolos);
        }
        static int retornaContagemTijolos(int[][] marks)
        {
            int i, j;
            List<Contador> mostAppearance = new List<Contador>();
            //varre vetor i (linha) 
            for (i = 0; i < marks.Length; i++)
            {
                //varre vetor j (coluna)
                int sum = 0;
                for (j = 0; j < marks[i].Length; j++)
                {
                    //verifico se é diferente da ultima posição
                    if (j < marks[i].Length - 1)
                    {
                        //somo o valor da linha i até a posição da coluna j (diferente da ultima posição)tendo em vista que não pode
                            // contabilizar os extremos.
                        sum += marks[i][j];
                        //adiciono em uma lista qual a linha do tijolo que NÃO foi cortado, tendo em vista que o corte é vertical...
                        mostAppearance.Add(new Contador()
                        {
                            soma = sum,
                            linha = i,
                        });
                    }
                }
            }
            //eleger qual o que mais aparece dada a lista, 
            List<Contador> itemMaisAparece = mostAppearance.GroupBy(x => x.soma).OrderBy(x => x.Count()).Last().ToList();

            int contadorTijolos = 0;
            //verifico entre as linhas se existe entre os tijolos adicionados
            for (var y = 0; y < marks.Length; y++)
            {
                if (!itemMaisAparece.Exists(x => x.linha == y))
                    contadorTijolos++;
            }
            return contadorTijolos;

        }
    }
    
    public class Contador
    {
        public int soma { get; set; }
        public int linha { get; set; }
    }
}
