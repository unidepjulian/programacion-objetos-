namespace orientadoobjetos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var num1 = 7;
            var num2 = 5;
            operaciones op = new operaciones();
            sentencia st = new sentencia();

            // Operaciones matemáticas
            int suma1 = op.suma(num1, num2);
            int resta1 = op.resta(num1, num2);
            int multiplicacion1 = op.multiplicacion(num1, num2);
            double division1 = op.division(num1, num2);

            // Mostrar resultados en MessageBox
            MessageBox.Show($"Suma: {suma1}");
            MessageBox.Show($"Resta: {resta1}");
            MessageBox.Show($"Multiplicación: {multiplicacion1}");
            MessageBox.Show($"División: {division1}");

            // Sentencias de control
            bool esMayorNum1 = st.esMayor(num1, num2);
            bool esParNum1 = st.esPar(num1);
            bool esMayorNum2 = st.esMayor(num2, num1);
            bool esParNum2 = st.esPar(num2);

            // Mostrar resultados de las sentencias de control
            MessageBox.Show($"Es mayor el numero1 que numero2: {esMayorNum1}");
            MessageBox.Show($"El numero1 es par: {esParNum1}");
            MessageBox.Show($"Es mayor el numero2 que numero1: {esMayorNum2}");
            MessageBox.Show($"El numero2 es par : {esParNum2}");
            
           


        }
    }

    class operaciones   
    {
        public int suma(int a, int b)
        {
            return a + b;
        }

        public int resta(int a, int b)
        {
            return a - b;
        }

        public int multiplicacion(int a, int b)
        {
            return a * b;
        }

        public int division(int a, int b)
        {
            return (a / b);
        }
    }

    class sentencia
    {
        public bool esMayor(int a, int b)
        {
            return a > b;
        }

        public bool esPar(int num)
        {
            return num % 2 == 0;
        }

        public bool esPositivoYMayor(int a, int b)
        {
            return a > 0 && a > b;
        }
    }
}


