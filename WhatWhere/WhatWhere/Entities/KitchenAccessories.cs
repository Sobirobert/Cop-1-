namespace WhatWhere.Entities
{
    public class KitchenAccessories : EntityBase
    {
        public override string ToString() => base.ToString() + $" - (KitchenAccessories)";
        public KitchenAccessories(string? name, string? location, int count)
        {
            Name = name;
            Location = location;
            Count = count;
        }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
    }
}
