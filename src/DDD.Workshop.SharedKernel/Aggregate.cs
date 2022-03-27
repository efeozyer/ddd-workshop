using System;
using System.Collections.Generic;

namespace DDD.Workshop.SharedKernel
{
    public abstract class Aggregate<TAggregateId>
        where TAggregateId : struct, IComparable<TAggregateId>, IEquatable<TAggregateId>
    {
        public TAggregateId Id { get; set; }

        protected List<object> Events { get; init; }

        public Aggregate()
        {
            Events = new List<object>();
        }
    }
}
