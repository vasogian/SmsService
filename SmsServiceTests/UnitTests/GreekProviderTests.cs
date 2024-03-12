using Moq;
using SmsService.Interfaces;
using SmsService.Models;
using SmsService.Services;
using Xunit;

namespace SmsServiceTests.UnitTests
{
    public class GreekProviderTests
    {
        [Theory]
        [InlineData("+806970085146", "Γεια σου")]
        [InlineData("+3076970085146", "ΓειασουHI")]
        [InlineData("+9976970085146", "hi")]
        [InlineData(null, "hi")]
        [InlineData(null, null)]
        public async Task When_Input_IsInvalid_DoNotSend(string? phoneNumber, string? payload)
        {
            Mock<IContextService> contextServiceMock = new Mock<IContextService>();

            GreekProvider sut = new GreekProvider(contextServiceMock.Object);

            SmsMessage message = new SmsMessage()
            {
                PhoneNumber = phoneNumber,
                Message = payload
            };

            List<SmsMessage> result = await sut.Send(message);

            Assert.Empty(result);
        }

        [Fact]
        public async Task When_Input_IsValid_Send()
        {
            Mock<IContextService> contextServiceMock = new Mock<IContextService>();

            GreekProvider sut = new GreekProvider(contextServiceMock.Object);

            SmsMessage message = new SmsMessage()
            {
                PhoneNumber = "+306970085146",
                Message = "Γεια σου"
            };

            List<SmsMessage> result = await sut.Send(message);

            Assert.Single(result);
        }
    }
}
