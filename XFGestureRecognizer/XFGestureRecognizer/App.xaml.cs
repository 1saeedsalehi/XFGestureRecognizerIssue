using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFGestureRecognizer
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        int _tapCounter;

        public MainPageViewModel()
        {
            TapCommand = new Command(OnTapped);
        }

        public ICommand TapCommand { get; }

        public int TapCounter
        {
            get => _tapCounter;
            set
            {
                if (_tapCounter == value)
                {
                    return;
                }

                _tapCounter = value;

                OnPropertyChanged();
            }
        }

        void OnTapped()
        {
            TapCounter++;
        }

        #region INotifyPropertyChanged 

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
