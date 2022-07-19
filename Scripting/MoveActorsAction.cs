using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using System.Collections.Generic;


namespace HexaGone
{
    /// <summary>
    /// Moves the actors and wraps them around the screen boundaries. Note, this is different from
    /// steering them which only changes their direction. The call to actor.Move() is what updates
    /// their position on the screen.
    /// </summary>
    public class MoveActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public MoveActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {


                // get the actors from the scene
                //Actor actor = scene.GetFirstActor("actors");
                Actor screen = scene.GetFirstActor("screen");
                List<Actor> actors = new List<Actor>();
                actors = scene.GetAllActors("actors");
                Actor player = scene.GetFirstActor("actors");
                
                // move the actor and wrap it around the screen boundaries
                //actor.Move();
                //actor.WrapIn(screen);
                
                Random rand = new Random();
                
                foreach (Actor actor in actors)
                {
                    if (actor != player)
                    {
                        actor.Rotate(8);
                        actor.Move();
                        actor.WrapIn(screen);
                        player.Move();
                        player.WrapIn(screen);
                    }
                }

            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }
    }
}