using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using SmsService.Models;
using SmsService.Interfaces;
using SmsService.Services;

namespace SmsServiceTests.UnitTests
{
    public class RestOfTheWorldProviderTests
    {
        [Theory]
        [InlineData("+306951426598", "Γεια σου")]
        [InlineData("+3574611111", "ΓειασουHI")]
        public async Task When_Input_IsInvalid_DoNotSend(string? phoneNumber, string? payload)
        {
            Mock<IContextService> contextServiceMock = new Mock<IContextService>();

            RestOfTheWorldProvider sut = new RestOfTheWorldProvider(contextServiceMock.Object);

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

            RestOfTheWorldProvider sut = new RestOfTheWorldProvider(contextServiceMock.Object);

            SmsMessage message = new SmsMessage()
            {
                PhoneNumber = "54564564545",
                Message = "Hellooo"
            };

            List<SmsMessage> result = await sut.Send(message);

            Assert.Single(result);
        }

    }
}
