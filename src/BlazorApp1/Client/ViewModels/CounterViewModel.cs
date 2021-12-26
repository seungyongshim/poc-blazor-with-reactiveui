using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorApp1.Client.ViewModels;

public class CounterViewModel : INotifyPropertyChanged
{
    int _currentCount;

    public int CurrentCount
    {
        get => _currentCount;
        private set => OnPropertyChanged(() => _currentCount = value);
    }

    public CounterViewModel()
    {
        var timer = new Timer(o => CurrentCount++, null, 1000, 1000);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(Action action, [CallerMemberName] string? name = null)
    {
        action?.Invoke();
        PropertyChanged?.Invoke(this, new(name));
    }
}
