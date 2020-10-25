using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Client.Pages
{
    public class InputWatcher : ComponentBase
    {
        EditContext? editContext;

        [CascadingParameter]
        public EditContext? EditContext
        {
            get => editContext;

            set
            {
                editContext = value;
                if (editContext != null)
                {
                    editContext.OnFieldChanged += async (sender, e) =>
                    {
                        await FieldChanged.InvokeAsync(e.FieldIdentifier.FieldName).ConfigureAwait(true);
                    };
                }
            }
        }

        [Parameter]
        public EventCallback<string> FieldChanged { get; set; }

        public bool Validate() => EditContext?.Validate() ?? false;
    }
}
