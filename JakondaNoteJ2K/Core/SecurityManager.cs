using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

public static class SecurityManager
{
    // Ключ для шифрования/расшифровки данных
    private static readonly byte[] EncryptionKey = Encoding.UTF8.GetBytes("YourEncryptionKey123!");

    // Инициализация менеджера безопасности
    public static void Initialize()
    {
        // Проверка на наличие лицензионного ключа
        if (!IsLicenseValid())
        {
            throw new Exception("Invalid license key.");
        }

        // Проверка на наличие инструментов декомпиляции
        if (IsDecompilerPresent())
        {
            throw new Exception("Decompiling tools detected.");
        }
    }

    private static bool IsLicenseValid()
    {
        // Здесь должна быть логика проверки лицензионного ключа
        // Это может быть запрос к серверу лицензий или проверка локального ключа
        return true; // Заглушка для примера
    }

    private static bool IsDecompilerPresent()
    {
        // Проверка на наличие процесса, связанного с инструментами декомпиляции
        string[] decompilerNames = { "dnspy", "dotpeek", "ildasm" };
        return Process.GetProcesses().Any(p => decompilerNames.Any(d => p.ProcessName.ToLower().Contains(d)));
    }
}
