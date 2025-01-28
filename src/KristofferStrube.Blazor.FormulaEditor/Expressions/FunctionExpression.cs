using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class FunctionExpression : NumberReturningExpression
{
    public const double ParenthesisWidth = 6;

    public override Type SVGPresenter => typeof(FunctionExpressionSVGPresenter);

    public override List<(string Icon, string Text, Action Action)> ExtraExpressionActions()
    {
        return [
            ("( )", Parenthesis ? "Remove Parenthesis" : "Add Parenthesis", () => Parenthesis = !Parenthesis)
        ];
    }

    public NumberReturningExpression? Input { get; set; }

    public required Function Function { get; set; }

    public bool Parenthesis { get; set; } = true;

    public override double Evaluate() => Function.Expression.Invoke(Input!.Evaluate());

    public override (double Width, double Height) GetDimensions()
    {
        (double Width, double Height) inputDimensions = Input?.GetDimensions() ?? (20, 20);

        return (inputDimensions.Width + (Parenthesis ? ParenthesisWidth * 2 : 0) + Function.Name.Length * 12, inputDimensions.Height);
    }
}
