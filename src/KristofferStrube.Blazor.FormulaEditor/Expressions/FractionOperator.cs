using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class FractionOperator : NumberReturningExpression
{
    public const double SeparatorThickness = 2;
    public const double SeparatorMargin = 4;
    public const double SeparatorFullSpace = SeparatorThickness + SeparatorMargin * 2;

    public override Type SVGPresenter => typeof(FractionOperatorSVGPresenter);

    public NumberReturningExpression? Numerator { get; set; }
    public NumberReturningExpression? Denominator { get; set; }

    public override double Evaluate() => Numerator!.Evaluate() / Denominator!.Evaluate();

    public override (double Width, double Height) GetDimensions()
    {
        (double Width, double Height) firstDimensions = Numerator?.GetDimensions() ?? (20, 20);
        (double Width, double Height) secondDimensions = Denominator?.GetDimensions() ?? (20, 20);

        return (Math.Max(firstDimensions.Width, secondDimensions.Width) + 10, firstDimensions.Height + secondDimensions.Height + SeparatorFullSpace);
    }
}
