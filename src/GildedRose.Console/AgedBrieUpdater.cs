namespace GildedRose.Console
{
    public class AgedBrieUpdater : ItemUpdater
    {
        public AgedBrieUpdater(Program.Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            this.Item.SellIn--;

            // The Quality of an item is never more than 50
            if (this.Item.Quality < 50)
            {
                // "Aged Brie" actually increases in Quality the older it gets
                this.Item.Quality++;
            }
        }
    }
}