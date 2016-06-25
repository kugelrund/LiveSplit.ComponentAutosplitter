using System;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace LiveSplit.ComponentAutosplitter
{
    class Component : LogicComponent
    {
        private Game game;

        private Settings settings;
        private TimerModel model = null;

        private GameInfo info = null;
        private GameEvent[] eventList = null;

        public override string ComponentName => game.Name + " Auto Splitter";

        public Component(Game game, LiveSplitState state)
        {
            this.game = game;

            model = new TimerModel() { CurrentState = state };
            model.CurrentState.OnStart += State_OnStart;

            settings = new Settings(game);
            eventList = settings.GetEventList();
            settings.EventsChanged += settings_EventsChanged;
        }

        private void State_OnStart(object sender, EventArgs e)
        {
            model.InitializeGameTime();
        }

        public override void Update(UI.IInvalidator invalidator, LiveSplitState state, float width, float height, UI.LayoutMode mode)
        {
            if (info != null && !info.GameProcess.HasExited)
            {
                info.Update();
                if (state.CurrentSplitIndex + 1 < eventList.Length && eventList[state.CurrentSplitIndex + 1].HasOccured(info))
                {
                    if (state.CurrentPhase == TimerPhase.NotRunning)
                    {
                        state.IsGameTimePaused = false;
                        model.Start();
                    }
                    else
                    {
                        model.Split();
                    }
                }

                if (settings.PauseGameTime)
                {
                    state.IsGameTimePaused = !info.InGame;
                }
            }
            else
            {
                Process gameProcess = Process.GetProcessesByName(game.ProcessName).FirstOrDefault();
                if (gameProcess != null && !gameProcess.HasExited)
                {
                    info = Activator.CreateInstance(typeof(GameInfo), gameProcess) as GameInfo;
                }
                else
                {
                    info = null;
                }
            }

            settings.Segments = state.Run;
        }

        private void settings_EventsChanged(object sender, EventArgs e)
        {
            eventList = settings.GetEventList();
        }

        public override System.Windows.Forms.Control GetSettingsControl(UI.LayoutMode mode)
        {
            settings.UpdateSegments();
            return settings;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return settings.GetSettings(document);
        }

        public override void SetSettings(XmlNode settings)
        {
            this.settings.SetSettings(settings);
        }

        public override void Dispose()
        {
            model.CurrentState.OnStart -= State_OnStart;
            settings.EventsChanged -= settings_EventsChanged;
            settings.Dispose();
        }
    }
}
