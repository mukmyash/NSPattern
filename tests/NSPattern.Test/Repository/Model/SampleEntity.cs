using System;
using System.Collections.Generic;
using System.Text;

namespace NSPattern.Test.Repository.Model
{
    public class SampleEntity : IEquatable<SampleEntity>
    {
        public int id { get; set; }
        public string sValue { get; set; }
        public int iValue { get; set; }
        public decimal mValue { get; set; }

        public bool Equals(SampleEntity other)
        {
            return this.id == other.id
                && this.iValue == other.iValue
                && this.mValue == other.mValue
                && this.sValue == other.sValue;
        }
    }
}
