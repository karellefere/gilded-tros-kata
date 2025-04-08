using System;

namespace GildedTros.App.DegradationStrategies
{
    public class DegradationStrategyBase
    {
        protected DegradationStrategyBase() { }

        protected virtual void QualityCheck(Item item)
        {
            item.Quality = Math.Max(item.Quality, 0);
            item.Quality = Math.Min(item.Quality, 50);
        }
    }
}
