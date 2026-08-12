using System;
using System.Reflection;

namespace NetInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
      
            Assembly app = Assembly.GetExecutingAssembly();
            Console.WriteLine($"==================================================");
            Console.WriteLine($" THÔNG TIN MÔI TRƯỜNG THỰC THI - {app.GetName().Name?.ToUpper()}");
            Console.WriteLine($"==================================================\n");

            Console.WriteLine($"[1] Phiên bản CLR/.NET đang chạy: {Environment.Version}");

      
            Console.WriteLine($"[2] Tên máy tính                : {Environment.MachineName}");
            Console.WriteLine($"    Tên người dùng đăng nhập    : {Environment.UserName}");

            string architecture = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
            Console.WriteLine($"[3] Hệ điều hành                : {Environment.OSVersion}");
            Console.WriteLine($"    Kiến trúc HĐH/CPU           : {architecture}");

   
            long memoryInBytes = GC.GetTotalMemory(false);
            double memoryInMB = memoryInBytes / (1024.0 * 1024.0);
            Console.WriteLine($"[4] Bộ nhớ RAM do GC quản lý    : {memoryInBytes:N0} bytes (~{memoryInMB:F2} MB)");

        
            Console.ReadKey();
        }
    }
}