using System;

namespace NKakasi
{
    class Character : IComparable
    {
        public Character(char c)
        {
            Value = c;
        }

        public char Value { get; }

        public static char ToUpper(char c)
        {
            return c.ToString().ToUpper()[0];
        }

        public static bool IsWhitespace(char c)
        {
            if (c == ' ') return true;
            if (c == '\r') return true;
            if (c == '\n') return true;
            if (c == '\t') return true;
            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (this.GetType() != obj.GetType())
            {
                throw new ArgumentException("別の型とは比較できません。", "obj");
            }
            return Value.CompareTo(((Character)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Character other && other.Value == Value;
        }
    }
}
