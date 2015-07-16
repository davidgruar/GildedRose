namespace GildedRose.Console
{
    public class BackstagePassUpdater : ItemUpdater
    {
        public BackstagePassUpdater(Program.Item item)
            : base(item)
        {
        }

        public override void UpdateQuality()
        {
            this.Item.SellIn--;
            if (this.Item.Quality < 50)
            {
                this.Item.Quality++;

                // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
                if (this.Item.SellIn < 10 && this.Item.Quality < 50)
                {
                    this.Item.Quality++;
                }

                if (this.Item.SellIn < 5 && this.Item.Quality < 50)
                {
                    this.Item.Quality++;
                }
            }

            if (this.Item.SellIn < 0)
            {
                this.Item.Quality = 0;
            }
        }
    }
}