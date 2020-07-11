using Xunit;

namespace Romanizer.Tests
{
    public class Romanize
    {
        [Fact]
        public void Default()
        {
            var romanizer = new Romanizer();
            Assert.Equal("sato", romanizer.Romanize("サトウ", "佐藤"));
            Assert.Equal("inoue", romanizer.Romanize("イノウエ", "井上"));
            Assert.Equal("kochi", romanizer.Romanize("コウチ", "高知"));
            Assert.Equal("kouchi", romanizer.Romanize("コウチ", "小内"));
            Assert.Equal("shinjuku", romanizer.Romanize("シンジュク", "新宿"));
            Assert.Equal("shimbashi", romanizer.Romanize("シンバシ", "新橋"));
            Assert.Equal("hatchobori", romanizer.Romanize("ハッチョウボリ", "八丁堀"));
            Assert.Equal("osaka", romanizer.Romanize("オオサカ", "大阪"));
        }

        [Fact]
        public void Kunrei()
        {
            var romanizer = new Romanizer(SpellingStyle.Kunrei, LongVowelStyle.AsIs);
            Assert.Equal("satou", romanizer.Romanize("サトウ", "佐藤"));
            Assert.Equal("inoue", romanizer.Romanize("イノウエ", "井上"));
            Assert.Equal("kouti", romanizer.Romanize("コウチ", "高知"));
            Assert.Equal("kouti", romanizer.Romanize("コウチ", "小内"));
            Assert.Equal("sinzyuku", romanizer.Romanize("シンジュク", "新宿"));
            Assert.Equal("sinbasi", romanizer.Romanize("シンバシ", "新橋"));
            Assert.Equal("hattyoubori", romanizer.Romanize("ハッチョウボリ", "八丁堀"));
            Assert.Equal("oosaka", romanizer.Romanize("オオサカ", "大阪"));
        }

        [Fact]
        public void Oh()
        {
            var romanizer = new Romanizer(LongVowelStyle.ToOH);
            Assert.Equal("satoh", romanizer.Romanize("サトウ", "佐藤"));
            Assert.Equal("inoue", romanizer.Romanize("イノウエ", "井上"));
            Assert.Equal("kohchi", romanizer.Romanize("コウチ", "高知"));
            Assert.Equal("kouchi", romanizer.Romanize("コウチ", "小内"));
            Assert.Equal("shinjuku", romanizer.Romanize("シンジュク", "新宿"));
            Assert.Equal("shimbashi", romanizer.Romanize("シンバシ", "新橋"));
            Assert.Equal("hatchohbori", romanizer.Romanize("ハッチョウボリ", "八丁堀"));
            Assert.Equal("ohsaka", romanizer.Romanize("オオサカ", "大阪"));
        }
    }
}
