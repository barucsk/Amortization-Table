using System;
using Months;
using ClassPayment;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        decimal TotalCredit;
        decimal FDPDP;
        decimal CApercentaga;
        decimal SDAV;
        decimal MonthlyPayment;
        decimal Pattern;
        Month month;
        decimal Interest;
        List<Payment> listPayments = new();


        Console.WriteLine("Amount of your mortgage:");
        TotalCredit = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Amount of FDPDP:");
        FDPDP = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("percengage of your CA:");
        CApercentaga = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Amount of your SDAV:");
        SDAV = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Amount of your monthly payment:");
        MonthlyPayment = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Amount of your pattern payment:");
        Pattern = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Number of month to start:");
        month = (Month)Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("% of iterest:");
        Interest = Convert.ToDecimal(Console.ReadLine());

        
        listPayments.Add(GetNewBalance(new Payment
        {
            Balance = TotalCredit,
            FDPDP = FDPDP,
            CA = ((TotalCredit * (CApercentaga / 100)) / 360) * 30,
            NMonth = 1,
            MonthlyPayment = MonthlyPayment,
            Pattern = Pattern,
            Month = month,
            SDAV = SDAV,
            Interest = ((TotalCredit * (Interest / 100)) / 360) * 30
        }));
        var tempTotal = listPayments.Last().NewBalance;
        while (tempTotal>0)
        {
            listPayments.Add(GetPayment(listPayments.Last(), Interest, CApercentaga));
            tempTotal = listPayments.Last().NewBalance;
        }
        Console.WriteLine("Tardaste estos meses en acabar tu credito: " + listPayments.Count);
        Console.WriteLine("Pagaste en total: "+listPayments.Sum(x=>x.MonthlyPayment));
        Console.WriteLine("Pagaste en total: " + listPayments.Sum(x => x.MonthlyPayment));
        Console.WriteLine("Patron paga en total: " + listPayments.Sum(x => x.Pattern));
        Console.WriteLine("Pagaste en intereses: " + listPayments.Sum(x => x.Interest));
        Console.WriteLine("Pagaste en administracion: " + listPayments.Sum(x => x.CA));
        Console.WriteLine("Pagaste en seguro vivienda: " + listPayments.Sum(x => x.SDAV));
        Console.WriteLine("Pagaste en seguro pago: " + listPayments.Sum(x => x.FDPDP));
        Console.WriteLine("Total pagos extras sin intereses: " + listPayments.Sum(x => x.SDAV + x.FDPDP + x.CA));
        Console.WriteLine("Total pagos extras con intereses: " + listPayments.Sum(x => x.SDAV + x.FDPDP + x.CA+x.Interest));
        foreach (var item in listPayments)
        {
            Console.WriteLine($"{item.NMonth}:{item.Balance} | {item.Interest}");
        }
    }

    static Payment GetPayment(Payment arg, decimal percentaInterest, decimal cap) 
    {
        Payment newPay = new()
        {
            Balance = arg.NewBalance,
            FDPDP = arg.FDPDP,
            NMonth = arg.NMonth+1,
            MonthlyPayment = arg.MonthlyPayment,
            Pattern = arg.Pattern,
            Month = arg.Month.NextMonth(),
            SDAV = arg.SDAV,
            Interest = ((arg.NewBalance * (percentaInterest / 100))/360)*30
        };
        newPay.CA = newPay.Month == Month.Enero ? ((newPay.Balance * (cap / 100)) / 360) * 30 : newPay.CA;
        return GetNewBalance(newPay);
    }

    static Payment GetNewBalance(Payment arg)
    {
        arg.NewBalance = arg.Balance + arg.FDPDP + arg.CA + arg.SDAV + arg.Interest - arg.MonthlyPayment - arg.Pattern;
        return arg;
    }
}