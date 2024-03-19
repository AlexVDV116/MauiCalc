using System.Globalization;

namespace MauiCalc;

public partial class MainPage
{
    private string CurrentInput { get; set; } = String.Empty;

    private string RunningTotal { get; set; } = String.Empty;

    private string? _selectedOperator;

    private readonly string[] _operators = { "+", "-", "/", "X", "=" };

    private readonly string[] _numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "." };

    private bool _resetOnNextInput;

    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var btn = sender as Button;

        var thisInput = btn.Text;

        if (_numbers.Contains(thisInput))
        {
            if (_resetOnNextInput)
            {
                CurrentInput = btn.Text;
                _resetOnNextInput = false;
            }
            else
            {
                CurrentInput += btn.Text;
            }

            LCD.Text = CurrentInput;
        }
        else if (_operators.Contains(thisInput))
        {
            var result = PerformCalculation();

            if (thisInput == "=")
            {
                CurrentInput = result.ToString(CultureInfo.CurrentCulture);

                LCD.Text = CurrentInput;

                RunningTotal = string.Empty;
                _selectedOperator = string.Empty;

                _resetOnNextInput = true;
            }
            else
            {
                RunningTotal = result.ToString(CultureInfo.CurrentCulture);

                _selectedOperator = thisInput;

                CurrentInput = string.Empty;

                LCD.Text = CurrentInput;
            }
        }
    }


    private double PerformCalculation()
    {
        double currentVal;
        double.TryParse(CurrentInput, out currentVal);

        double runningVal;
        double.TryParse(RunningTotal, out runningVal);

        double result;

        switch (_selectedOperator)
        {
            case "+":
                result = runningVal + currentVal;
                break;
            case "-":
                result = runningVal - currentVal;
                break;
            case "X":
                result = runningVal * currentVal;
                break;
            case "/":
                result = runningVal / currentVal;
                break;
            default:
                result = currentVal;
                break;
        }

        return result;
    }
}