using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.Write("Nhập N: ");
int n = int.Parse(Console.ReadLine() ?? "0");

if (IsPerfectNumber(n))
{
    Console.Write($"{n} là Số hoàn hảo! ");
}
else
{
    Console.Write($"{n} KHÔNG là Số hoàn hảo! ");
}

if (IsPrime(n))
{
    Console.Write($"{n} là Số nguyên tố. ");
}
else
{
    Console.Write($"{n} KHÔNG là Số nguyên tố. ");
}

PrintFibonacci(n);

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
        if (n % i == 0)
        {
            sum += i;
        }
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
        if (i == 0)
        {
            Console.Write(a);
        }
        else if (i == 1)
        {
            Console.Write($", {b}");
        }
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