﻿namespace BuildingSiteManagementWebApp.Data.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
