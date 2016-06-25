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
            NewEvent = null;

            foreach (Type eventType in game.EventTypes)
            {
                lstEventTypes.Items.Add(Activator.CreateInstance(eventType));
            }

            if (gameEvent != null)
            {
                int index = Array.IndexOf(game.EventTypes, gameEvent.GetType());
                lstEventTypes.Items[index] = gameEvent;
                lstEventTypes.SelectedIndex = index;
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
                for (int i = 0; i < selectedEvent.AttributeNames.Length; i += 1)
                {
                    dgvAttributes.Rows.Add(selectedEvent.AttributeNames[i] + ":",
                                           selectedEvent.AttributeValues[i]);
                }

                if (dgvAttributes.Rows.Count > 0)
                {
                    dgvAttributes.CurrentCell = dgvAttributes.Rows[0].Cells[AttributeValue.Index];
                }
            }
        }

        private GameEvent SelectedGameEvent()
        {
            List<string> attributes = new List<string>();
            foreach (DataGridViewRow row in dgvAttributes.Rows)
            {
                attributes.Add(row.Cells[AttributeValue.Index].Value as string);
            }

            return Activator.CreateInstance(lstEventTypes.SelectedItem.GetType(),
                                             attributes.ToArray()) as GameEvent;
        }

        private void lstTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAttributes();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            NewEvent = SelectedGameEvent();
            Close();
        }

        private void dgvAttributes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            lstEventTypes.Items[lstEventTypes.SelectedIndex] = SelectedGameEvent();
            UpdateAttributes();
            btnOk.Focus();
        }
    }
}
