using System ;
class Program
{
    static void Main ()
    {
        Console.Write("Nhap a :");
        double a = double.Parse(Console.ReadLine ());

        Console.Write("Nhap b ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhap phep toan (+,-,*,/,%)");
        char pt = Console.ReadLine()![0];

        string result = (pt,b) switch
        {
            ('+', _) => (a + b).ToString("F2"),
            ('-', _) => (a - b).ToString("F2"),
            ('*', _) => (a * b).ToString("F2"),
            ('/', 0) => "Lỗi: Không thể chia cho 0!",
            ('/', _) => (a / b).ToString("F2"),
            ('%', 0) => "Lỗi: Không thể chia cho 0!",
            ('%', _) => (a % b).ToString("F2"),
            _        => "Lỗi: Phép toán không hợp lệ!"
            
        };
        Console.WriteLine(result);
    }
}


