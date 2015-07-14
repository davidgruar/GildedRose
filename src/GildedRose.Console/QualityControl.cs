namespace GildedRose.Console
{
    using System.Collections;
    using System.Collections.Generic;

    using Item = Program.Item;

    public class QualityControl
    {
        public void UpdateQuality(IList<Item> items)
        {
            foreach (Item item in items)
            {
                var myItem = ItemUpdater.Create(item);
                if (myItem == null)
                {
                    // Handle special cases
                    UpdateQuality(item);
                    UpdateSellIn(item);
                }
                else
                {
                    // Handler normal case
                    myItem.UpdateQuality();
                }
            }
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }

                if (item.SellIn < 6 && item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        private static void UpdateSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                // Quality drops to 0 after the concert
                item.Quality = 0;
            }
        }
    }
}
