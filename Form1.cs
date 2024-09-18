namespace orientadoobjetos
{
    public partial class Form1 : Form
    {
        int resultado = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var num1 = 7; 
            var num2 = 5;
            int resultado = suma(num1,num2);

        }
        private int suma(int a, int b) 
        {

        int totalsuma = a + b;
        return totalsuma;
        }
    }
}
