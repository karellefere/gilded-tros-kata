namespace GildedTros.App.DegradationStrategies
{
    public class BackStagePassDegradationStrategy : DegradationStrategyBase, IDegradationStrategy
    {
        public void Degrade(Item item)
        {
            if (item == null)
            {
                return;
            }

            int oldSellIn = item.SellIn;
            item.SellIn -= 1;

            if (oldSellIn <= 0)
            {
                item.Quality = 0;

                QualityCheck(item);
                return;
            }

            if (oldSellIn > 10)
            {
                item.Quality += 1;

                QualityCheck(item);
                return;
            }

            if (oldSellIn > 5)
            {
                item.Quality += 2;

                QualityCheck(item);
                return;
            }

            item.Quality += 3;

            QualityCheck(item);
        }
    }
}
