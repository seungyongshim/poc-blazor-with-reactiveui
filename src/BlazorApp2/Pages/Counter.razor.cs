using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorApp2;
using BlazorApp2.Shared;
using Proto;

namespace BlazorApp2.Pages
{
    
    public partial class Counter 
    {
        [Inject]
        RootContext Context { get; set; }

        Action<object> Command { get; set; }

        CounterState State { get; set; }

        protected override void OnInitialized()
        {
            Command = c => Context.Send(new PID(Context.System.Address, "CounterActor"), c);

            Command(new ViewInitialized());

            var a = Context.System.EventStream.Subscribe<CounterState>(s =>
            {
                State = s;
                StateHasChanged();
            });
        }
    }
}
