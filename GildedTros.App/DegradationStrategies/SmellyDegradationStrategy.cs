namespace GildedTros.App.DegradationStrategies
{
    public class SmellyDegradationStrategy : DegradationStrategyBase, IDegradationStrategy
    {
        public void Degrade(Item item)
        {
            if (item == null)
            {
                return;
            }

            item.SellIn -= 1;

            item.Quality -= 2;

            QualityCheck(item);
        }
    }
}
