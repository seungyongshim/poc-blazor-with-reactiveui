using BlazorApp2;
using Proto;

record CounterState(int Count);
public class CounterActor : IActor
{
    CounterState State { get; set; } = new CounterState(0);

    public record Increase;

    Task ChangeState(IContext c, Func<CounterState, CounterState> func)
    {
        State = func(State);
        c.System.EventStream.Publish(State);
        return Task.CompletedTask;
    }

    public Task ReceiveAsync(IContext c) => c.Message switch
    {
        Started => Task.CompletedTask,
        Increase => ChangeState(c, s => s with
        {
            Count = s.Count + 1
        }),
        ViewInitialized => ChangeState(c, s => s),
        _ => Task.CompletedTask
    };
}
