using NodaTime;

namespace dddbits.Basetypes
{
    public abstract class TinyDateValue : TinyType<LocalDate>
    {
        protected TinyDateValue(LocalDate date) : base(date)
        {
        }
        
        protected TinyDateValue(in int year, in int month, in int day) : this(new LocalDate(year, month, day))
        {
        }

        public int Year => Value.Year;
        
        public int Month => Value.Month;
        
        public int Day => Value.Day;
    }
}