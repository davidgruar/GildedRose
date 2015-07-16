namespace GildedRose.Console
{
    public class ConjuredItemUpdater : ItemUpdater
    {
        public ConjuredItemUpdater(Program.Item item)
            : base(item)
        {
        }

        protected override void UpdateQuality()
        {
            // "Conjured" items degrade in Quality twice as fast as normal items
            base.UpdateQuality();
            base.UpdateQuality();
        }
    }
}