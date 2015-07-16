namespace GildedRose.Console
{
    using System;

    public class BackstagePassUpdater : ItemUpdater
    {
        public BackstagePassUpdater(Program.Item item)
            : base(item)
        {
        }

        protected override void UpdateQuality()
        {
            if (this.Item.SellIn < 0)
            {
                this.Item.Quality = 0;
            }
            else
            {
                this.Item.Quality++;

                // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
                if (this.Item.SellIn < 10)
                {
                    this.Item.Quality++;
                }

                if (this.Item.SellIn < 5)
                {
                    this.Item.Quality++;
                }

                this.Item.Quality = Math.Min(this.Item.Quality, 50);
            }

            
        }
    }
}