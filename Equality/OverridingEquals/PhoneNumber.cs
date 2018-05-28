using System;

namespace OverridingEquals {
    public class PhoneNumber {
        // First part of a phone number: (XXX) 000-0000
        public string AreaCode { get; set; }

        // Second part of a phone number: (000) XXX-0000
        public string Exchange { get; set; }

        // Third part of a phone number: (000) 000-XXXX
        public string SubscriberNumber { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != GetType()) return false;
            if (ReferenceEquals(this, obj)) return true;

            return Equals((PhoneNumber) obj);
        }

        private bool Equals(PhoneNumber other)
        {
            return AreaCode == other.AreaCode && Exchange == other.Exchange &&
                   SubscriberNumber == other.SubscriberNumber;
        }

        public override int GetHashCode()
        {
            const int hashSeed = 7;
            const int hashMultiplier = 13;

            var hash = hashSeed;
            hash = (hash * hashMultiplier) ^ (AreaCode is null ? 0 : AreaCode.GetHashCode());
            hash = (hash * hashMultiplier) ^ (Exchange is null ? 0 : Exchange.GetHashCode());
            hash = (hash * hashMultiplier) ^ (SubscriberNumber is null ? 0 : SubscriberNumber.GetHashCode());

            return hash;
        }

        public static bool operator == (PhoneNumber a, PhoneNumber b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(PhoneNumber a, PhoneNumber b)
        {
            return !(a == b);
        }

    }
}