class PedidoDelivery : PedidoAbstrato
{
    private decimal taxaFixa = 8m;
    public PedidoDelivery(Prato prato) : base(prato) { }
    public PedidoDelivery() : base() { }
    public override decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var prato in pratos) {
            total += prato.ObterPreco();
        }
        return total + taxaFixa;
    }
}