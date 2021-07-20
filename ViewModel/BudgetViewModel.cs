using JustWork.Models;
using JustWork.ViewModel.Interface;
using System.ComponentModel;
using System.Linq;

namespace JustWork.ViewModel
{
    class BudgetViewModel : PropertyChange
    {
        private BindingList<Specialties> budgetGroups;
        private Command addOne;
        private Command minOne;
        private Command addPriorityOne;
        private Command minPriorityOne;
        private Model model;
        public Command MinOne
        {
            get
            {
                return minOne ?? (minOne = new Command(obj =>
                {
                    ChangeCountAmountStatement(obj, -1);
                    SaveChangeAndChange();
                }));
            }
        }
        public Command AddOne
        {
            get
            {
                return addOne ?? (addOne = new Command(obj =>
                {
                    ChangeCountAmountStatement(obj, 1);
                    SaveChangeAndChange();
                }));
            }
        }
        public Command AddPriorityOne
        {
            get
            {
                return addPriorityOne ?? (addPriorityOne = new Command(obj =>
                {
                    ChangePriority(obj, 1);
                }));
            }
        }
        public Command MinPriorityOne
        {
            get
            {
                return minPriorityOne ?? (minPriorityOne = new Command(obj =>
                {
                    ChangePriority(obj, -1);
                }));
            }
        }
        private void ChangeCountAmountStatement(object obj, int value)
        {
            var speciality = obj as Specialties;
            speciality.AmountStatements += value;
        }
        private void SaveChangeAndChange()
        {
            ChangingProperty(nameof(BudgetGroups));
            model.SaveChanges();
        }
        private void ChangePriority(object obj, int value)
        {
            var speciality = obj as Specialties;
            speciality.AmountPriority += value;
            if (value == 1)
                addOne.Execute(obj);
            else
                minOne.Execute(obj);
        }
        public BudgetViewModel(Model model)
        {
            this.model = model;
            FillSpecialtie();
        }
        public BindingList<Specialties> BudgetGroups
        {
            get => budgetGroups;
            set
            {
                budgetGroups = value;
                ChangingProperty(nameof(BudgetGroups));
            }
        }
        private void FillSpecialtie()
        {
            var specialties = model.Specialties.Local.Where(x => x.Budget).ToList();
            BudgetGroups = new BindingList<Specialties>(specialties);
        }
    }
}