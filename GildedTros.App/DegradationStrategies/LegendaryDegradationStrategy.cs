namespace GildedTros.App.DegradationStrategies
{
    public class LegendaryDegradationStrategy : DegradationStrategyBase, IDegradationStrategy
    {
        private const int legendaryQualityRate = 80;

        public void Degrade(Item item)
        {
            if (item == null)
            {
                return;
            }

            QualityCheck(item);
        }

        protected override void QualityCheck(Item item)
        {
            if (item.Quality != legendaryQualityRate)
            {
                item.Quality = legendaryQualityRate;
            }
        }
    }
}
