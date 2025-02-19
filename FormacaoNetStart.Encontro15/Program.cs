using FormacaoNetStart.Encontro15.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;


var repositorio = new RepositorioVeiculos();
var veiculos = repositorio.ListarTodos();





ImprimirLista(veiculos);




static void ImprimirLista(IEnumerable<object> registros)
{
    if (registros.Any())
    {
        foreach (var obj in registros)
            Console.WriteLine(obj);
    }
    else
    {
        Console.WriteLine("lista vazia!");
    }
}

