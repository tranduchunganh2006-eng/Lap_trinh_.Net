using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

int choice;

do
{
    Console.Clear();
    Console.WriteLine("=== CHƯƠNG TRÌNH QUẢN LÝ BÀI TẬP ===");
    Console.WriteLine("1. Chạy Bài tập 1 (Calculator)");
    Console.WriteLine("2. Chạy Bài tập 2 (Phương trình bậc 2)");
    Console.WriteLine("3. Chạy Bài tập 3 (Số nguyên tố & Fibonacci)");
    Console.WriteLine("0. Thoát chương trình");
    Console.WriteLine("====================================");
    Console.Write("Mời bạn chọn chức năng (0-3): ");

    if (!int.TryParse(Console.ReadLine(), out choice))
    {
        choice = -1;
    }

    Console.Clear();

    switch (choice)
    {
        case 1:
            RunBai1();
            break;
        case 2:
            RunBai2();
            break;
        case 3:
            RunBai3();
            break;
        case 0:
            Console.WriteLine("Đã thoát chương trình. Cảm ơn bạn!");
            break;
        default:
            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại!");
            break;
    }

    if (choice != 0)
    {
        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
        Console.ReadKey();
    }

} while (choice != 0);

void RunBai1()
{
    Console.WriteLine("--- BÀI TẬP 1: CALCULATOR ---");
    Console.Write("Nhập số thứ nhất: ");
    double a = double.Parse(Console.ReadLine() ?? "0");
    Console.Write("Nhập số thứ hai: ");
    double b = double.Parse(Console.ReadLine() ?? "0");
    Console.Write("Nhập phép tính (+, -, *, /): ");
    string op = Console.ReadLine() ?? "";

    switch (op)
    {
        case "+":
            Console.WriteLine($"Kết quả: {a} + {b} = {a + b}");
            break;
        case "-":
            Console.WriteLine($"Kết quả: {a} - {b} = {a - b}");
            break;
        case "*":
            Console.WriteLine($"Kết quả: {a} * {b} = {a * b}");
            break;
        case "/":
            if (b != 0)
                Console.WriteLine($"Kết quả: {a} / {b} = {a / b}");
            else
                Console.WriteLine("Lỗi: Không thể chia cho 0!");
            break;
        default:
            Console.WriteLine("Phép tính không hợp lệ!");
            break;
    }
}

void RunBai2()
{
    Console.WriteLine("--- BÀI TẬP 2: GIẢI PHƯƠNG TRÌNH BẬC 2 ---");
    Console.Write("Nhập a: ");
    double a = double.Parse(Console.ReadLine() ?? "0");
    Console.Write("Nhập b: ");
    double b = double.Parse(Console.ReadLine() ?? "0");
    Console.Write("Nhập c: ");
    double c = double.Parse(Console.ReadLine() ?? "0");

    if (a == 0)
    {
        if (b == 0)
        {
            if (c == 0)
                Console.WriteLine("Phương trình có vô số nghiệm.");
            else
                Console.WriteLine("Vô nghiệm.");
        }
        else
        {
            double x = -c / b;
            Console.WriteLine($"Phương trình có 1 nghiệm x = {x:F2}");
        }
    }
    else
    {
        double delta = b * b - 4 * a * c;
        if (delta > 0)
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"x1={x1:F2},x2={x2:F2}");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Nghiệm kép x={x:F2}");
        }
        else
        {
            Console.WriteLine("Vô nghiệm.");
        }
    }
}

void RunBai3()
{
    Console.WriteLine("--- BÀI TẬP 3: SỐ NGUYÊN TỐ & FIBONACCI ---");
    Console.Write("Nhập N: ");
    int n = int.Parse(Console.ReadLine() ?? "0");

    if (IsPerfectNumber(n))
        Console.Write($"{n} là Số hoàn hảo! ");
    else
        Console.Write($"{n} KHÔNG là Số hoàn hảo! ");

    if (IsPrime(n))
        Console.Write($"{n} là Số nguyên tố. ");
    else
        Console.Write($"{n} KHÔNG là Số nguyên tố. ");

    PrintFibonacci(n);
}

bool IsPrime(int n)
{
    if (n < 2) return false;
    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (n % i == 0) return false;
    }
    return true;
}

bool IsPerfectNumber(int n)
{
    if (n <= 0) return false;
    int sum = 0;
    for (int i = 1; i <= n / 2; i++)
    {
        if (n % i == 0) sum += i;
    }
    return sum == n;
}

void PrintFibonacci(int count)
{
    if (count <= 0) return;
    Console.Write($"Dãy Fibonacci {count} số: ");
    long a = 0, b = 1;
    for (int i = 0; i < count; i++)
    {
        if (i == 0) Console.Write(a);
        else if (i == 1) Console.Write($", {b}");
        else
        {
            long next = a + b;
            Console.Write($", {next}");
            a = b;
            b = next;
        }
    }
    Console.WriteLine();
}