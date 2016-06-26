﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace LiveSplit.ComponentAutosplitter
{
    /// <summary>
    /// Component for the Autosplitter. Does the actual splitting and handles
    /// all other communication with LiveSplit.
    /// </summary>
    class Component : LogicComponent
    {
        /// <summary>
        /// The game that the autosplitter shall be used for.
        /// </summary>
        private Game game;

        /// <summary>
        /// The settings object for the autosplitter.
        /// </summary>
        private Settings settings;
        /// <summary>
        /// TimerModel, to interact with the timer in LiveSplit, i.e.
        /// splitting and so on.
        /// </summary>
        private TimerModel model = null;

        /// <summary>
        /// GameInfo object that provides information about the game.
        /// </summary>
        private GameInfo info = null;
        /// <summary>
        /// Array of GameEvents to split on.
        /// </summary>
        private GameEvent[] eventList = null;

        /// <summary>
        /// Name of the component.
        /// </summary>
        public override string ComponentName => game.Name + " Auto Splitter";

        /// <summary>
        /// Creates the component.
        /// </summary>
        /// <param name="game">
        /// The game that this component handles the splitting for.
        /// </param>
        /// <param name="state">
        /// Current state of LiveSplit.
        /// </param>
        public Component(Game game, LiveSplitState state)
        {
            this.game = game;

            model = new TimerModel() { CurrentState = state };
            model.CurrentState.OnStart += State_OnStart;

            settings = new Settings(game);
            eventList = settings.GetEventList();
            settings.EventsChanged += settings_EventsChanged;
        }

        /// <summary>
        /// Initialize game time on timerstart.
        /// </summary>
        private void State_OnStart(object sender, EventArgs e)
        {
            model.InitializeGameTime();
        }

        /// <summary>
        /// Main logic for splitting. Gets called in a loop by LiveSplit.
        /// </summary>
        public override void Update(UI.IInvalidator invalidator, LiveSplitState state, float width, float height, UI.LayoutMode mode)
        {
            if (info != null && !info.GameProcess.HasExited)
            {
                // if the game is running update our information about it
                info.Update();
                if (state.CurrentSplitIndex + 1 < eventList.Length && eventList[state.CurrentSplitIndex + 1].HasOccured(info))
                {
                    // if the current event just occured it's time to split (or start the timer).
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

                // deal with gametime. TODO: real game time (e.g. Quake)
                if (settings.PauseGameTime)
                {
                    state.IsGameTimePaused = !info.InGame;
                }
            }
            else
            {
                // if the game is not running try to find an active process
                Process gameProcess = Process.GetProcessesByName(game.ProcessName).FirstOrDefault();
                if (gameProcess != null && !gameProcess.HasExited)
                {
                    // if we found something create a GameInfo object based
                    // on the found process
                    try
                    {
                        info = new GameInfo(gameProcess);
                    }
                    catch (ArgumentException)
                    {
                        // something was still wrong with the process, try again
                        info = null;
                    }
                }
                else
                {
                    info = null;
                }
            }

            // update Segments for Settings (TODO: find a better place to do this)
            settings.Segments = state.Run;
        }

        /// <summary>
        /// Listener for when the eventslist changed in the settings.
        /// </summary>
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
