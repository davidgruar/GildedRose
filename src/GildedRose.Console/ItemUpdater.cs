namespace GildedRose.Console
{
    public class ItemUpdater
    {
        public Program.Item Item { get; private set; }

        public ItemUpdater(Program.Item item)
        {
            this.Item = item;
        }

        public void Update()
        {
            this.UpdateSellIn();
            this.UpdateQuality();
        }

        protected virtual void UpdateSellIn()
        {
            this.Item.SellIn--;
        }

        protected virtual void UpdateQuality()
        {
            if (this.Item.Quality > 0)
            {
                var qualityDecrease = this.Item.SellIn > 0 ? 1 : 2;
                {
                    this.Item.Quality -= qualityDecrease;
                }
            }
        }

        public static ItemUpdater Create(Program.Item item)
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