namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public abstract class NumberReturningExpression : Expression
{
    public abstract double Evaluate();
}
