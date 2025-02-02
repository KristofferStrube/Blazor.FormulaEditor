using KristofferStrube.Blazor.FormulaEditor.BooleanExpressions;
using KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class CasesExpression : NumberReturningExpression
{
    public const double ForkWidth = 12;
    public const double ConditionSpacing = 15;
    public const double CaseSpacing = 5;
    public const string OtherwiseText = "otherwise";
    public const string ForText = "for";
    public const double ForTextSpacing = 5;
    public static readonly double ForTextWidth = ForText.Length * 12 + ForTextSpacing;

    public override Type SVGPresenter => typeof(CasesExpressionSVGPresenter);

    public List<Case> Cases { get; set; } = [];
    public NumberReturningExpression? Otherwise { get; set; }

    public override List<(string Icon, string Text, Action Action)> ExtraExpressionActions()
    {
        return [
            ..base.ExtraExpressionActions(),
            ("➕", "Add Case", () => Cases.Add(new()))
        ];
    }

    public override double Evaluate()
    {
        foreach (Case casesExpressionCase in Cases)
        {
            if (casesExpressionCase.Condition?.Evaluate() is true)
            {
                return casesExpressionCase.Value!.Evaluate();
            }
        }
        return Otherwise!.Evaluate();
    }

    public override (double Width, double Height) GetDimensions()
    {
        (double Width, double Height) otherwiserDimensions = Otherwise?.GetDimensions() ?? (20, 20);
        double maxWidthLeft = otherwiserDimensions.Width;
        double maxWidthRight = OtherwiseText.Length * 12;
        double totalHeight = otherwiserDimensions.Height;
        foreach (Case casesExpressionCase in Cases)
        {
            (double Width, double Height) valueDimensions = casesExpressionCase.Value?.GetDimensions() ?? (20, 20);
            (double Width, double Height) conditionDimensions = casesExpressionCase.Condition?.GetDimensions() ?? (20, 20);
            maxWidthLeft = Math.Max(maxWidthLeft, valueDimensions.Width);
            maxWidthRight = Math.Max(maxWidthRight, ForTextWidth + conditionDimensions.Width);
            totalHeight += Math.Max(valueDimensions.Height, conditionDimensions.Height) + CaseSpacing;
        }
        return (ForkWidth + maxWidthLeft + ConditionSpacing + maxWidthRight, totalHeight);
    }

    public class Case
    {
        public NumberReturningExpression? Value { get; set; }
        public BooleanExpression? Condition { get; set; }
    }
}
