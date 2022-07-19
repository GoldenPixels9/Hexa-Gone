using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace HexaGone
{
    /// <summary>
    /// Rotates an actor left or right based on keyboard input.
    /// </summary>
    public class RotateActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public RotateActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actor from the cast
                Actor actor = scene.GetFirstActor("actors");

                // rotate left or right based on key pressed
                if (_keyboardService.IsKeyDown(KeyboardKey.Q))
                {
                    actor.Rotate(-5);
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.E))
                {
                    actor.Rotate(5);
                }

            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't rotate actor.", exception);
            }
        }
    }
}