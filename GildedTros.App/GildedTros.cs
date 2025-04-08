using System;
using System.Collections.Generic;

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
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                if(item.Name == "Good Wine")
                {
                    UpdateQualityGoodWine(item);
                    continue;
                }

                if(item.Name == "B-DAWG Keychain")
                {
                    UpdateQualityLegendary(item);
                    continue;
                }

                if(item.Name.StartsWith("Backstage passes"))
                {
                    UpdateQualityBackStagePass(item);
                    continue;
                }

                UpdateQualityNormal(item);
            }
        }
        
        private void QualityCheck(Item item)
        {
            item.Quality = Math.Max(item.Quality, 0);
            item.Quality = Math.Min(item.Quality, 50);
        }

        private void UpdateQualityNormal(Item item)
        {
            if(item == null)
            {
                return;
            }

            item.SellIn -= 1;
            
            if(item.SellIn < 0){
                item.Quality -= 2;
            }
            else
            {
                item.Quality -= 1;
            }

            QualityCheck(item);
        }

        private void UpdateQualityGoodWine(Item item)
        {
            if(item == null)
            {
                return;
            }

            item.SellIn -= 1;

            if(item.SellIn < 0)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality += 1;
            }

            QualityCheck(item);
        }

        private void UpdateQualityLegendary(Item item)
        {
            if(item == null)
            {
                return;
            }

            if(item.Quality != 80)
            {
                item.Quality = 80;
            }
        }

        private void UpdateQualityBackStagePass(Item item)
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

            if(oldSellIn > 10)
            {
                item.Quality += 1;

                QualityCheck(item);
                return;
            }

            if(oldSellIn > 5)
            {
                item.Quality += 2;

                QualityCheck(item);
                return;
            }

            item.Quality += 3;

            QualityCheck(item);
        }

        private void UpdateQualitySmellyItem(Item item)
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
