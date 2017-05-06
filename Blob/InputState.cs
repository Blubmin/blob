using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;

namespace Blob {
    public static class InputState {

        private static KeyboardState OldState { get; set; }
        private static KeyboardState NewState { get; set; }

        public static void Init() {
            OldState = Keyboard.GetState();
            NewState = OldState;
        }

        public static void Update() {
            OldState = NewState;
            NewState = Keyboard.GetState();
        }

        public static KeyState GetState(Keys key) {
            if (OldState.IsKeyDown(key)) {
                if (NewState.IsKeyDown(key))
                    return KeyState.Down;
                else
                    return KeyState.Released;
            }
            else {
                if (NewState.IsKeyDown(key))
                    return KeyState.Pressed;
                else
                    return KeyState.Up;
            }
        }

        private static bool IsState(Keys key, KeyState state) {
            return IsState(new Keys[] { key }, state);
        }

        private static bool IsState(Keys[] keys, KeyState state) {
            return IsStates(keys, new KeyState[] { state });
        }

        private static bool IsStates(Keys[] keys, KeyState[] states) {
            var keyStates = keys.Select(key => GetState(key));
            return keyStates.Aggregate(false, (ret, s) => ret || states.Contains(s));
        }

        public static bool IsDown(Keys key) {
            return IsState(key, KeyState.Down);
        }

        public static bool IsDown(Keys[] keys) {
            return IsState(keys, KeyState.Down);
        }

        public static bool IsUp(Keys key) {
            return IsState(key, KeyState.Up);
        }

        public static bool IsUp(Keys[] keys) {
            return IsState(keys, KeyState.Up);
        }

        public static bool IsPressed(Keys key) {
            return IsState(key, KeyState.Pressed);
        }

        public static bool IsPressed(Keys[] keys) {
            return IsState(keys, KeyState.Pressed);
        }

        public static bool IsReleased(Keys key) {
            return IsState(key, KeyState.Released);
        }

        public static bool IsReleased(Keys[] keys) {
            return IsState(keys, KeyState.Released);
        }

        public static bool IsPressedDown(Keys key) {
            return IsStates(new Keys[] { key }, new KeyState[] { KeyState.Pressed, KeyState.Down });
        }

        public static bool IsPressedDown(Keys[] keys) {
            return IsStates(keys, new KeyState[] { KeyState.Pressed, KeyState.Down });
        }

        public static bool IsReleasedUp(Keys key) {
            return IsStates(new Keys[] { key }, new KeyState[] { KeyState.Released, KeyState.Up });
        }

        public static bool IsReleasedUp(Keys[] keys) {
            return IsStates(keys, new KeyState[] { KeyState.Released, KeyState.Up });
        }
    }

    public enum KeyState {
        Down,
        Up,
        Pressed,
        Released
    }
}
