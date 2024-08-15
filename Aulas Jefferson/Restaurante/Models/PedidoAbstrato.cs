abstract class PedidoAbstrato
{
    protected string numeroPedido;
    private static int contador = 0;
    protected List<Prato> pratos;
    public PedidoAbstrato(Prato prato)
    {
        pratos = new List<Prato>();
        if (prato != null) {
            pratos.Add(prato);
        }
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
}