using JustWork.Models;
using System.Data.Entity;

namespace JustWork.ViewModel
{
    internal class CommonViewModel
    {
        public ExtrabudgetViewModel ExtrabudgetView { get; set; }
        public BudgetViewModel BudgetView { get; set; }
        public CommonViewModel()
        {
            Model dataModel = new Model();
            dataModel.Specialties.Load();
            ExtrabudgetView = new ExtrabudgetViewModel(dataModel);
            BudgetView = new BudgetViewModel(dataModel);
        }
    }
}
