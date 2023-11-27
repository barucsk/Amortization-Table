

namespace Months
{
    internal enum Month
    {
        Enero,
        Febrero,
        Marzo,
        Abril,
        Mayo,
        Junio,
        Julio,
        Agosto,
        Septiembre,
        Octubre,
        Noviembre,
        Diciembre
    }

    internal static class MonthExtensions
    {
        internal static Month NextMonth(this Month month) => (Month)(((int)month + 1) % 12);
    }
}
