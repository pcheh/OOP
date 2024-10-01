using System;

namespace TimeStruct
{
    public struct Time
    {
        const int maxValue = 59;
        const int secondsInMinute = 60;
        const int secondsInHour = 3600;

        int hours;

        public int Hours
        {
            get => hours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение должно быть неотрицательным");

                hours = value;
            }
        }


        int minutes;

        public int Minutes
        {
            get => minutes;
            set
            {
                if (value < 0 || value > maxValue)
                    throw new ArgumentException("Значение должно быть неотрицательным и не более 59");

                minutes = value;
            }
        }

        int seconds;
        public int Seconds
        {
            get => seconds;
            set
            {
                if (value < 0 || value > maxValue)
                    throw new ArgumentException("Значение должно быть неотрицательным и не более 59");

                seconds = value;
            }
        }

        public int DurationInSeconds
        {
            get => Hours * secondsInHour + Minutes * secondsInMinute + Seconds;
        }

        public Time(int hours, int minutes, int seconds) : this()
        {
            Hours = hours;
            Minutes = minutes; 
            Seconds = seconds;
        }

        public override string ToString() => $"{Hours}:{Minutes}:{Seconds}";

        public override bool Equals(object obj)
        {
            if (obj is Time)
                return DurationInSeconds == ((Time)obj).DurationInSeconds;

            throw new ArgumentException("Объект не является временным интервалом");
        }

        public override int GetHashCode() => DurationInSeconds.GetHashCode();

        public static bool operator ==(Time x, Time y) => x.Equals(y);
        public static bool operator !=(Time x, Time y) => !x.Equals(y);
        public static bool operator >(Time x, Time y) => x.DurationInSeconds > y.DurationInSeconds;
        public static bool operator <(Time x, Time y) => x.DurationInSeconds < y.DurationInSeconds;
        public static bool operator >=(Time x, Time y) => (x.DurationInSeconds >= y.DurationInSeconds);
        public static bool operator <=(Time x, Time y) => (x.DurationInSeconds <= y.DurationInSeconds);

        public static Time operator +(Time x, Time y) =>
            GetTimeByDurationInSeconds(x.DurationInSeconds + y.DurationInSeconds);

        public static Time operator -(Time x, Time y)
        {
            if (x < y)
                throw new ArgumentException("Уменьшаемое не должно быть меньше вычитаемого");
                
            return GetTimeByDurationInSeconds(x.DurationInSeconds - y.DurationInSeconds);
        }

        public static Time operator *(double k, Time time)
        {
            if (k < 0)
                throw new ArgumentException("Множитель не должен быть отрицательным");

            return GetTimeByDurationInSeconds((int)Math.Round(k * time.DurationInSeconds));
        }

        public static Time operator *(Time time, double k) => k * time;


        private static Time GetTimeByDurationInSeconds(int val)
        {
            int seconds = val;
            int hours = seconds / secondsInHour;
            seconds %= secondsInHour;
            int minutes = seconds / secondsInMinute;
            seconds %= secondsInMinute;

            return new Time(hours, minutes, seconds);
        }
    }
}
