abstract class PedidoAbstrato
{
    protected string numeroPedido;
    private int contador = 0;
    protected List<Prato> pratos = new List<Prato>();
    public PedidoAbstrato(Prato prato)
    {
        if (prato != null) {
            pratos.Add(prato);
        }
        contador++;
        numeroPedido = contador.ToString("D5");
    }
    public PedidoAbstrato()
    {
        contador++;
        numeroPedido = contador.ToString("D5");
    }

    public abstract decimal CalcularTotal();
    public void AdicionarPrato(Prato prato)
    {
        pratos.Add(prato);
    }
    public void RemoverPrato(string nomePrato)
    {
        pratos.RemoveAll(p => p.ObterNome() == nomePrato);
    }
    public string ObterNumeroPedido()
    {
        return numeroPedido;
    }
    public List<Prato> ObterPratos()
    {
        return pratos;
    }
}