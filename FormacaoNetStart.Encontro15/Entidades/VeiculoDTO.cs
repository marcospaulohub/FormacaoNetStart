namespace FormacaoNetStart.Encontro15.Entidades
{
    class VeiculoDTO
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public override string ToString()
            => $"Marca: {Marca.PadRight(10)} Modelo: {Modelo.PadRight(10)}";
    }
}
