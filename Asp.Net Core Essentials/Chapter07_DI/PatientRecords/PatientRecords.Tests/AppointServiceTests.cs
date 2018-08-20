using PatientRecords.Services;
using System;
using Xunit;

namespace PatientRecords.Tests
{
    public class AppointServiceTests
    {
        [Fact]
        public void VerifySuccess()
        {
            bool isSuccess = false;
            isSuccess = true;
            Assert.True(isSuccess);
        }
        [Theory]
        [InlineData(7, 5)]
        public void VerifySuccessWithParams(int n1, int n2)
        {
            Assert.True(n1 > n2);
        }

        [Fact(Skip ="temporarily skip")]
        public void VerifyAppointService()
        {
            var service = new AppointService();
            bool isSuccess = service.ScheduleAppoint();
            Assert.True(isSuccess);
        }
    }
}
