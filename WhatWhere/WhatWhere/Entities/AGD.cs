namespace WhatWhere.Entities
{
    public class AGD : EntityBase
    {
        public override string ToString() => base.ToString() + $" - (AGD)";
        public AGD(string? name, string? location, int count)
        {
            Name = name;
            Location = location;
            Count = count;
        }
        public string Name {get; set; }
        public string Location { get; set; }
        public int Count { get; set; }  
    }

}
