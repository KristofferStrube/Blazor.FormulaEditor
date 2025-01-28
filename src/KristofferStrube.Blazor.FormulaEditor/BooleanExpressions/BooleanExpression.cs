using KristofferStrube.Blazor.FormulaEditor.Expressions;

namespace KristofferStrube.Blazor.FormulaEditor.BooleanExpressions;

public abstract class BooleanExpression : Expression
{
    public abstract bool Evaluate();
}
