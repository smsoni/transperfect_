using System;

namespace WahooFitnessFramework
{
    public class DescriptionAttrAttribute : Attribute
    {
        public string Name { get; set; }

        public DescriptionAttrAttribute(string name)
        {
            this.Name = name;
        }
    }
}