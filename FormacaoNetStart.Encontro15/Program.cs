using FormacaoNetStart.Encontro15.Entidades;
using FormacaoNetStart.Encontro15.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;


var repositorio = new RepositorioVeiculos();
var veiculos = repositorio.ListarTodos();

//static void ImprimirLista(IEnumerable<object> registros)
//{
//    if (registros.Any())
//    {
//        foreach (var obj in registros)
//            Console.WriteLine(obj);
//    }
//    else
//    {
//        Console.WriteLine("lista vazia!");
//    }
//}

//ImprimirLista(veiculos);
//veiculos.ForEach(Console.WriteLine);

#region Retornando múltiplos registros

var veiculosToyota = veiculos.Where(v => v.Marca == "Toyota");
var veiculosAte50rs = veiculos.Where(v => v.Valor <= 50_000);
var veiculosDe50rsA70rs = veiculos.Where(v => v.Valor >= 50_000 && v.Valor <= 70_000);

#endregion

#region Notação de SQL

/*
//Notação de SQL
var veiculosDe50rsA70rsSQL = from v in veiculos
                              where 
                                v.Valor >= 50_000 && 
                                v.Valor <= 70_000 &&
                                v.Marca == "Toyota"
                             select v;

//Notação de SQL retornando um objeto dinâmico anônimo
var veiculosDe50rsA70rsSQL2 = from v in veiculos
                             where
                               v.Valor >= 50_000 &&
                               v.Valor <= 70_000 &&
                               v.Marca == "Toyota"
                             select new { v.Marca, v.Modelo};

//Notação de SQL retornando um objeto DTO
var veiculosDe50rsA70rsSQL3 = from v in veiculos
                              where
                                v.Valor >= 50_000 &&
                                v.Valor <= 70_000 &&
                                v.Marca == "Toyota"
                              select new VeiculoDTO { Marca = v.Marca, Modelo = v.Modelo };

*/

#endregion

#region Definindo a forma do retorno

//Exibe toda a lista somente com a marca.
var listaDeMarcas = veiculos.Select(v => v.Marca);

//Exibe toda a lista somente com a marca removendo os repetidos.
var listaDeMarcasSemRepetidos = veiculos.Select(v => v.Marca).Distinct();

//Exibe toda a lista mudando o objeto de retorno.
var veiculosDtos = veiculos.Select(v => new VeiculoDTO { Marca = v.Marca, Modelo = v.Modelo });

#endregion

#region Retorna um único registro

//Retorna o primeiro objeto da lista.
var primeiroVeiculoDaLista = veiculos.First();
//Console.WriteLine(primeiroVeiculoDaLista);

//Retorna o ultimo objeto da lista.
var ultimoVeiculoDaLista = veiculos.Last();
//Console.WriteLine(ultimoVeiculoDaLista);

var fiatMobi = veiculos.First(v => v.Marca == "Fiat" && v.Modelo == "Mobi");
//Console.WriteLine(fiatMobi);
var fiatToro = veiculos.FirstOrDefault(v => v.Marca == "Fiat" && v.Modelo == "Toro");
//Console.WriteLine(fiatToro?.Modelo);

var ultimoHyundai = veiculos.Last(v => v.Marca == "Hyundai");
//Console.WriteLine(ultimoHyundai);

var ultimaFerrari = veiculos.LastOrDefault(v => v.Marca == "Ferrari");
//Console.WriteLine(ultimaFerrari?.Marca);

//Para condições de um unico registo se utiliza o single
var honda = veiculos.Single(v => v.Marca == "Honda");
//Console.WriteLine(honda);
#endregion

#region Condições globais/gerais

var colecaoNaoVazia = veiculos.Any(); // Equivale a Count > 0.

// retorna true ou false para essa condição.
// Any significa que pelo menos um registro atende a essa condição.
// Existe pelo menos um veiculo com valor menor ou igual a 50_000?
var algumVeiculoAte50rs = veiculos.Any(v => v.Valor <= 50_000);
//Console.WriteLine(algumVeiculoAte50rs);

