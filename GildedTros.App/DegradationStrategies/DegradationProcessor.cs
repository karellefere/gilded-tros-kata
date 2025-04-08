namespace GildedTros.App.DegradationStrategies
{
    public class DegradationProcessor
    {
        private IDegradationStrategy _degradationStrategy;

        public DegradationProcessor(IDegradationStrategy degradationStrategy)
        {
            _degradationStrategy = degradationStrategy;
        }

        public void ProcessDegradation(Item item)
        {
            _degradationStrategy.Degrade(item);
        }
    }
}
