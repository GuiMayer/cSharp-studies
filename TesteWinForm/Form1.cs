namespace TesteWinForm;

public partial class Form1 : Form
{
    public Label label;
    public Button button;
    

    public Form1()
    {
        InitializeComponent();
        InitializeCustomComponents();
    }

    private void InitializeCustomComponents()
    {
        // Criar e configurar um Label para exibir o texto
        label = new Label();
        label.Text = "Olá, Mundo!";
        label.AutoSize = true;
        label.Font = new System.Drawing.Font("Arial", 16);
        label.Location = new System.Drawing.Point(0, 0); // Posicionar o label no formulário

        // Adicionar o Label ao formulário
        this.Controls.Add(label);
    
        // Criar e configurar um Button para alterar o texto do Label
        button = new Button
        {
            Text = "Mudar Texto",
            Location = new System.Drawing.Point(50, 100) // Posicionar o botão no formulário
        };
        button.Click += Button_Click; // Associar o evento Click do botão ao método Button_Click

        // Adicionar o Label e o Button ao formulário
        this.Controls.Add(label);
        this.Controls.Add(button);
    }

    // Método para lidar com o evento Click do botão
    private void Button_Click(object sender, EventArgs e)
    {
        label.Text = "Texto Alterado!"; // Alterar o texto do Label
    }
}