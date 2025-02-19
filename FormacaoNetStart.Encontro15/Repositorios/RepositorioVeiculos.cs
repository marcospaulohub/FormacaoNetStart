using FormacaoNetStart.Encontro15.Entidades;
using System.Collections.Generic;

namespace FormacaoNetStart.Encontro15.Repositorios
{
    public class RepositorioVeiculos
    {
        private List<Veiculo> veiculos =
        [
        new Veiculo { Id = 1,  Marca = "Hyundai", Modelo = "HB20", Quilometragem = 90_000, Valor = 52_000 },
        new Veiculo { Id = 2,  Marca = "Toyota", Modelo = "Corolla", Quilometragem = 120_000, Valor = 98_000 },
        new Veiculo { Id = 3,  Marca = "Ford", Modelo = "Ka", Quilometragem = 75_000, Valor = 41_000 },
        new Veiculo { Id = 4,  Marca = "Chevrolet", Modelo = "Onix", Quilometragem = 65_000, Valor = 50_000 },
        new Veiculo { Id = 5,  Marca = "Volkswagen", Modelo = "Polo", Quilometragem = 80_000, Valor = 63_000 },
        new Veiculo { Id = 6,  Marca = "Fiat", Modelo = "Uno", Quilometragem = 100_000, Valor = 48_000 },
        new Veiculo { Id = 7,  Marca = "Honda", Modelo = "Civic", Quilometragem = 110_000, Valor = 97_000 },
        new Veiculo { Id = 8,  Marca = "Renault", Modelo = "Sandero", Quilometragem = 70_000, Valor = 50_000 },
        new Veiculo { Id = 9,  Marca = "Nissan", Modelo = "Versa", Quilometragem = 85_000, Valor = 79_000 },
        new Veiculo { Id = 10, Marca = "Jeep", Modelo = "Renegade", Quilometragem = 95_000, Valor = 110_000 },
        new Veiculo { Id = 11, Marca = "Hyundai", Modelo = "HB20S", Quilometragem = 75_000, Valor = 72_000 },
        new Veiculo { Id = 12, Marca = "Jeep", Modelo = "Compass", Quilometragem = 25_000, Valor = 180_000 },
        new Veiculo { Id = 13, Marca = "Toyota", Modelo = "Etios", Quilometragem = 25_000, Valor = 70_000 },
        new Veiculo { Id = 14, Marca = "Fiat", Modelo = "Mobi", Quilometragem = 45_000, Valor = 49_000 },
    ];

        public List<Veiculo> ListarTodos()
            => veiculos;

        public List<Veiculo> BuscarPorMarca(string marca)
        {
            var resultado = new List<Veiculo>();
            foreach (var v in veiculos)
            {
                if (v.Marca == marca)
                    resultado.Add(v);
            }
            return resultado;
        }
    }
}
