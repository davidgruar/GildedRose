namespace GildedRose.Console
{
    using System.Collections.Generic;

    using Item = Program.Item;

    public class QualityControl
    {
        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                var updater = Create(item);
                updater.Update();
            }
        }

        private static ItemUpdater Create(Program.Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieUpdater(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassUpdater(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasItemUpdater(item);
                case "Conjured Mana Cake":
                    return new ConjuredItemUpdater(item);
                default:
                    return new ItemUpdater(item);
            }
        }
    }
}
