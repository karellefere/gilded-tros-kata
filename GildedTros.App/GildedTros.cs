using GildedTros.App.DegradationStrategies;
using System.Collections.Generic;
using System.Linq;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                var degradationProcessor = GetDegradationProcessor(item.Name);
                degradationProcessor.ProcessDegradation(item);
            }
        }

        private DegradationProcessor GetDegradationProcessor(string itemName)
        {
            if (itemName == Constants.GoodWine)
            {
                return new DegradationProcessor(new GoodWineDegradationStrategy());
            }

            if (itemName == Constants.BDawgKeychain)
            {
                return new DegradationProcessor(new LegendaryDegradationStrategy());
            }

            if (itemName.StartsWith(Constants.BackStagePasses))
            {
                return new DegradationProcessor(new BackStagePassDegradationStrategy());
            }

            if (Constants.smellyItemNames .Any(smellyName => smellyName == itemName))
            {
                return new DegradationProcessor(new SmellyDegradationStrategy());
            }

            return new DegradationProcessor(new NormalDegradationStrategy());
        }
    }
}
