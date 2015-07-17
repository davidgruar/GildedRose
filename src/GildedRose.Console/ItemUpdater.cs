namespace GildedRose.Console
{
    public class ItemUpdater
    {
        protected Program.Item Item { get; private set; }

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
                this.Item.Quality -= qualityDecrease;
            }
        }
    }
}