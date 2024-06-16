// FormFactories.cs
using System;
using System.Windows.Forms;

namespace DairyFarmSystem
{
    public interface IFormFactory
    {
        Form CreateForm();
    }

    public class CowsFactory : IFormFactory
    {
        public Form CreateForm() => new Cows();
    }

    public class MilkSalesFactory : IFormFactory
    {
        public Form CreateForm() => new MilkSales();
    }

    public class MilkProductionFactory : IFormFactory
    {
        public Form CreateForm() => new MilkProduction();
    }

    public class CowHealthFactory : IFormFactory
    {
        public Form CreateForm() => new CowHealth();
    }

    public class BreedingFactory : IFormFactory
    {
        public Form CreateForm() => new Breeding();
    }

    public class FinancesFactory : IFormFactory
    {
        public Form CreateForm() => new Finances();
    }

    public class DashboardFactory : IFormFactory
    {
        public Form CreateForm() => new Dashboard();
    }
}
