namespace TRABALHOCALCULO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Lê os valores dos lados
                double ladoA = double.Parse(txtLadoA.Text);
                double ladoB = double.Parse(txtLadoB.Text);
                double ladoC = double.Parse(txtLadoC.Text);

                // Verifica se forma um triângulo válido
                if (!EhTrianguloValido(ladoA, ladoB, ladoC))
                {
                    lblResultado.Text = "❌ Estes lados NÃO formam um triângulo!";
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                    lblTipo.Text = "";
                    lblArea.Text = "";
                    return;
                }

                lblResultado.Text = "✓ É um triângulo válido!";
                lblResultado.ForeColor = System.Drawing.Color.DarkGreen;

                // Determina o tipo do triângulo
                string tipo = DeterminarTipo(ladoA, ladoB, ladoC);
                lblTipo.Text = "Tipo: " + tipo;

                // Calcula a área usando Fórmula de Heron
                double area = CalcularArea(ladoA, ladoB, ladoC);
                lblArea.Text = string.Format("Área: {0:F2} unidades²", area);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, digite valores numéricos válidos!",
                    "Erro de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EhTrianguloValido(double a, double b, double c)
        {
            // Verifica se os lados são positivos
            if (a <= 0 || b <= 0 || c <= 0)
                return false;

            // Verifica a desigualdade triangular
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        private string DeterminarTipo(double a, double b, double c)
        {
            if (a == b && b == c)
            {
                return "🔺 Equilátero (todos os lados iguais)";
            }
            else if (a == b || b == c || a == c)
            {
                return "🔺 Isósceles (dois lados iguais)";
            }
            else
            {
                return "🔺 Escaleno (todos os lados diferentes)";
            }
        }

        private double CalcularArea(double a, double b, double c)
        {
            // Fórmula de Heron
            double s = (a + b + c) / 2; // semi-perímetro
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}