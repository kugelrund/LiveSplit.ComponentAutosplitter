using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveSplit.ComponentAutosplitter
{
    partial class ChangeEventForm : Form
    {
        private Game game;
        public GameEvent NewEvent { get; private set; }

        public ChangeEventForm(Game game, GameEvent gameEvent)
        {
            InitializeComponent();
            this.game = game;

            foreach (Type eventType in game.EventTypes)
            {
                lstEventTypes.Items.Add(Activator.CreateInstance(eventType));
            }

            if (gameEvent != null)
            {
                lstEventTypes.SelectedIndex = Array.IndexOf(game.EventTypes, gameEvent.GetType());
            }
            else
            {
                lstEventTypes.SelectedIndex = 0;
            }
        }

        private void UpdateAttributes()
        {
            dgvAttributes.Rows.Clear();
            GameEvent selectedEvent = (lstEventTypes.SelectedItem as GameEvent);
            if (selectedEvent.AttributeNames != null)
            {
                foreach (string attribute in selectedEvent.AttributeNames)
                {
                    dgvAttributes.Rows.Add(attribute, "");
                }
            }
        }

        private void UpdateGameEvent()
        {
            List<string> attributes = new List<string>();
            foreach (DataGridViewRow row in dgvAttributes.Rows)
            {
                attributes.Add(row.Cells[AttributeValue.Index].Value as string);
            }
            
            NewEvent = Activator.CreateInstance(lstEventTypes.SelectedItem.GetType(),
                                                 attributes.ToArray()) as GameEvent;
        }

        private void lstTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAttributes();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UpdateGameEvent();
            Close();
        }
    }
}
