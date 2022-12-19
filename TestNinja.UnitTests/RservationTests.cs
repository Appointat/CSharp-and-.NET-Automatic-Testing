// using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using NUnit.Framework;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            // Arrange 安排
            var reservation = new Reservation();

            // Act
            var result = reservation.CanbeCancelledBy(new User { IsAdmin = true });

            // Assert 断言
            // Assert.IsTrue(result);
            Assert.That(result, Is.True);
            // Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_RetureTrue()
        {
            // Arrange 安排
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanbeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);            
        }
        
        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnFlase()
        {
            var reservation = new Reservation();
            var result = reservation.CanbeCancelledBy(new User());
            Assert.IsFalse(result);
        }
    }
}
