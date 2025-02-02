using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class SquareRootOperator : NumberReturningExpression
{
    public const double FlipWidth = 4;
    public const double VFirstPartWidth = 6;
    public const double VFirstPartHeight = 10;
    public const double VSecondPartWidth = 6;
    public const double VSecondPartHeightBase = 10;
    public const double TopPadding = 2;
    public const double SymbolThickness = 2;
    public const double WidthOfVWithFlip = FlipWidth + VFirstPartWidth + VSecondPartWidth;

    public override Type SVGPresenter => typeof(SquareRootOperatorSVGPresenter);

    public NumberReturningExpression? Value { get; set; }

    public override double Evaluate()
    {
        return Math.Sqrt(Value!.Evaluate());
    }

    public override (double Width, double Height) GetDimensions()
    {
        (double Width, double Height) valueDimensions = Value?.GetDimensions() ?? (20, 20);

        return (valueDimensions.Width + FlipWidth + VFirstPartWidth + VSecondPartWidth + SymbolThickness, valueDimensions.Height + VSecondPartHeightBase + SymbolThickness);
    }
}
