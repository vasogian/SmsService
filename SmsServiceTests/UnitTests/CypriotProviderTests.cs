using Moq;
using SmsService.Interfaces;
using SmsService.Models;
using SmsService.Services;
using Xunit;

namespace SmsServiceTests.UnitTests
{
    public class CypriotProviderTests
    {
        [Theory]
        [InlineData("74611111", "Helloooo")]
        [InlineData(null, "hi")]
        [InlineData(null, null)]
        public async Task When_Input_IsInvalid_DoNotSend(string? phoneNumber, string? payload)
        {
            Mock<IContextService> contextServiceMock = new Mock<IContextService>();

            CypriotProvider sut = new CypriotProvider(contextServiceMock.Object);

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

            CypriotProvider sut = new CypriotProvider(contextServiceMock.Object);

            SmsMessage message = new SmsMessage()
            {
                PhoneNumber = "+3574611111",
                Message = "this is a test"
            };

            List<SmsMessage> result = await sut.Send(message);

            Assert.Single(result);
        }

        [Fact]

        public async Task When_Message_Exceeds_MaxCypriotSmsMessageLength()
        {
            Mock<IContextService> contextServiceMock = new Mock<IContextService>();

            CypriotProvider sut = new CypriotProvider(contextServiceMock.Object);

            string message = "wejdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrhfbjkfwefkjhwejfhwjfuwhfwjfhkkkkkkkkkkkkfwhjghhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhheiiiiiiiiiiiiiiiiiiiiiiiiiiiiii";

            SmsMessage messageToSend = new SmsMessage()
            {
                PhoneNumber = "+3574611111",
                Message = message

            };
            List<SmsMessage> result = await sut.Send(messageToSend);

            Assert.Single(result);

        }
        public async Task When_Message_Exceeds_380_Length()
        {
            Mock<IContextService> contextServiceMock = new Mock<IContextService>();

            CypriotProvider sut = new CypriotProvider(contextServiceMock.Object);

            string message = "wejdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrdrhfbjkfwefkjhwejfhwjfuwhfwjfhkkkkkkkkkkkkfwhjeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiihwejfhwjfuwhfwjfhkkkkkkkkkkkkfwhjeiiiiiiiiiiiiiiiiiiiiiiihwejfhwjfuwhfwjfhkkkkkkkkkkkkfwhjeiiiiiiiiiiiiiiiiiiiiiiihwejfhwjfuwhfwjfhkkkkkkkkkkkkfwhjeiiiiiiiiiiiiiiiiiiiiiiihwejfhwjfuwhfwjfhkkkkkkkkkkkkfwhjeiiiiiiiiiythjyrtjeiiiiiiiiiiiiiiiiiiiiiii";

            SmsMessage messageToSend = new SmsMessage()
            {
                PhoneNumber = "+3574611111",
                Message = message

            };
            List<SmsMessage> result = await sut.Send(messageToSend);

            Assert.Equal(2, result.Count);

        }
    }
}
