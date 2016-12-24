using System;
using System.Diagnostics;
using LiveSplit.ComponentUtil;

namespace LiveSplit.ComponentAutosplitter
{
    /// <summary>
    /// Defines an abstract Game. Stores basic information about a game
    /// that are essential to know for the autosplitter, most importantly
    /// what types of events to split on are available for a game.
    /// </summary>
    abstract class Game
    {
        /// <summary>
        /// Array of the possible Type's that split-events can
        /// have for this game.
        /// </summary>
        public abstract Type[] EventTypes { get; }

        /// <summary>
        /// Full name of the game.
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Executable names of the game.
        /// </summary>
        public abstract string[] ProcessNames { get; }
        /// <summary>
        /// Whether game time is supported for the game.
        /// </summary>
        public abstract bool GameTimeExists { get; }
        /// <summary>
        /// Whether load removal is supported for the game.
        /// </summary>
        public abstract bool LoadRemovalExists { get; }
        /// <summary>
        /// Array of custom settings
        /// </summary>
        public readonly CustomSettingBool[] CustomSettings;

        /// <summary>
        /// Constructor for custom settings
        /// </summary>
        /// <param name="customSettings">custom settings</param>
        public Game(CustomSettingBool[] customSettings)
        {
            CustomSettings = customSettings;
        }

        /// <summary>
        /// Allows to define a function that reads a GameEvent from an xml string
        /// directly as a fallback for old autosplitter settings that don't use
        /// the save system used by this version of the ComponentAutosplitter.
        /// </summary>
        /// <param name="id">
        /// The "id" of the event that has to be interpreted by this function
        /// to output the corresponding GameEvent;
        /// </param>
        /// <returns></returns>
        public virtual GameEvent ReadLegacyEvent(string id)
        {
            // in general we don't know (and also don't need it)
            // so just return an EmptyEvent
            return new EmptyEvent();
        }
    }

    /// <summary>
    /// Provides properties and functions to gather information about a game.
    /// This is a partial class because it is expected to be extended for each
    /// game that shall use this ComponentAutosplitter (an inheritance approach
    /// caused a lot of issues with the GameEvent class and didn't work well
    /// at all but please tell me if you have a better idea).
    /// </summary>
    partial class GameInfo
    {
        /// <summary>
        /// The process that information is gathered for.
        /// </summary>
        private Process gameProcess;
        /// <summary>
        /// Base address of the process.
        /// </summary>
        private IntPtr baseAddress;

        /// <summary>
        /// Provides read access to "gameProcess".
        /// </summary>
        public Process GameProcess => gameProcess;
        /// <summary>
        /// Whether the game is currently ingame, e.g. not in a loading state.
        /// </summary>
        public bool InGame { get; protected set; }
        /// <summary>
        /// Current game time if supported.
        /// </summary>
        public double GameTime { get; protected set; }

        /// <summary>
        /// Creates a GameInfo object for the give process.
        /// </summary>
        /// <param name="gameProcess">
        /// The process that information shall be gathered for.
        /// </param>
        public GameInfo(Process gameProcess)
        {
            this.gameProcess = gameProcess;
            try
            {
                baseAddress = gameProcess.MainModuleWow64Safe().BaseAddress;
                GetVersion();
            }
            catch
            {
                throw new ArgumentException("Faulty process handle!");
            }
        }

        /// <summary>
        /// Wrapper that calls the SetCustomSettings function.
        /// </summary>
        public void UpdateCustomSettings(CustomSettingBool[] customSettings)
        {
            SetCustomSettings(customSettings);
        }

        /// <summary>
        /// Wrapper that calls the UpdateInfo function to update information
        /// about the game.
        /// </summary>
        public void Update()
        {
            UpdateInfo();
        }

        /// <summary>
        /// Wrapper that calls the ResetInfo function.
        /// </summary>
        public void Reset()
        {
            ResetInfo();
        }

        /// <summary>
        /// Update custom settings
        /// </summary>
        partial void SetCustomSettings(CustomSettingBool[] customSettings);

        /// <summary>
        /// Updates information about the game. This is expected to
        /// be implemented for each specific game
        /// </summary>
        partial void UpdateInfo();

        /// <summary>
        /// Gets the version of the game and sets stuff up accordingly.
        /// </summary>
        partial void GetVersion();

        /// <summary>
        /// Used to reset stuff like game time.
        /// </summary>
        partial void ResetInfo();
    }

    /// <summary>
    /// Defines an abstract GameEvent, i.e. an event that can happen in
    /// the game that can issue the autosplitter to split. Specific game
    /// implementations will define events that inherit from this class.
    ///
    /// When you create a Event class make sure to provide a parameterless
    /// constructor that will be needed in the ChangeEventForm (i wish
    /// i could force you to somehow but i didn't find a way to do that).
    ///
    /// Overriding ToString also makes sense cause it will be used in the
    /// Settings form.
    /// </summary>
    abstract class GameEvent
    {
        /// <summary>
        /// Names of optional attributes that a GameEvent can have.
        /// </summary>
        public abstract string[] AttributeNames { get; }
        /// <summary>
        /// Values of optional attributes that a GameEvent can have.
        /// </summary>
        public abstract string[] AttributeValues { get; }
        /// <summary>
        /// Description for this GameEvent that can be shown in dialogs.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Most important function for a GameEvent. This function has
        /// to decide whether the event occured, based on the info provided
        /// by a GameInfo objet.
        /// </summary>
        /// <param name="info">
        /// The GameInfo object that provides info about the game state.
        /// </param>
        /// <returns>
        /// <code>true</code> when the event happenen, <code>false</code>
        /// when it did not.
        /// </returns>
        public abstract bool HasOccured(GameInfo info);
    }

    /// <summary>
    /// Abstract GameEvent that does not have any attributes.
    /// </summary>
    abstract class NoAttributeEvent : GameEvent
    {
        public override string[] AttributeNames => null;
        public override string[] AttributeValues => null;
    }

    /// <summary>
    /// Abstract GameEvent that depends on a map of the game.
    /// </summary>
    abstract class MapEvent : GameEvent
    {
        /// <summary>
        /// A MapEvent depends on a map, so it has a matching attribute
        /// </summary>
        protected string[] attributeValues;
        public override string[] AttributeNames => new string[] { "Map" };
        public override string[] AttributeValues => attributeValues;

        /// <summary>
        /// The specific map that this MapEvent depends on.
        /// </summary>
        protected string map;

        /// <summary>
        /// Parameterless constructor for ChangeEventForm.
        /// </summary>
        public MapEvent()
        {
            map = "";
            attributeValues = new string[] { "" };
        }

        /// <summary>
        /// Creates a map event based on the given map.
        /// </summary>
        /// <param name="map">
        /// The name of the map to base this event on.
        /// </param>
        public MapEvent(string map)
        {
            this.map = map;
            attributeValues = new string[] { this.map };
        }
    }

    /// <summary>
    /// Provides an EmptyEvent, i.e. an event that never happens.
    /// </summary>
    class EmptyEvent : NoAttributeEvent
    {
        public override string Description => "No event";

        public override bool HasOccured(GameInfo info)
        {
            // empty event, never happens
            return false;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
