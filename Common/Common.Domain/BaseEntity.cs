using System;

namespace Common.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = new DateTime();
        }

        public long Id { get; private set; }
        public DateTime CreationDate { get; }
    }
}