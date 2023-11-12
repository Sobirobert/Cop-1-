namespace WhatWhere.Entities
{
    public class Groceries : EntityBase
    {
        public override string ToString() => base.ToString() + $", Name: {Name}, Count: {Count}, Location {Location} - (Groceries)";
        public Groceries(string? name, string? location, int count, DateTime DateChanges) //:base(name, location,count)
        {
            Name = name;
            Location = location;
            Count = count;
            DateChange = DateChanges;
        }
        public Groceries() 
        {
            
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
        public DateTime DateChange { get; set; }
    }
}
