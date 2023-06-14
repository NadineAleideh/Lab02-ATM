using Lab02_ATM;

namespace TestATM
{
    public class UnitTest1
    {
        [Fact]
        public void Test_ViewBalance()
        {
            Program.Balance = 300;
            decimal balance = Program.ViewBalance();
            Assert.Equal(300, balance);
        }

        [Fact]
        public void Test_WithdrawValidAmount()
        {
            Program.Balance = 250;
            decimal newBalance = Program.Withdraw(50);
            Assert.Equal(200, newBalance);
        }

        [Fact]
        public void Test_WithdrawMoreThanBalance()
        {
            Program.Balance = 100;
            decimal newBalance = Program.Withdraw(150);
            Assert.Equal(100, newBalance);
        }

        [Fact]
        public void Test_WithdrawInvalidAmount()
        {
            Program.Balance = 250;
            decimal newBalance = Program.Withdraw(-50);
            Assert.Equal(250, newBalance);
        }

        [Fact]
        public void Test_DepositValidAmount()
        {
            Program.Balance = 320;
            decimal newBalance = Program.Deposit(80);
            Assert.Equal(400, newBalance);
        }

        [Fact]
        public void Test_DepositInvalidAmount()
        {
            Program.Balance = 320;
            decimal newBalance = Program.Deposit(-80);
            Assert.Equal(320, newBalance);
        }
    }
}