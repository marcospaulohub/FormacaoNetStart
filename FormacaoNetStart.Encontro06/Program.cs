using System;

int BuscarElemento(int[] elementos, int elementoBuscado)
{
    for (int i = 0; i < elementos.Length; i++)
    {
        if (elementos[i] == elementoBuscado)
        {
            return i;
        }
    }
    return -1;
}


int[] numeros = [3, 9, 5, 1, 2, 6, 7];
int numeroBuscado = 22;

var indice = BuscarElemento(numeros, numeroBuscado);

Console.WriteLine($"{(indice >= 0 ? "ENCONTRADO" : "NÃO ENCONTRADO")}");



