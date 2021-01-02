using FluentAssertions;
using NUnit.Framework;

namespace LegoLib.Tests
{
    [TestFixture]
    public class StorageContainerInformationShould
    {
        [Test]
        public void ReturnContainerIgnoringPrint()
        {
            var partRecord = new PartRecord { PartNumber = "98382pr0003", ColorName = "Black" };
            var container = StorageContainerInformation.StorageContainer(partRecord);
            container.Should().Be("Black 80 - 89");
        }
    }
}