using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveSplit.ComponentAutosplitter
{
    /// <summary>
    /// Form for choosing a GameEvent from a list and settings attributes
    /// </summary>
    partial class ChangeEventForm : Form
    {
        /// <summary>
        /// The game that the autosplitter shall be used for.
        /// </summary>
        private Game game;

        /// <summary>
        /// The event that the user selects. This can be read when
        /// the form closed.
        /// </summary>
        public GameEvent NewEvent { get; private set; }

        /// <summary>
        /// Creates the ChangeEventForm.
        /// </summary>
        /// <param name="game">
        /// The game that the ComponentAutosplitter is used for.
        /// </param>
        /// <param name="gameEvent">
        /// The previous gameEvent. Used to initialize the form with the previous
        /// previous. Can be <code>null</code> if there was no previous value.
        /// </param>
        public ChangeEventForm(Game game, GameEvent gameEvent)
        {
            InitializeComponent();
            this.game = game;
            NewEvent = null;

            // add all the possible types of Events that this game has to the
            // listbox that the user can choose from
            foreach (Type eventType in game.EventTypes)
            {
                // TODO: Exception handling
                lstEventTypes.Items.Add(Activator.CreateInstance(eventType));
            }

            // default select the first one
            lstEventTypes.SelectedIndex = 0;
            if (gameEvent != null)
            {
                // If there was a previous value select that one
                int index = Array.IndexOf(game.EventTypes, gameEvent.GetType());
                if (index != -1)
                {
                    lstEventTypes.Items[index] = gameEvent;
                    lstEventTypes.SelectedIndex = index;
                    UpdateAttributes();
                }
            }
        }

        /// <summary>
        /// Updates the list of attributes based on the currently
        /// selected GameEvent.
        /// </summary>
        private void UpdateAttributes()
        {
            // clear attributes first
            dgvAttributes.Rows.Clear();
            // get currently selected event
            GameEvent selectedEvent = (lstEventTypes.SelectedItem as GameEvent);
            // check if the event even has attributes
            if (selectedEvent.AttributeNames != null)
            {
                // add all attributes to the DataGridView
                for (int i = 0; i < selectedEvent.AttributeNames.Length; i += 1)
                {
                    dgvAttributes.Rows.Add(selectedEvent.AttributeNames[i] + ":",
                                           selectedEvent.AttributeValues[i]);
                }

                // set the current cell for convenient instant editing
                if (dgvAttributes.Rows.Count > 0)
                {
                    dgvAttributes.CurrentCell = dgvAttributes.Rows[0].Cells[AttributeValue.Index];
                }
            }
        }

        /// <summary>
        /// Returns the GameEvent selected by the user (with the given attributes).
        /// </summary>
        /// <returns>
        /// The GameEvent currently chosen by the user.
        /// </returns>
        private GameEvent SelectedGameEvent()
        {
            // collect attributes
            List<string> attributes = new List<string>();
            foreach (DataGridViewRow row in dgvAttributes.Rows)
            {
                attributes.Add(row.Cells[AttributeValue.Index].Value as string);
            }

            // create instance (TODO: exception handling?)
            return Activator.CreateInstance(lstEventTypes.SelectedItem.GetType(),
                                            attributes.ToArray()) as GameEvent;
        }

        /// <summary>
        /// Closes the form but stores the new event at first.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            NewEvent = SelectedGameEvent();
            Close();
        }

        /// <summary>
        /// When the selected index of the listbox changes we have to update the attribue
        /// list because different event can potentially mean different attributes.
        /// </summary>
        private void lstTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAttributes();
        }

        /// <summary>
        /// When a cell value changes an attribute was changed by the user, so we
        /// store the attributes for the currently selected event.
        /// </summary>
        private void dgvAttributes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            lstEventTypes.Items[lstEventTypes.SelectedIndex] = SelectedGameEvent();
            UpdateAttributes();
            // often you will just want to quit the dialog after setting an
            // attribute, so the the focus on the OK button for convenience
            btnOk.Focus();
        }
    }
}
