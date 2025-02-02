using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class IdentifierExpression : NumberReturningExpression
{
    public override Type SVGPresenter => typeof(IdentifierExpressionSVGPresenter);

    public Identifier? Value { get; set; }

    public override double Evaluate()
    {
        return Value!.GetValue();
    }

    public override (double Width, double Height) GetDimensions()
    {
        return ((Value?.Name.Length ?? 1) * 12, 20);
    }
}