using System;

namespace GildedTros.App.DegradationStrategies
{
    public class DegradationStrategyBase
    {
        private const int minimumQualityRate = 0;
        private const int maximumQualityRate = 50;

        protected DegradationStrategyBase() { }

        protected virtual void QualityCheck(Item item)
        {
            item.Quality = Math.Max(item.Quality, minimumQualityRate);
            item.Quality = Math.Min(item.Quality, maximumQualityRate);
        }
    }
}
