using System;
using EquipMe.Models;

namespace EquipMe.TemplateSelectors
{
    public class ParameterTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NumericTemplate { get; set; }
        public DataTemplate DropdownTemplate { get; set; }
        public DataTemplate MultipleSelectionTemplate { get; set; }
        public DataTemplate DateTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var parameter = item as Parameter; //TODO: make it lower case and then check 
            return parameter.Type switch
            {
                "Numeric" => NumericTemplate,
                "Dropdown" => DropdownTemplate,
                "MultipleSelection" => MultipleSelectionTemplate,
                "Date" => DateTemplate,
                _ => throw new NotImplementedException($"No template for type {parameter.Type}")
            };
        }
    }
}

