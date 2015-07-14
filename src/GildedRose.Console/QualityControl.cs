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
            if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
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
            }
            else if (item.Quality > 0)
            {
                // The Quality of an item is never negative
                item.Quality = item.Quality - 1;
            }

        }

        private static void UpdateSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Name == "Aged Brie")
                {
                    // "Aged Brie" actually increases in Quality the older it gets
                    if (item.Quality < 50)
                    {
                        // The Quality of an item is never more than 50
                        item.Quality = item.Quality + 1;
                    }
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    // Quality drops to 0 after the concert
                    item.Quality = 0;
                }
                else if (item.Quality > 0)
                {
                    // Once the sell by date has passed, Quality degrades twice as fast
                    // The Quality of an item is never negative
                    item.Quality = item.Quality - 1;
                }
            }
        }
    }
}
