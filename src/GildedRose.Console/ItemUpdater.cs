namespace GildedRose.Console
{
    public class ItemUpdater
    {
        public Program.Item Item { get; private set; }

        public ItemUpdater(Program.Item item)
        {
            this.Item = item;
        }

        public virtual void UpdateQuality()
        {
            this.Item.SellIn--;
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
                case "Backstage passes to a TAFKAL80ETC concert":
                    return null;
                // TODO return custom subclass
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasItemUpdater(item);
                default:
                    return new ItemUpdater(item);
            }
        }
    }
}