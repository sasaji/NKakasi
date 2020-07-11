using System;
using System.Collections.Generic;

namespace NKakasi
{
    class KanjiYomi : IComparable
    {
        private readonly Dictionary<Character, string> okuriganaTable = new Dictionary<Character, string>() {
            { new Character('\u3041'), "aiueow" },
            { new Character('\u3042'), "aiueow" },
            { new Character('\u3043'), "aiueow" },
            { new Character('\u3044'), "aiueow" },
            { new Character('\u3045'), "aiueow" },
            { new Character('\u3046'), "aiueow" },
            { new Character('\u3047'), "aiueow" },
            { new Character('\u3048'), "aiueow" },
            { new Character('\u3049'), "aiueow" },
            { new Character('\u304a'), "aiueow" },
            { new Character('\u304b'), "k" },
            { new Character('\u304d'), "k" },
            { new Character('\u304f'), "k" },
            { new Character('\u3051'), "k" },
            { new Character('\u3053'), "k" },
            { new Character('\u304c'), "g" },
            { new Character('\u304e'), "g" },
            { new Character('\u3050'), "g" },
            { new Character('\u3052'), "g" },
            { new Character('\u3054'), "g" },
            { new Character('\u3055'), "s" },
            { new Character('\u3057'), "s" },
            { new Character('\u3059'), "s" },
            { new Character('\u305b'), "s" },
            { new Character('\u305d'), "s" },
            { new Character('\u3056'), "zj" },
            { new Character('\u3058'), "zj" },
            { new Character('\u305a'), "zj" },
            { new Character('\u305c'), "zj" },
            { new Character('\u305e'), "zj" },
            { new Character('\u305f'), "t" },
            { new Character('\u3061'), "tc" },
            { new Character('\u3063'), "aiueokstchgzjfdbpw" },
            { new Character('\u3064'), "t" },
            { new Character('\u3066'), "t" },
            { new Character('\u3068'), "t" },
            { new Character('\u3060'), "d" },
            { new Character('\u3062'), "d" },
            { new Character('\u3065'), "d" },
            { new Character('\u3067'), "d" },
            { new Character('\u3069'), "d" },
            { new Character('\u306a'), "n" },
            { new Character('\u306b'), "n" },
            { new Character('\u306c'), "n" },
            { new Character('\u306d'), "n" },
            { new Character('\u306e'), "n" },
            { new Character('\u306f'), "h" },
            { new Character('\u3072'), "h" },
            { new Character('\u3075'), "hf" },
            { new Character('\u3078'), "h" },
            { new Character('\u307b'), "h" },
            { new Character('\u3070'), "b" },
            { new Character('\u3073'), "b" },
            { new Character('\u3076'), "b" },
            { new Character('\u3079'), "b" },
            { new Character('\u307c'), "b" },
            { new Character('\u3071'), "p" },
            { new Character('\u3074'), "p" },
            { new Character('\u3077'), "p" },
            { new Character('\u307a'), "p" },
            { new Character('\u307d'), "p" },
            { new Character('\u307e'), "m" },
            { new Character('\u307f'), "m" },
            { new Character('\u3080'), "m" },
            { new Character('\u3081'), "m" },
            { new Character('\u3082'), "m" },
            { new Character('\u3083'), "y" },
            { new Character('\u3084'), "y" },
            { new Character('\u3085'), "y" },
            { new Character('\u3086'), "y" },
            { new Character('\u3087'), "y" },
            { new Character('\u3088'), "y" },
            { new Character('\u3089'), "rl" },
            { new Character('\u308a'), "rl" },
            { new Character('\u308b'), "rl" },
            { new Character('\u308c'), "rl" },
            { new Character('\u308d'), "rl" },
            { new Character('\u308e'), "wiueo" },
            { new Character('\u308f'), "wiueo" },
            { new Character('\u3090'), "wiueo" },
            { new Character('\u3091'), "wiueo" },
            { new Character('\u3092'), "w" },
            { new Character('\u3093'), "n" },
            { new Character('\u30f5'), "k" },
            { new Character('\u30f6'), "k" },
        };

        private static readonly object LOCK = new object();
        private static long objectConter;
        private readonly long objectIndex;

        private readonly string kanji;
        private readonly string yomi;
        private readonly char okurigana;
        private readonly int kanjiLength;
        private readonly int hashCode;

        internal KanjiYomi(string kanji, string yomi, char okurigana)
        {
            this.kanji = kanji;
            this.yomi = yomi;
            this.okurigana = okurigana;
            kanjiLength = kanji.Length;
            hashCode = kanji.GetHashCode() ^ yomi.GetHashCode() ^ (int)okurigana;
            lock (LOCK)
            {
                objectIndex = objectConter++;
            }
        }

        internal string Kanji
        {
            get { return kanji; }
        }

        internal string Yomi
        {
            get { return yomi; }
        }

        internal char Okurigana
        {
            get { return okurigana; }
        }

        internal int Length
        {
            get { return kanjiLength + (okurigana > 0 ? 1 : 0); }
        }

        internal string GetYomiFor(string target)
        {
            if (kanjiLength > 0 && !target.StartsWith(kanji))
            {
                return null;
            }
            if (okurigana == 0)
            {
                return yomi;
            }
            try
            {
                Character ch = new Character(target[kanjiLength]);
                string okuriganaList = (string)okuriganaTable[ch];
                return
                    okuriganaList == null || okuriganaList.IndexOf(okurigana) < 0 ?
                    null : yomi + ch.Value;
            }
            catch
            {
                return null;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is KanjiYomi kanjiYomi)
            {
                return
                        hashCode == kanjiYomi.GetHashCode() &&
                        kanji.Equals(kanjiYomi.kanji) &&
                        yomi.Equals(kanjiYomi.yomi) &&
                        okurigana == kanjiYomi.okurigana;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return hashCode;
        }

        public int CompareTo(object o)
        {
            KanjiYomi other = (KanjiYomi)o;
            if (other.kanjiLength == kanjiLength)
            {
                if (okurigana > 0 && other.okurigana == 0)
                {
                    return -1;
                }
                else if (okurigana == 0 && other.okurigana > 0)
                {
                    return 1;
                }
                else
                {
                    return Equals(other) ? 0 :
                        objectIndex < other.objectIndex ? -1 : 1;
                }
            }
            else
            {
                return other.kanjiLength < kanjiLength ? -1 : 1;
            }
        }
    }
}
