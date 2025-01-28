using KristofferStrube.Blazor.FormulaEditor.Expressions;
using Microsoft.AspNetCore.Components;

namespace KristofferStrube.Blazor.FormulaEditor.ExpressionSVGPresenters;

public class ExpressionSVGPresenter<TExpression> : ComponentBase where TExpression : Expression
{
    protected bool editing = false;

    [Parameter]
    public required TExpression Expression { get; set; }

    [Parameter]
    public required MathEditorContext Context { get; set; }

    [Parameter]
    public double PositionX { get; set; }

    [Parameter]
    public double PositionY { get; set; }
}
