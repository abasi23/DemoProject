using RA.Domain.Shared;
using RA.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Domain.Products
{
    public class Price : ValueObject<Price>
    {
        public decimal Value { get; private set; }

        protected override bool EqualsCore(Price other)
        {
            return other.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        public Price(decimal val)
        {
            if (val < 0) throw new BusinessRuleException("Invalid price value.");
            Value = val;
        }

        public Price() { }

    }
}
