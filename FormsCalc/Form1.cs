namespace FormsCalc
{
    public partial class Form1 : Form
    {
        private float valueBuffer;
        private char operationBuffer;
        private bool clearDisplay;
        public Form1()
        {
            InitializeComponent();
            valueBuffer = 0;
            clearDisplay = false;
        }

        private void DigitPressed(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (clearDisplay)
            {
                displayTextBox.Text = btn.Text;
                clearDisplay = false;
            }
            else
            {
                displayTextBox.Text += btn.Text;
            }

        }

        private void OperationPressed(object sender, EventArgs e)
        {
            clearDisplay = true;
            Button btn = (Button)sender;
            char opperation = btn.Text[0];
            float displayValue = float.Parse(displayTextBox.Text);
            switch (operationBuffer)
            {
                case '+':
                    valueBuffer += displayValue;
                    break;
                case '-':
                    valueBuffer -= displayValue;
                    break;
                case '*':
                    valueBuffer *= displayValue;
                    break;
                case '/':
                    valueBuffer /= displayValue;
                    break;
                default:
                    valueBuffer = displayValue;
                    break;
            }
            if (opperation == '=')
            {
                displayTextBox.Text = valueBuffer.ToString();
            }
            else
            {
                operationBuffer = opperation;
            }

        }

        private void ClearPressed(object sender, EventArgs e)
        {
            valueBuffer = 0;
            displayTextBox.Text = "0";
            operationBuffer = '!';
        }
    }
}