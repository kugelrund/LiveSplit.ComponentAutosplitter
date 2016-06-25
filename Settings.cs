using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;

namespace LiveSplit.ComponentAutosplitter
{
    partial class Settings : UserControl
    {
        private Game game;

        private bool eventsChanged = false;
        public event EventHandler EventsChanged;
        protected virtual void OnChanged(EventArgs e)
        {
            EventsChanged?.Invoke(this, e);
        }

        public bool PauseGameTime { get; private set; }
        public IRun Segments { private get; set; }

        public Settings(Game game)
        {
            InitializeComponent();
            this.game = game;
            PauseGameTime = true;
        }

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

        public void UpdateSegments()
        {
            if (dgvSegmentEvents.Rows.Count < Segments.Count + 1)
            {
                dgvSegmentEvents.Rows.Add(Segments.Count + 1 - dgvSegmentEvents.Rows.Count);
            }

            for (int i = 0; i < Segments.Count; i += 1)
            {
                dgvSegmentEvents.Rows[i].Cells[Segment.Index].Value = Segments[i].Name;
            }
            dgvSegmentEvents.Rows[Segments.Count].Cells[Segment.Index].Value = "--- End ---";
        }

        private void ClearEvents()
        {
            foreach (DataGridViewRow row in dgvSegmentEvents.Rows)
            {
                row.Cells[Event.Index].Value = "";
            }
            eventsChanged = true;
        }

        private void ChangeEvent()
        {
            DataGridViewCell eventCell = dgvSegmentEvents.SelectedRows[0].Cells[Event.Index];
            ChangeEventForm form = new ChangeEventForm(game, eventCell.Value as GameEvent);
            form.ShowDialog();
            eventCell.Value = form.NewEvent;
            eventsChanged = true;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("settings");

            XmlElement usedEventsNode = document.CreateElement("usedEvents");
            XmlElement eventNode;
            XmlElement typeNode;
            XmlElement attributeNode;
            GameEvent gameEvent;
            foreach (DataGridViewRow row in dgvSegmentEvents.Rows)
            {
                gameEvent = row.Cells[Event.Index].Value as GameEvent;
                if (gameEvent == null)
                {
                    gameEvent = new EmptyEvent();
                }
                eventNode = document.CreateElement("event");
                typeNode = document.CreateElement("type");
                typeNode.InnerText = gameEvent.GetType().ToString();
                eventNode.AppendChild(typeNode);

                foreach (string attributeValue in gameEvent.AttributeValues)
                {
                    attributeNode = document.CreateElement("attribute");
                    attributeNode.InnerText = attributeValue;
                    eventNode.AppendChild(attributeNode);
                }

                usedEventsNode.AppendChild(eventNode);
            }
            settingsNode.AppendChild(usedEventsNode);

            XmlElement pauseGameTimeNode = document.CreateElement("pauseGameTime");
            pauseGameTimeNode.InnerText = PauseGameTime.ToString();
            settingsNode.AppendChild(pauseGameTimeNode);

            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            if (settings["usedEvents"] != null)
            {
                if (settings["usedEvents"].ChildNodes.Count > dgvSegmentEvents.Rows.Count)
                {
                    dgvSegmentEvents.Rows.Add(settings["usedEvents"].ChildNodes.Count - dgvSegmentEvents.Rows.Count);
                }

                int i = 0;
                foreach (XmlNode eventNode in settings["usedEvents"].ChildNodes)
                {
                    GameEvent gameEvent;
                    if (eventNode.FirstChild.HasChildNodes)
                    {
                        Type type = Type.GetType(eventNode.FirstChild.InnerText);
                        List<string> attributes = new List<string>();
                        foreach (XmlNode node in eventNode.ChildNodes)
                        {
                            if (node != eventNode.FirstChild)
                            {
                                attributes.Add(node.InnerText);
                            }
                        }

                        gameEvent = Activator.CreateInstance(type, attributes.ToArray()) as GameEvent;
                    }
                    else
                    {
                        // fallback to read old autosplitter settings
                        gameEvent = game.ReadLegacyEvent(eventNode.InnerText);
                    }

                    dgvSegmentEvents.Rows[i].Cells[Event.Index].Value = gameEvent;
                    i += 1;
                }

                OnChanged(EventArgs.Empty);
                eventsChanged = false;
            }

            bool pauseGameTime;
            if (settings["pauseGameTime"] != null && Boolean.TryParse(settings["pauseGameTime"].InnerText, out pauseGameTime))
            {
                PauseGameTime = pauseGameTime;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEvents();
        }

        private void btnChangeEvent_Click(object sender, EventArgs e)
        {
            ChangeEvent();
        }

        private void Settings_HandleDestroyed(object sender, EventArgs e)
        {
            if (eventsChanged)
            {
                eventsChanged = false;
                OnChanged(EventArgs.Empty);
            }
        }

        private void dgvSegmentEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Event.Index)
            {
                ChangeEvent();
            }
        }

        private void MoveEvents(bool up)
        {
            int[] selectedIndices = new int[dgvSegmentEvents.SelectedRows.Count];
            for (int i = 0; i < dgvSegmentEvents.SelectedRows.Count; i += 1)
            {
                selectedIndices[i] = dgvSegmentEvents.SelectedRows[i].Index;
            }
            Array.Sort(selectedIndices);
            if (!up)
            {
                Array.Reverse(selectedIndices);
            }

            int newIndex;
            object tempValue;
            foreach (int oldIndex in selectedIndices)
            {
                newIndex = up ? oldIndex - 1 : oldIndex + 1;
                if (newIndex >= 0)
                {
                    tempValue = dgvSegmentEvents.Rows[oldIndex].Cells[Event.Index].Value;
                    if (oldIndex < dgvSegmentEvents.Rows.Count - 1)
                    {
                        dgvSegmentEvents.Rows[oldIndex].Cells[Event.Index].Value =
                            dgvSegmentEvents.Rows[newIndex].Cells[Event.Index].Value;
                        dgvSegmentEvents.Rows[newIndex].Cells[Event.Index].Value = tempValue;
                    }
                    else
                    {
                        dgvSegmentEvents.Rows[oldIndex].Cells[Event.Index].Value = null;
                        dgvSegmentEvents.Rows.Add("", tempValue);
                    }
                    dgvSegmentEvents.Rows[newIndex].Selected = true;
                    dgvSegmentEvents.Rows[oldIndex].Selected = false;
                }
            }

            eventsChanged = true;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveEvents(false);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveEvents(true);
        }
    }
}
