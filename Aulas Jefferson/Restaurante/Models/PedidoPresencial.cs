class PedidoPresencial : PedidoAbstrato
{
    public PedidoPresencial(Prato prato) : base(prato) { }
    public override decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var prato in pratos) {
            total += prato.ObterPreco();
        }
        return total;
    }
}