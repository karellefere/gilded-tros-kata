namespace GildedTros.App.DegradationStrategies
{
    public class GoodWineDegradationStrategy : DegradationStrategyBase, IDegradationStrategy
    {
        public void Degrade(Item item)
        {
            if (item == null)
            {
                return;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality += 1;
            }

            QualityCheck(item);
        }
    }
}
