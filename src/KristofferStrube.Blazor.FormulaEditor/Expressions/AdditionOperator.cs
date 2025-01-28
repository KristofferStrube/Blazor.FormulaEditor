namespace KristofferStrube.Blazor.FormulaEditor.Expressions;

public class AdditionOperator : BinaryOperator
{
    public override string Operator => "+";

    public override double Evaluate() => First!.Evaluate() + Second!.Evaluate();
}
