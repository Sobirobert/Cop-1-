namespace WhatWhere.Entities
{
    public class KitchenAccessories : EntityBase
    {
        public KitchenAccessories(string? name, string? location, int count, DateTime dateChanges)
        {
            Name = name;
            Location = location;
            Count = count;
            DateChange = dateChanges;
        }

        public KitchenAccessories()
        {
        }

        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Count { get; set; }
        public DateTime DateChange { get; set; }

        public override string ToString() => base.ToString() + $", Name: {Name}, Count: {Count}, Location: {Location}, DateTime - {DateChange}  - (KitchenAccessories)";
    }
}