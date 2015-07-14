namespace GildedRose.Console
{
    using System.Collections;
    using System.Collections.Generic;

    using Item = Program.Item;

    //public class MyItem : Item
    //{
    //    public MyItem(Item item)
    //    {
    //        this.Name = item.Name;
    //        this.Quality = item.Quality;
    //        this.SellIn = item.SellIn;
    //    }

    //    public virtual void UpdateQuality()
    //    {
    //        if (this.SellIn <)
    //    }
    //}

    public class QualityControl
    {
        public void UpdateQuality(IList<Item> items)
        {
            foreach (Item item in items)
            {
                UpdateQuality(item);
                UpdateSellIn(item);
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
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
        }

        private static void UpdateSellIn(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
                return;
            }
            
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
