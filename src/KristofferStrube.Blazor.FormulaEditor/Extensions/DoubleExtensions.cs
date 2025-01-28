using System.Globalization;

namespace KristofferStrube.Blazor.FormulaEditor.Extensions;

internal static class DoubleExtensions
{
    internal static string AsString(this double d)
    {
        return Math.Round(d, 6).ToString(CultureInfo.InvariantCulture);
    }
}