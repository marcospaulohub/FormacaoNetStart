namespace FormacaoNetStart.Encontro15.Entidades
{
    public class Veiculo
    {
        public int Id { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public decimal Valor { get; set; }
        public int Quilometragem { get; set; }

        public override string ToString()
            => $"{Id:00} {Marca.PadRight(10)} {Modelo.PadRight(10)} {Quilometragem.ToString("#,##").PadLeft(7)} km{Valor.ToString("#,##0.00").PadLeft(12)}";
    }
}
