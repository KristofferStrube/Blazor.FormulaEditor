namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public abstract class Expression
{
    public abstract Type SVGPresenter { get; }

    public abstract (double Width, double Height) GetDimensions();

    public bool Editable { get; set; } = true;

    public virtual List<(string Icon, string Text, Action Action)> ExtraExpressionActions()
    {
        return [];
    }
}
