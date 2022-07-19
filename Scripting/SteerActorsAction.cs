using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace HexaGone
{
    /// <summary>
    /// Steers an actor in a direction corresponding to keyboard input. Note, this does not update 
    /// the actor's position, just steers it in a certain direction. See MoveActorAction to see how
    /// the actor's position is actually updated.
    /// </summary>
    public class SteerActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public SteerActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // declare direction variables
                int directionX = 0;
                int directionY = 0;

                // determine vertical or y-axis direction
                if (_keyboardService.IsKeyDown(KeyboardKey.Up) || _keyboardService.IsKeyDown(KeyboardKey.W))
                {
                    directionY = -1;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.Down)|| _keyboardService.IsKeyDown(KeyboardKey.S))
                {
                    directionY = 1;
                }

                // determine horizontal or x-axis direction
                if (_keyboardService.IsKeyDown(KeyboardKey.Left)|| _keyboardService.IsKeyDown(KeyboardKey.A))
                {
                    directionX = -1;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.Right)|| _keyboardService.IsKeyDown(KeyboardKey.D))
                {
                    directionX = 1;
                }


                

                // steer the actor in the desired direction
                Actor actor = scene.GetFirstActor("actors");
                actor.Steer(directionX, directionY);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't steer actor.", exception);
            }
        }
    }
}