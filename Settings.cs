﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;

namespace LiveSplit.ComponentAutosplitter
{
    /// <summary>
    /// Settings control for a ComponentAutosplitter. Deals with
    /// saving, loading and letting the user change settings, most
    /// importantly a list of events that define when to split.
    /// </summary>
    partial class Settings : UserControl
    {
        /// <summary>
        /// The game that the autosplitter shall be used for.
        /// </summary>
        private Game game;

        /// <summary>
        /// Stuff for signaling when the eventlist changes so that the
        /// Component class can properly use the new eventlist.
        /// </summary>
        private bool eventsChanged = false;
        public event EventHandler EventsChanged;
        protected virtual void OnChanged(EventArgs e)
        {
            EventsChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Setting of whether to use GameTime.
        /// </summary>
        public bool PauseGameTime { get; private set; }
        /// <summary>
        /// Current list of segments of the run. Used in the DataGridView for the
        /// user to conveniently set events to split on for specific segments.
        /// </summary>
        public IRun Segments { private get; set; }



        /// <summary>
        /// Constructs the settings object for the ComponentAutosplitter.
        /// </summary>
        /// <param name="game">
        /// The game that the autosplitter shall be used for.
        /// </param>
        public Settings(Game game)
        {
            InitializeComponent();
            this.game = game;
            PauseGameTime = true;
        }

        /// <summary>
        /// Collect the events to split on from the DataGridView into an array. The
        /// Component class uses this method to get the eventlist, so that it knows
        /// when to split.
        /// </summary>
        /// <returns>
        /// The array of the current list of events.
        /// </returns>
        public GameEvent[] GetEventList()
        {
            int length = dgvSegmentEvents.Rows.Count;
            GameEvent[] gameEvents = new GameEvent[length + 1];

            for (int i = 0; i < length; ++i)
            {
                gameEvents[i] = (dgvSegmentEvents.Rows[i].Cells[Event.Index].Value as GameEvent)
                                ?? new EmptyEvent();
            }

            gameEvents[length] = new EmptyEvent();
            return gameEvents;
        }

        /// <summary>
        /// Updates the list of segments in the DataGridView based on the contents
        /// of the "Segments" member. The Component class updates that member when
        /// the segments changed. Also adds or removes rows of the DataGridView to
        /// match the amount of segments.
        /// </summary>
        public void UpdateSegments()
        {
            // Find out how many rows we need and add or remove rows accordingly
            int neededRows = Segments.Count + 1;
            if (dgvSegmentEvents.Rows.Count < neededRows)
            {
                // we need some more rows, add them
                dgvSegmentEvents.Rows.Add(neededRows - dgvSegmentEvents.Rows.Count);
            }
            while (dgvSegmentEvents.Rows.Count > neededRows)
            {
                // delete unnecessary rows
                dgvSegmentEvents.Rows.RemoveAt(dgvSegmentEvents.Rows.Count - 1);
            }

            // Fill out the DataGridView with the names of the segments
            for (int i = 0; i < Segments.Count; i += 1)
            {
                dgvSegmentEvents.Rows[i].Cells[Segment.Index].Value = Segments[i].Name;
            }
            // We need to make a special entry for the final split
            dgvSegmentEvents.Rows[Segments.Count].Cells[Segment.Index].Value = "--- End ---";
        }

        /// <summary>
        /// Opens a dialog for the user to change the event in the topmost
        /// selected row.
        /// </summary>
        private void ChangeEvent()
        {
            // get selected cell
            DataGridViewCell eventCell = dgvSegmentEvents.SelectedRows[0].Cells[Event.Index];

            // open form
            ChangeEventForm form = new ChangeEventForm(game, eventCell.Value as GameEvent);
            form.ShowDialog();

            // set new event
            eventCell.Value = form.NewEvent;
            eventsChanged = true;
        }

        /// <summary>
        /// Deletes all events in the DataGridView.
        /// </summary>
        private void ClearEvents()
        {
            foreach (DataGridViewRow row in dgvSegmentEvents.Rows)
            {
                row.Cells[Event.Index].Value = null;
            }
            eventsChanged = true;
        }

        /// <summary>
        /// Changes the order of the currently selected events in the DataGridView
        /// by moving them up or down.
        /// </summary>
        /// <param name="up">
        /// Whether to move upwards or downwards.
        /// </param>
        private void MoveEvents(bool up)
        {
            // To properly deal with moving multiple selected events we have
            // to get the indices of the selected rows in the correct order.
            // We cannot use "SelectedRows" directly for that cause the rows in
            // there are not sorted.
            int[] selectedIndices = new int[dgvSegmentEvents.SelectedRows.Count];
            for (int i = 0; i < dgvSegmentEvents.SelectedRows.Count; i += 1)
            {
                selectedIndices[i] = dgvSegmentEvents.SelectedRows[i].Index;
            }
            // sort the indices
            Array.Sort(selectedIndices);
            if (!up)
            {
                // When we want to move down we need to move the bottom
                // rows first so reverse the order.
                Array.Reverse(selectedIndices);
            }

            // Now that we have the sorted indices of the selected rows
            // we can move the rows.
            int newIndex;
            object tempValue;  // temporary storage for swapping
            foreach (int oldIndex in selectedIndices)
            {
                // new index for this row
                newIndex = up ? oldIndex - 1 : oldIndex + 1;
                // Don't move the row if it would get moved out of the list
                if (newIndex >= 0 && newIndex < dgvSegmentEvents.Rows.Count)
                {
                    // swap row[oldIndex] and row[newIndex]
                    tempValue = dgvSegmentEvents.Rows[oldIndex].Cells[Event.Index].Value;
                    dgvSegmentEvents.Rows[oldIndex].Cells[Event.Index].Value =
                        dgvSegmentEvents.Rows[newIndex].Cells[Event.Index].Value;
                    dgvSegmentEvents.Rows[newIndex].Cells[Event.Index].Value = tempValue;
                    // change selection so that the moved row stays selected
                    dgvSegmentEvents.Rows[newIndex].Selected = true;
                    dgvSegmentEvents.Rows[oldIndex].Selected = false;
                }
            }

            // order changed so we have to rebuild list of events
            eventsChanged = true;
        }

        /// <summary>
        /// Save the current settings to xml.
        /// </summary>
        /// <param name="document">
        /// The XmlDocument to store the settings in.
        /// </param>
        /// <returns>
        /// The created settings node.
        /// </returns>
        public XmlNode GetSettings(XmlDocument document)
        {
            // create settingsNode
            XmlElement settingsNode = document.CreateElement("settings");

            // create node for storing the current list of events. For each
            // event it's type (derived from GameEvent) will be saved together
            // with it's AttributeValues.
            XmlElement usedEventsNode = document.CreateElement("usedEvents");
            XmlElement eventNode;
            XmlElement typeNode;
            XmlElement attributeNode;
            GameEvent gameEvent;
            foreach (DataGridViewRow row in dgvSegmentEvents.Rows)
            {
                // get event from row
                gameEvent = row.Cells[Event.Index].Value as GameEvent;
                if (gameEvent == null)
                {
                    gameEvent = new EmptyEvent();
                }

                // save derived type of the event
                eventNode = document.CreateElement("event");
                typeNode = document.CreateElement("type");
                typeNode.InnerText = gameEvent.GetType().ToString();
                eventNode.AppendChild(typeNode);

                // save all attribute values
                foreach (string attributeValue in gameEvent.AttributeValues)
                {
                    attributeNode = document.CreateElement("attribute");
                    attributeNode.InnerText = attributeValue;
                    eventNode.AppendChild(attributeNode);
                }

                usedEventsNode.AppendChild(eventNode);
            }
            settingsNode.AppendChild(usedEventsNode);

            // save setting of whether to use game time
            XmlElement pauseGameTimeNode = document.CreateElement("pauseGameTime");
            pauseGameTimeNode.InnerText = PauseGameTime.ToString();
            settingsNode.AppendChild(pauseGameTimeNode);

            return settingsNode;
        }

        /// <summary>
        /// Loads settings from xml.
        /// </summary>
        /// <param name="settings">
        /// The xml node to read from.
        /// </param>
        public void SetSettings(XmlNode settings)
        {
            if (settings["usedEvents"] != null)
            {
                // make enough rows in the DataGridView for the events in the xml
                if (settings["usedEvents"].ChildNodes.Count > dgvSegmentEvents.Rows.Count)
                {
                    dgvSegmentEvents.Rows.Add(settings["usedEvents"].ChildNodes.Count -
                                              dgvSegmentEvents.Rows.Count);
                }

                // Read all events and store them in the DataGridView
                int i = 0;
                GameEvent gameEvent;
                Type type;
                List<string> attributes;
                foreach (XmlNode eventNode in settings["usedEvents"].ChildNodes)
                {
                    if (eventNode.FirstChild.HasChildNodes)
                    {
                        // get the type of the event.
                        type = Type.GetType(eventNode.FirstChild.InnerText);

                        // read the attributes of the event
                        attributes = new List<string>();
                        foreach (XmlNode node in eventNode.ChildNodes)
                        {
                            if (node != eventNode.FirstChild)
                            {
                                attributes.Add(node.InnerText);
                            }
                        }

                        // Create a new GameEvent object based on the read type and attributes
                        gameEvent = Activator.CreateInstance(type, attributes.ToArray()) as GameEvent;
                    }
                    else
                    {
                        // fallback to read old autosplitter settings
                        gameEvent = game.ReadLegacyEvent(eventNode.InnerText);
                    }

                    // store the event in the DataGridView
                    dgvSegmentEvents.Rows[i].Cells[Event.Index].Value = gameEvent;
                    i += 1;
                }

                // signal that events have changed
                OnChanged(EventArgs.Empty);
                eventsChanged = false;
            }

            bool pauseGameTime;
            if (settings["pauseGameTime"] != null && Boolean.TryParse(settings["pauseGameTime"].InnerText, out pauseGameTime))
            {
                // read setting of whether to use game time
                PauseGameTime = pauseGameTime;
            }
        }

        private void btnChangeEvent_Click(object sender, EventArgs e)
        {
            ChangeEvent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEvents();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveEvents(false);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveEvents(true);
        }

        private void dgvSegmentEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Event.Index)
            {
                ChangeEvent();
            }
        }

        private void Settings_HandleDestroyed(object sender, EventArgs e)
        {
            if (eventsChanged)
            {
                eventsChanged = false;
                OnChanged(EventArgs.Empty);
            }
        }
    }
}
