namespace WhatWhere.Entities
{
    public class Groceries : EntityBase
    {
        public override string ToString() => base.ToString() + $" - (Groceries)";
        public Groceries(string? name, string? location, int count)
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
