﻿namespace RecordStore.Core.Entities.Models
{
    public class Style : Entity
    {
        public string Name { get; set; }
        public ICollection<Record> Records { get; set; } = new List<Record>();
    }
}
