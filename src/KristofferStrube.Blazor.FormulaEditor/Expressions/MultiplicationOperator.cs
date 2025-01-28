using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class MultiplicationOperator : BinaryOperator
{
    public override string Operator => "•";

    public bool ExplicitOperator { get; set; } = true;

    public override Type SVGPresenter => typeof(MultiplicationOperatorSVGPresenter);

    public override double Evaluate() => First!.Evaluate() * Second!.Evaluate();

    public override List<(string Icon, string Text, Action Action)> ExtraExpressionActions()
    {
        return [
            ..base.ExtraExpressionActions(),
            ("•", ExplicitOperator ? "Hide Operator" : "Show Operator", () => ExplicitOperator = !ExplicitOperator)
        ];
    }

    public override (double Width, double Height) GetDimensions()
    {
        (double Width, double Height) baseDimensions = base.GetDimensions();
        if (ExplicitOperator)
        {
            return baseDimensions;
        }

        return (baseDimensions.Width - OperatorFullSpace + OperatorMargin, baseDimensions.Height);
    }
}
