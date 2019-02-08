using System;
using System.Collections.Generic;

////
// Author: Ivo Aluízio Stinghen Filho
// Estrategia do parser:  [Esquerda] [Meio] [Direita]
// Esquerda = 1 elemento à esquerda.
// Meio = n elementos de valores iguais
// Direito = 1 elemento à direita.
////

public class CalculateCastles
{
    private int p, q;	//intervalo
    private int e, d;	//esquerda e direia (valores assumem 1 se for ''subida'' e -1 se for uma descida.
    private int N;		//numero de posições
    private int score;  //total de pontos 
    private List<int> castlePositions = new List<int>();

    public List<int> GetCastlePositions() => this.castlePositions; 


    public void Main()
    {
        //*Debug: Testes de input*
        int[] teste = { 3, 2, 2, 3, 2, 2, 4 };
        //int[] teste  = {3};
        //int[] teste  = {1,2,2,3};
        solution(teste);
    }

    public int solution(int[] A)
    {
        N = A.Length; p = 0; q = 0; e = -2; d = -2; score = 0;
        while (q < N)
        {
            e = -2; d = -2;
            Esq(A); Meio(A); Dir(A);
            if (e == -1 && d == 1 || e == 1 && d == -1 || e == 0 || d == 0) score += q - p + 1;
            q++;
            p = q;
        }
        return score;
    }

    public void Esq(int[] A)
    {
        if (p == 0) e = 0;
        else if (A[p - 1] < A[p]) e = 1;
        else if (A[p - 1] > A[p]) e = -1;
    }

    public void Dir(int[] A)
    {
        if (q >= N - 1) d = 0;
        else if (A[q + 1] < A[q]) d = -1;
        else if (A[q + 1] > A[q]) d = 1;
    }

    public void Meio(int[] A)
    {
        for (int i = p + 1; i < N - 1; i++)
        {
            if (A[i] != A[p]) return;
            q++;
        }
    }

    public void print(string s)
    {
        Console.WriteLine(s);
    }

}