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
                var updater = ItemUpdater.Create(item);
                updater.Update();
            }
        }
    }
}
