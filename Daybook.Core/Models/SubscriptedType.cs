namespace Daybook.Core.Models
{
    public enum SubscriptedType : short
    {
        None = 0,
        Weekly = 7,
        Fortngiht = 14,
        Monthly = 20,
        Seasonally = 91,
        Annually = 365,
        Custom = 999
    }
}
