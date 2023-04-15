using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Utilities;


namespace FinalProject.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {

        public RelayCommand RegistrationViewCommand { get; set; }
        public RelayCommand IntroduceViewCommand { get; set; }

        public RegistrationVM RegistrationVM {get; set;}
        public IntroduceVM IntroduceVM {get; set;}

        private Object _currentView;

        public Object CurrentView
        {

            get { return _currentView; }

            set
            {
                _currentView = value;
                OnPropertyChanged();
                // name에 해당하는 이름을 갖는 데이터에 변화가 생일때마다 이벤트를 발생시키는 메서드
            }

        }

        public MainViewModel()
        {
            RegistrationVM = new RegistrationVM();
            IntroduceVM = new IntroduceVM();

            RegistrationViewCommand = new RelayCommand(o =>
            {
                CurrentView = RegistrationVM;
            });

            IntroduceViewCommand = new RelayCommand(o =>
            {
                CurrentView = IntroduceVM;
            });
        }
    }
}
