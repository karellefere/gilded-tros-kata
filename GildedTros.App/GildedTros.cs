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
            if (itemName == "Good Wine")
            {
                return new DegradationProcessor(new GoodWineDegradationStrategy());
            }

            if (itemName == "B-DAWG Keychain")
            {
                return new DegradationProcessor(new LegendaryDegradationStrategy());
            }

            if (itemName.StartsWith("Backstage passes"))
            {
                return new DegradationProcessor(new BackStagePassDegradationStrategy());
            }

            string[] smellyItemNames = { "Duplicate Code", "Long Methods", "Ugly Variable Names" };
            if (smellyItemNames.Any(smellyName => smellyName == itemName))
            {
                return new DegradationProcessor(new SmellyDegradationStrategy());
            }

            return new DegradationProcessor(new NormalDegradationStrategy());
        }
    }
}
