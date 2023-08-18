using System.Collections.Generic;
using System.Linq;

namespace GenericEventSystem {
    public class EventName {
        //A few example event names. We arrange them in classes for convenience and make a Get() function to export into lists.
        //String names that are returned must be unique, therefore a good convention is to attach a prefix of it's class for easier debugging.
        public class UI {
            public static string ShowScoreScreen() { return "UI_ShowScoreScreen"; }
            public static string ScoreScreenShown() { return "UI_ScoreScreenShown"; }
            public static List<string> Get() { return new List<string> { ShowScoreScreen(), ScoreScreenShown() }; }
        }

        public class Network {
            public static string PlayerJoined() { return "Network_PlayerJoined"; }
            public static string PlayerLeft() { return "Network_PlayerLeft"; }
            public static List<string> Get() { return new List<string> { PlayerJoined(), PlayerLeft() }; }
        }
        //this shows how message names can be nested for convenience into types
        public class Input {
            public class Menus {
                public static string ShowSettings() { return "Input_Menus_ShowSettings"; }
                public static string None() { return null; }
                public static List<string> Get() { return new List<string> { ShowSettings(), None() }; }
            }
            public static string PlayersReady() { return "Input_PlayersReady"; }
            //nesting can be done indefinitely but Get() function must get it's depth as well as follows:
            public static List<string> Get() {
                return new List<string> {
                        PlayersReady(),
                    }.Concat(Menus.Get())
                    .Concat(Network.Get())
                    .ToList();
            }
        }
        //Some examples what other classes could be used to better arrange messaging into
        public class Editor {
            public static string None() { return null; }
            public static List<string> Get() { return new List<string> { None() }; }
        }
        public class AI {
            public static string None() { return null; }
            public static List<string> Get() { return new List<string> { None() }; }
        }
        //This master Get() function returns all of the messages, thus enabling things like Editor extensions, i.e. the list picker/selector.
        public static List<string> Get() {
            return new List<string> {}.Concat(UI.Get())
                .Concat(Editor.Get())
                .Concat(Input.Get())
                .Concat(AI.Get())
                .Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
        }
    }
}