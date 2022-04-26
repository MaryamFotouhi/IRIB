using System;

namespace Common.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }

        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}