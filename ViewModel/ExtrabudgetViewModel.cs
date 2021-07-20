using JustWork.Models;
using JustWork.ViewModel.Interface;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace JustWork.ViewModel
{
    class ExtrabudgetViewModel : PropertyChange
    {
        private ObservableCollection<Specialties> extrabudgetGroups;
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
                }));
            }
        }

        private void ChangeCountAmountStatement(object obj, int value)
        {
            var speciality = obj as Specialties;
            speciality.AmountStatements += value;
            SaveChangeAndChange();
        }

        private void SaveChangeAndChange()
        {
            try
            {
                model.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var lineError = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:\n",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        lineError += string.Format("- Property: \"{0}\", Error: \"{1}\"\n",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                    MessageBox.Show(lineError, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            ChangingProperty(nameof(ExtrabudgetGroups));
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
        private void ChangePriority(object obj, int value)
        {
            var speciality = obj as Specialties;
            speciality.AmountPriority += value;
            if (value == 1)
                addOne.Execute(obj);
            else
                minOne.Execute(obj);
        }
        public ExtrabudgetViewModel(Model model)
        {
            this.model = model;
            ExtrabudgetGroups = new ObservableCollection<Specialties>(model.Specialties.Local.Where(x => !x.Budget));
        }
        public ObservableCollection<Specialties> ExtrabudgetGroups 
        {
            get => extrabudgetGroups;
            set 
            { 
                extrabudgetGroups = value; 
                ChangingProperty(nameof(ExtrabudgetGroups));
            }
        }
    }
}