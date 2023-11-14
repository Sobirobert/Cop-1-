namespace WhatWhere.Entities
{
    public class Groceries : EntityBase
    {
        public Groceries(string? name, string? location, int count, DateTime DateChanges)
        {
            Name = name;
            Location = location;
            Count = count;
            DateChange = DateChanges;
        }

        public Groceries()
        {
        }

        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Count { get; set; }
        public DateTime DateChange { get; set; }

        public override string ToString() => base.ToString() + $", Name: {Name}, Count: {Count}, Location {Location}, DateTime - {DateChange} - (Groceries)";
    }
}