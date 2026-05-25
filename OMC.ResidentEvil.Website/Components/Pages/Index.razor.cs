using Microsoft.AspNetCore.Components;
using OMC.ResidentEvil.BackEnd.Enums;

namespace OMC.ResidentEvil.Website.Components.Pages
{    public partial class Index
    {

        Views _selectedValue = 0;
        Dictionary<int, string> _options = new Dictionary<int, string>();

        protected override void OnInitialized() {
            foreach (Views option in Enum.GetValues(typeof(Views))) {

                _options.Add((int)option, option.ToString());
            }                   
        }

        protected async Task selectedGrid(ChangeEventArgs e)
        {
            _selectedValue = (Views)System.Convert.ToInt32(e.Value);
            Console.WriteLine($"Selected: {_selectedValue}");
        }
    }
}
