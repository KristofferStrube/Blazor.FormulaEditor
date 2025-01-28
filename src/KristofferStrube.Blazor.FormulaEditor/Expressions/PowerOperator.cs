using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class PowerOperator : NumberReturningExpression
{
    public const double PowerOffset = 10;

    public override Type SVGPresenter => typeof(PowerOperatorSVGPresenter);

    public NumberReturningExpression? Value { get; set; }
    public NumberReturningExpression? Power { get; set; }

    public override double Evaluate() => Math.Pow(Value!.Evaluate(), Power!.Evaluate());

    public override (double Width, double Height) GetDimensions()
    {
        (double Width, double Height) valueDimensions = Value?.GetDimensions() ?? (20, 20);
        (double Width, double Height) superScriptDimensions = Power?.GetDimensions() ?? (20, 20);

        return (valueDimensions.Width + superScriptDimensions.Width, valueDimensions.Height + superScriptDimensions.Height - PowerOffset);
    }
}
