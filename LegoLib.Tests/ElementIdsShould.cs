using FluentAssertions;
using NUnit.Framework;

namespace LegoLib.Tests
{
    [TestFixture]
    public class ElementIdsShould
    {
        [Test]
        public void LookupUnderscoreElementIdsCorrectly()
        {
            var partRecord = ElementIds.Lookup("_36756pr0001_28");
            partRecord.PartNumber.Should().Be("36756pr0001");
            partRecord.ColorId.Should().Be("28");
        }
    }
}