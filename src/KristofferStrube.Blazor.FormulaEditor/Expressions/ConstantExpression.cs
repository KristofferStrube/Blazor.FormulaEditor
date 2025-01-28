using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class ConstantExpression : NumberReturningExpression
{
    public override Type SVGPresenter => typeof(ConstantExpressionSVGPresenter);

    public Constant? Value { get; set; }

    public override double Evaluate() => Value!.Value;

    public override (double Width, double Height) GetDimensions()
    {
        return ((Value?.Representation.Length ?? 1) * 12, 20);
    }
}