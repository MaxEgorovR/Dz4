

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

LongTermContribution lContribution = new LongTermContribution();
ShortTermContribution shContribution = new ShortTermContribution();
int choise;
bool flag = true;
Console.WriteLine("Введите сумму долгосрочного вклада:");
lContribution.SumOfContribution = double.Parse(Console.ReadLine());
Console.WriteLine("Введите количество месяцев долгосрочного вклада:");
lContribution.NumberOfMonths = double.Parse(Console.ReadLine());
Console.WriteLine("Введите сумму краткосрочного вклада:");
shContribution.SumOfContribution = double.Parse(Console.ReadLine());
Console.WriteLine("Введите количество месяцев краткосрочного вклада:");
shContribution.NumberOfMonths = double.Parse(Console.ReadLine());
while (flag)
{
    Console.WriteLine("1 - Расчитать сумму долгосрочного вклада\n2 - Расчитать сумму краткосрочного вклада\n3 - Сменить данные по долгосрочному вкладу\n4 - Сменить данные по краткосрочному вкладу\nИначе - Выход");
    choise = int.Parse(Console.ReadLine());
    if(choise == 1)
    {
        Console.WriteLine("Итоговая сумма: "+lContribution.CalculationDepositAmount(lContribution.NumberOfMonths));
    }
    else if(choise == 2)
    {
        Console.WriteLine("Итоговая сумма: " + shContribution.CalculationDepositAmount(shContribution.NumberOfMonths));
    }
    else if(choise == 3)
    {
        lContribution = new LongTermContribution();
        Console.WriteLine("Введите сумму долгосрочного вклада:");
        lContribution.SumOfContribution = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество месяцев долгосрочного вклада:");
        lContribution.NumberOfMonths = double.Parse(Console.ReadLine());
    }
    else if(choise == 4)
    {
        shContribution = new ShortTermContribution();
        Console.WriteLine("Введите сумму краткосрочного вклада:");
        shContribution.SumOfContribution = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество месяцев краткосрочного вклада:");
        shContribution.NumberOfMonths = double.Parse(Console.ReadLine());
    }
    else
    {
        flag = false;
    }
}

class Bank
{
    /// <summary>
    /// Название банка
    /// </summary>
    public string Name { get; set; }
}

class Вranch
{
    /// <summary>
    /// Название филиала
    /// </summary>
    public string Name { get; set; }

    private double sumOfContributions;
    /// <summary>
    /// Общая сумма вкладов
    /// </summary>
    public double SumOfContributions {
        get { return sumOfContributions; }
        set
        {
            try
            {
                if (value > 0)
                {
                    sumOfContributions = value;
                }
                else throw new VkladException();
            }
            catch (VkladException ex)
            {
                ex.VkladCount(value);
            }
        }
    }
}

class Contribution
{
    /// <summary>
    /// ФИО вкладчика
    /// </summary>
    public string FIO { get; set; }


    private double sumOfContribution;
    /// <summary>
    /// Сумма вклада 
    /// </summary>
    public double SumOfContribution {
        get { return sumOfContribution; }
        set
        {
            try
            {
                if (value > 0)
                {
                    sumOfContribution = value;
                }
                else throw new VkladException();
            }
            catch (VkladException ex)
            {
                ex.VkladCount(value);
            }
        }
    }

    private double numberOfMonths;
    /// <summary>
    /// 
    /// </summary>
    public double NumberOfMonths 
    {
        get { return numberOfMonths; }
        set 
        {
            try
            {
                if (value > 0)
                {
                    numberOfMonths = value;
                }
                else throw new KolichestvoException();
            }
            catch (KolichestvoException ex)
            {
                ex.MonthCount(value);
            }
        }
    }

    /// <summary>
    /// Расчёт вклада
    /// </summary>
    /// <param name="Количество месяцев"></param>
    /// <returns name="Сумма вклада"></returns>
    public double CalculationDepositAmount(double numberOfMonths)
    {
        return 0;
    }
}

class LongTermContribution : Contribution
{
    /// <summary>
    /// Расчёт вклада
    /// </summary>
    /// <param name="Количество месяцев"></param>
    /// <returns name="Сумма вклада"></returns>
    public new double CalculationDepositAmount(double numberOfMonths)
    {
        try
        {
            if (numberOfMonths > 0)
            {
                for (int i = 0; i < numberOfMonths; i++)
                {
                    this.SumOfContribution += this.SumOfContribution * 0.16;
                }
                return this.SumOfContribution;
            }
            else throw new KolichestvoException();
        }
        catch (KolichestvoException ex)
        {
            ex.MonthCount(numberOfMonths);
        }
        return 0;
    }
}

class ShortTermContribution : Contribution
{
    /// <summary>
    /// Расчёт вклада
    /// </summary>
    /// <param name="Количество месяцев"></param>
    /// <returns name="Сумма вклада"></returns>
    public new double CalculationDepositAmount(double numberOfMonths)
    {
        try
        {
            if (numberOfMonths > 0)
            {
                for (int i = 0; i < numberOfMonths; i++)
                {
                    this.SumOfContribution += this.SumOfContribution * 0.03;
                }
                return this.SumOfContribution;
            }
            else throw new KolichestvoException();
        }
        catch (KolichestvoException ex)
        {
            ex.MonthCount(numberOfMonths);
        }
        return 0;
    }
}

class KolichestvoException : Exception
{
    public void MonthCount(double months)
    {
        Console.WriteLine("Error: "+this.Message + "\nНевозможное количество месяцев: " + months);
    }
}

class VkladException : Exception
{
    public void VkladCount(double sum)
    {
        Console.WriteLine("Error: " + this.Message+"\nНевозможная сумма вклада: "+sum);
    }
}