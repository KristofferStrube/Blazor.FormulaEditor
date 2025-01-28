using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public abstract class BinaryOperator : NumberReturningExpression
{
    public const double OperatorWidth = 12;
    public const double OperatorMargin = 3;
    public const double OperatorFullSpace = OperatorWidth + OperatorMargin * 2;
    public const double ParenthesisWidth = 6;

    public override Type SVGPresenter => typeof(BinaryOperatorSVGPresenter);

    public override List<(string Icon, string Text, Action Action)> ExtraExpressionActions()
    {
        return [
            ("( )", Parenthesis ? "Remove Parenthesis" : "Add Parenthesis", () => Parenthesis = !Parenthesis)
        ];
    }

    public abstract string Operator { get; }

    public bool Parenthesis { get; set; } = false;

    public NumberReturningExpression? First { get; set; }
    public NumberReturningExpression? Second { get; set; }

    public override (double Width, double Height) GetDimensions()
    {
        (double Width, double Height) firstDimensions = First?.GetDimensions() ?? (20, 20);
        (double Width, double Height) secondDimensions = Second?.GetDimensions() ?? (20, 20);

        return ((Parenthesis ? ParenthesisWidth * 2 : 0) + firstDimensions.Width + secondDimensions.Width + OperatorFullSpace, Math.Max(firstDimensions.Height, secondDimensions.Height));
    }
}
