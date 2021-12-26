using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorApp1.Client.ViewModels;

public class CounterViewModel : INotifyPropertyChanged, IDisposable
{
    private int _currentCount;

    public int CurrentCount
    {
        get => _currentCount;
        private set => OnPropertyChanged(ref _currentCount , value);
    }

    List<IDisposable> Disposes { get; } = new List<IDisposable>();

    public CounterViewModel()
    {
        var timer = new Timer(o => CurrentCount++, null, 1000, 1000);

        Disposes.Add(timer);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged<T>(ref T store, T value,  [CallerMemberName] string? name = null)
        where T : IEquatable<T>
    {
        if( EqualityComparer<T>.Default.Equals(store, value) ) return;

        store = value;
        PropertyChanged?.Invoke(this, new(name));
    }

    public void Dispose()
    {
        foreach (var item in Disposes)
        {
            item.Dispose();
        }
        Disposes.Clear();
    }
}
