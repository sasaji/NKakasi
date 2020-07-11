using Xunit;

namespace Romanizer.Tests
{
    public class Romanize
    {
        [Fact]
        public void Default()
        {
            var romanizer = new Romanizer();
            Assert.Equal("sato", romanizer.Romanize("�T�g�E", "����"));
            Assert.Equal("inoue", romanizer.Romanize("�C�m�E�G", "���"));
            Assert.Equal("kochi", romanizer.Romanize("�R�E�`", "���m"));
            Assert.Equal("kouchi", romanizer.Romanize("�R�E�`", "����"));
            Assert.Equal("shinjuku", romanizer.Romanize("�V���W���N", "�V�h"));
            Assert.Equal("shimbashi", romanizer.Romanize("�V���o�V", "�V��"));
            Assert.Equal("hatchobori", romanizer.Romanize("�n�b�`���E�{��", "�����x"));
            Assert.Equal("osaka", romanizer.Romanize("�I�I�T�J", "���"));
        }

        [Fact]
        public void Kunrei()
        {
            var romanizer = new Romanizer(SpellingStyle.Kunrei, LongVowelStyle.AsIs);
            Assert.Equal("satou", romanizer.Romanize("�T�g�E", "����"));
            Assert.Equal("inoue", romanizer.Romanize("�C�m�E�G", "���"));
            Assert.Equal("kouti", romanizer.Romanize("�R�E�`", "���m"));
            Assert.Equal("kouti", romanizer.Romanize("�R�E�`", "����"));
            Assert.Equal("sinzyuku", romanizer.Romanize("�V���W���N", "�V�h"));
            Assert.Equal("sinbasi", romanizer.Romanize("�V���o�V", "�V��"));
            Assert.Equal("hattyoubori", romanizer.Romanize("�n�b�`���E�{��", "�����x"));
            Assert.Equal("oosaka", romanizer.Romanize("�I�I�T�J", "���"));
        }

        [Fact]
        public void Oh()
        {
            var romanizer = new Romanizer(LongVowelStyle.ToOH);
            Assert.Equal("satoh", romanizer.Romanize("�T�g�E", "����"));
            Assert.Equal("inoue", romanizer.Romanize("�C�m�E�G", "���"));
            Assert.Equal("kohchi", romanizer.Romanize("�R�E�`", "���m"));
            Assert.Equal("kouchi", romanizer.Romanize("�R�E�`", "����"));
            Assert.Equal("shinjuku", romanizer.Romanize("�V���W���N", "�V�h"));
            Assert.Equal("shimbashi", romanizer.Romanize("�V���o�V", "�V��"));
            Assert.Equal("hatchohbori", romanizer.Romanize("�n�b�`���E�{��", "�����x"));
            Assert.Equal("ohsaka", romanizer.Romanize("�I�I�T�J", "���"));
        }
    }
}
