using System.Windows.Forms;

namespace LiveSplit.ComponentAutosplitter
{
    class CustomSettingBool
    {
        public string Description { get; }
        public bool Value { get; set; }
        private CheckBox control;

        public CustomSettingBool(string description, bool defaultValue)
        {
            Description = description;
            Value = defaultValue;
        }

        public CheckBox GetControl()
        {
            control = new CheckBox();
            control.Checked = Value;
            control.Text = Description;
            control.Dock = DockStyle.Fill;
            control.DataBindings.Add("Checked", this, "Value", false, DataSourceUpdateMode.OnPropertyChanged);
            return control;
        }
    }
}
