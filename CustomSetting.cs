using System.Windows.Forms;

namespace LiveSplit.ComponentAutosplitter
{
    class CustomSettingBool
    {
        public string Description { get; }
        public bool Value { get; set; }
        public CheckBox Control { get; }

        public CustomSettingBool(string description, bool defaultValue)
        {
            Description = description;
            Value = defaultValue;
            Control = new CheckBox();
            Control.Checked = Value;
            Control.Text = Description;
            Control.Dock = DockStyle.Fill;
            Control.DataBindings.Add("Checked", this, "Value", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
