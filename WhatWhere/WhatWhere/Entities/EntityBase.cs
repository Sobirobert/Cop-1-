namespace WhatWhere.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? Location { get; set; }
        //public int Count { get; set; }
        // public DateTime? ChangeDate { get; set; }
        // public override string ToString() => $"Change date: {DateTime.Now}, Id: {Id}, Name: {Name}, Count: {Count}, Location {Location} ";
        public override string ToString() => $"Change date: {DateTime.Now}, Id: {Id}";
    }
}
