﻿namespace ThinkEdu_Core_Service.Domain.Common
{
    public abstract class BaseAuditableEntity<T> : BaseTimeEntity<T>
    {
        public string? CreatedBy { get; set; }
    }
}