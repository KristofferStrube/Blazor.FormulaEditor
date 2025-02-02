using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;
using KristofferStrube.Blazor.FormulaEditor.Extensions;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class NumericExpression : NumberReturningExpression
{
    public override Type SVGPresenter => typeof(NumericExpressionSVGPresenter);

    public double Value { get; set; }

    public bool Parenthesis { get; set; } = false;

    public override List<(string Icon, string Text, Action Action)> ExtraExpressionActions()
    {
        return [
            ("( )", Parenthesis ? "Remove Parenthesis" : "Add Parenthesis", () => Parenthesis = !Parenthesis)
        ];
    }

    public override double Evaluate()
    {
        return Value;
    }

    public override (double Width, double Height) GetDimensions()
    {
        return ((Parenthesis ? BinaryOperator.ParenthesisWidth * 2 : 0) + Value.AsString().Length * 12, 20);
    }
}
