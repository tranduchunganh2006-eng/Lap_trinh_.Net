using System;

public class BankAccount
{
    private static long _nextAccountNumber = 1000000001;
    private decimal _balance;
    private string _accountHolder = string.Empty;

    public long AccountNumber { get; init; }

    public string AccountHolder
    {
        get => _accountHolder;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Tên chủ tài khoản không được để trống hoặc null.");
            }
            _accountHolder = value;
        }
    }

    public decimal Balance => _balance;

    public BankAccount(string accountHolder, decimal initialBalance)
    {
        if (initialBalance < 50_000m)
        {
            throw new ArgumentException("Số dư khởi tạo tối thiểu phải từ 50,000 VNĐ.");
        }

        AccountNumber = _nextAccountNumber++;
        AccountHolder = accountHolder;
        _balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Số tiền nạp phải lớn hơn 0 VNĐ.");
            return;
        }
        _balance += amount;
        Console.WriteLine($"Nạp thành công {amount:N0} VNĐ vào TK {AccountNumber}. Số dư mới: {_balance:N0} VNĐ.");
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Số tiền rút phải lớn hơn 0 VNĐ.");
            return false;
        }

        if (_balance - amount < 50_000m)
        {
            Console.WriteLine($"Rút tiền thất bại! Số dư còn lại không thể thấp hơn hạn mức duy trì 50,000 VNĐ.");
            return false;
        }

        _balance -= amount;
        Console.WriteLine($"Rút thành công {amount:N0} VNĐ từ TK {AccountNumber}. Số dư còn lại: {_balance:N0} VNĐ.");
        return true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"[STK: {AccountNumber}] | Chủ TK: {AccountHolder} | Số dư: {Balance:N0} VNĐ");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== KIỂM THỬ BÀI TẬP 1 ===");
        try
        {
            BankAccount acc1 = new BankAccount("Nguyen Van A", 100_000m);
            BankAccount acc2 = new BankAccount("Tran Thi B", 500_000m);

            acc1.DisplayInfo();
            acc2.DisplayInfo();

            acc1.Deposit(200_000m);
            acc1.Withdraw(260_000m); // Thất bại vì còn 40,000 < 50,000
            acc1.Withdraw(200_000m); // Thành công
            
            Console.WriteLine("\nThử tạo tài khoản với số dư 30,000 VNĐ:");
            BankAccount accInvalid = new BankAccount("Le Van C", 30_000m);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Bắt lỗi thành công]: {ex.Message}");
        }
    }
}