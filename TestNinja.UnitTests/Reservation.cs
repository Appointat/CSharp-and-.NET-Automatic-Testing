namespace TestNinja.UnitTests
{   
    public class Reservation
    {
        public User MadeBy { get; set; }
        public bool CanbeCancelledBy(User user)
        {
            return (user.IsAdmin || MadeBy == user);
            // if (MadeBy == user) return true;
            // return false;
        }
    }

    public class User
    {
        public bool IsAdmin { get; set;}
    }
}