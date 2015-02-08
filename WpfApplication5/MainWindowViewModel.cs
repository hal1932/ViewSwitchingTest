using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace WpfApplication5
{
    class ViewModelBase : BindableBase
    {
        #region Label変更通知プロパティ
        private string _Label;

        public string Label
        {
            get
            { return _Label; }
            set
            { 
                if (_Label == value)
                    return;
                _Label = value;
                OnPropertyChanged("Label");
            }
        }
        #endregion

    }

    class ViewModelA : ViewModelBase
    {
        public ViewModelA()
        {
            Label = "AAAAA";
        }
    }

    class ViewModelB : ViewModelBase
    {
        public ViewModelB()
        {
            Label = "BBBBB";
        }
    }

    class MainWindowViewModel : BindableBase
    {
        #region ContentViewModel変更通知プロパティ
        private object _ContentViewModel;

        public object ContentViewModel
        {
            get
            { return _ContentViewModel; }
            set
            { 
                if (_ContentViewModel == value)
                    return;
                _ContentViewModel = value;
                OnPropertyChanged("ContentViewModel");
            }
        }
        #endregion

        #region SwitchContentViewModelCommand
        private DelegateCommand<object> _SwitchContentViewModelCommand;

        public DelegateCommand<object> SwitchContentViewModelCommand
        {
            get
            {
                if (_SwitchContentViewModelCommand == null)
                {
                    _SwitchContentViewModelCommand = new DelegateCommand<object>(SwitchContentViewModel);
                }
                return _SwitchContentViewModelCommand;
            }
        }

        public void SwitchContentViewModel(object parameter)
        {
            if (ContentViewModel is ViewModelA) ContentViewModel = new ViewModelB();
            else ContentViewModel = new ViewModelA();
        }
        #endregion


        public MainWindowViewModel()
        {
            ContentViewModel = new ViewModelA();
        }
    }
}
