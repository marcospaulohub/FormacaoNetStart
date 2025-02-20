using FormacaoNetStart.Encontro15.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace FormacaoNetStart.Encontro15.Repositorios
{
    public class RepositorioVeiculos
    {
        private List<Veiculo> veiculos =
        [
        new Veiculo { Id = 1,  Marca = "Hyundai", Modelo = "HB20", Quilometragem = 90_000, Valor = 52_000, Placa = "BRA-2E19" },
        new Veiculo { Id = 2,  Marca = "Toyota", Modelo = "Corolla", Quilometragem = 120_000, Valor = 98_000, Placa = "RIO-4S32" },
        new Veiculo { Id = 3,  Marca = "Ford", Modelo = "Ka", Quilometragem = 75_000, Valor = 41_000 , Placa = "BRA-2A84"},
        new Veiculo { Id = 4,  Marca = "Chevrolet", Modelo = "Onix", Quilometragem = 65_000, Valor = 50_000, Placa = "FOR-01GH" },
        new Veiculo { Id = 5,  Marca = "Volkswagen", Modelo = "Polo", Quilometragem = 80_000, Valor = 63_000, Placa = "FOR-0031" },
        new Veiculo { Id = 6,  Marca = "Fiat", Modelo = "Uno", Quilometragem = 100_000, Valor = 48_000, Placa = "OTM-8H32" },
        new Veiculo { Id = 7,  Marca = "Honda", Modelo = "Civic", Quilometragem = 110_000, Valor = 97_000, Placa = "FOR-7733" },
        new Veiculo { Id = 8,  Marca = "Renault", Modelo = "Sandero", Quilometragem = 70_000, Valor = 50_000, Placa = "FOR-8832" },
        new Veiculo { Id = 9,  Marca = "Nissan", Modelo = "Versa", Quilometragem = 85_000, Valor = 79_000, Placa = "BRA-9K00" },
        new Veiculo { Id = 10, Marca = "Jeep", Modelo = "Renegade", Quilometragem = 95_000, Valor = 110_000, Placa = "HQW-2PO8" },
        new Veiculo { Id = 11, Marca = "Hyundai", Modelo = "HB20S", Quilometragem = 75_000, Valor = 72_000, Placa = "FPT-8801" },
        new Veiculo { Id = 12, Marca = "Jeep", Modelo = "Compass", Quilometragem = 25_000, Valor = 180_000, Placa = "LSN-4149" },
        new Veiculo { Id = 13, Marca = "Toyota", Modelo = "Etios", Quilometragem = 25_000, Valor = 70_000, Placa = "ABC-7893" },
        new Veiculo { Id = 14, Marca = "Fiat", Modelo = "Mobi", Quilometragem = 45_000, Valor = 49_000, Placa = "HMG-0228" },
    ];

        public decimal ValorTotalEstoque => veiculos.Sum(x => x.Valor);

        public List<Veiculo> ListarTodos(string? ordenacao = null)
        {
            return ordenacao switch
            {
                "marca" => veiculos.OrderBy(x => x.Marca).ToList(),
                "modelo" => veiculos.OrderBy(x => x.Modelo).ToList(),
                _ => veiculos.OrderBy(x => x.Id).ToList()
            };
        }

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

        public List<Veiculo> BuscarPorMarcaEModelo(string? marca, string? modelo)
        {
            var resultado = veiculos;

            if (!string.IsNullOrWhiteSpace(marca))
                resultado = veiculos.Where(x => x.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrWhiteSpace(modelo))
                resultado = resultado.Where(x => x.Modelo.Contains(modelo, StringComparison.OrdinalIgnoreCase)).ToList();

            return resultado;
        }

        public Veiculo? BuscarPorPlaca(string placa)
        {
            if (placa?.Length != 8)
                throw new ArgumentException("Placa inválida");

            return veiculos.SingleOrDefault(v => v.Placa == placa);
        }

        public void Adicionar(Veiculo veiculo)
        {
            if(!(veiculo.Placa.Length == 8))
                throw new ArgumentException("Placa inválida");
            

            if (veiculos.Any(x => x.Placa.ToUpper() == veiculo.Placa.ToUpper()))
                throw new ArgumentException("Placa já cadastrada");

            veiculo.Id = veiculos.Max(x => x.Id) + 1;
            veiculo.Placa = veiculo.Placa.ToUpper();

            veiculos.Add(veiculo);
        }
    }
}