// Para o caso onde quero verificar se todos atendem a uma condisão
// All significa que todos devem atender a uma condição
var algumVeiculoMenorque100rs = veiculos.All(v => v.Valor != 0);
//Console.WriteLine(algumVeiculoMenorque100rs);


#endregion

#region Ordenação
var ordenadoPorMarca = veiculos.OrderBy(v => v.Marca);
//ImprimirLista(ordenadosPorMarca);
var ordenadoPorMarcaDecrescente = veiculos.OrderByDescending(v => v.Marca);
//ImprimirLista(ordenadorPorMarcaDecrescente);

//Ordenar por dois campos
//Ordenar por Marca e Valor
var ordenadoPorMarcaEValor = veiculos.OrderBy(v => v.Marca).ThenBy(v => v.Valor);
//ImprimirLista(ordenadoPorMarcaEValor);

var ordenadoPorMarcaEValorDecresente = veiculos.OrderBy(v => v.Marca).ThenByDescending(v => v.Valor);
//ImprimirLista(ordenadoPorMarcaEValorDecresente);

#endregion

#region Agregação

var valorTotalEstoque = veiculos.Sum(v => v.Valor);
//Console.WriteLine("Valor total do estoque: " + valorTotalEstoque);

var valorTotalEstoqueComDescontoDe10porcento = veiculos.Sum(v =>v.Valor * 0.9m);
//Console.WriteLine("Valor total do estoque com desconto de 10%: " + valorTotalEstoqueComDescontoDe10porcento);

//MAX
//Retorna o maior valor
var maiorValor = veiculos.Max(v => v.Valor);
//Console.WriteLine(maiorValor);

//Retorna o objeto de maior valor
var veiculoDeMaisCaro = veiculos.MaxBy(v => v.Valor);
//Console.WriteLine(veiculoDeMaisCaro);

//MIN
//Retorna o menor valor
var menorValor = veiculos.Min(v => v.Valor);
//Console.WriteLine(menorValor);

//Retorna o objeto de menor valor
var veiculoMaisBarato = veiculos.MinBy(v => v.Valor);
//Console.WriteLine(veiculoMaisBarato);

//AVG
var valorMedio = veiculos.Average(v => v.Valor);
//Console.WriteLine(valorMedio);

//COUNT
var quantidadeToyota = veiculos.Count(v => v.Marca == "Toyota");
//Console.WriteLine(quantidadeToyota);

#endregion

#region Agrupamento

//Console.WriteLine("*************** Agrupamento ****************************");

//var veiculosPorMarca = veiculos.GroupBy(v => v.Marca);

//foreach(var marca in veiculosPorMarca)
//{
//    Console.WriteLine(marca.Key);

//    foreach(var veiculo in marca)
//    {
//        Console.WriteLine(veiculo);
//    }

//    Console.WriteLine("Valor total: " + marca.Sum(v => v.Valor).ToString("#,##0.00"));
//    Console.WriteLine();
//}

//Console.WriteLine("********************************************************");

#endregion


#region Resolução de exercícios propostos


//b)
//var v = repositorio.BuscarPorPlaca("FOR-7733");
//var v2 = repositorio.BuscarPorPlaca("FOR");

//c)
//repositorio.Adicionar(new Veiculo { Marca = "Honda", Modelo = "New Civic", Quilometragem = 15_000, Valor = 23_000, Placa = "for-1234" });
//veiculos = repositorio.ListarTodos();
//veiculos.ForEach(Console.WriteLine);


//d)
//repositorio.BuscarPorMarcaEModelo("Honda","").ForEach(Console.WriteLine);

//e)
//Console.WriteLine(repositorio.ValorTotalEstoque);

//f)
//repositorio.ListarTodos("marca")
//           .ToList()
//           .ForEach(Console.WriteLine);

repositorio.ListarTodos()
           .ToList()
           .ForEach(Console.WriteLine);


#endregion

