using modul8_1302213062;
using System;
using System.Collections.Generic;

namespace modul8_1302210084
{
    class Program
    {
        static void Main(string[] args)
        {

            BankTransferConfig.LoadConfig();


            string lang = BankTransferConfig.GetLang();

            if (lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }
            else
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }


            int jumlah = int.Parse(Console.ReadLine());
            int biayaTransfer;

            if (jumlah <= BankTransferConfig.GetThreshold())
            {
                biayaTransfer = BankTransferConfig.GetLowFee();
            }
            else
            {
                biayaTransfer = BankTransferConfig.GetHighFee();
            }

            int nominalTransfer = jumlah + biayaTransfer;


            if (BankTransferConfig.GetLang() == "en")
            {
                Console.WriteLine($"Transferfee = {biayaTransfer}\nTotal amount = {nominalTransfer}");
            }
            else
            {
                Console.WriteLine($"Biaya transfer = {biayaTransfer}\nTotal biaya = {nominalTransfer}");
            }

            if (BankTransferConfig.GetLang() == "en")
            {
                Console.WriteLine("Select transfer method:");
            }
            else if (BankTransferConfig.GetLang() == "id")
            {
                Console.WriteLine("Pilih metode transfer:");
            }

            List<string> transferMethods = BankTransferConfig.GetMethods();
            for (int i = 0; i < transferMethods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {transferMethods[i]}");
            }

            if (BankTransferConfig.GetLang() == "en")
            {
                Console.WriteLine($"Please type \"{BankTransferConfig.GetConfirmation("en")}\" to confirm the transaction:");
            }
            else if (BankTransferConfig.GetLang() == "id")
            {
                Console.WriteLine($"Ketik \"{BankTransferConfig.GetConfirmation("id")}\" untuk mengkonfirmasi transaksi:");
            }
            string confirmation = Console.ReadLine();

            if (confirmation == BankTransferConfig.GetConfirmation(BankTransferConfig.GetLang()))
            {
                if (BankTransferConfig.GetLang() == "en")
                {
                    Console.WriteLine("The transfer is completed");
                }
                else if (BankTransferConfig.GetLang() == "id")
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
            }
            else
            {
                if (BankTransferConfig.GetLang() == "en")
                {
                    Console.WriteLine("Transaksi is cancelled");
                }
                else if (BankTransferConfig.GetLang() == "id")
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }

    }
}