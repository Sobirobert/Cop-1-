namespace WhatWhere.Entities
{
    public class AGD : EntityBase
    {
        public override string ToString() => base.ToString() + $", Name: {Name}, Count: {Count}, Location {Location} GuaranteeDate: {GuaranteeDate} - (AGD)";
        public AGD(string? name, string? location, int count, DateTime guaranteeDate, DateTime dateChange)
        {
            Name = name;
            Location = location;
            Count = count;
            GuaranteeDate = guaranteeDate;
            DateChange = dateChange;  
        }
        public AGD() 
        { 
        }
        public string Name {get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
        public DateTime DateChange { get; set; }
        public DateTime GuaranteeDate { get; set; }
    }

}
