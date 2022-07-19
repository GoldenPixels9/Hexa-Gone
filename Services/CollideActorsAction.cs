using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using System.Collections.Generic;

namespace Example.Colliding
{
    /// <summary>
    /// Detects and resolves collisions between actors.
    /// </summary>
    public class CollideActorsAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public CollideActorsAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                
                // detect a collision between the actors.
                // get the actors from the cast
                Actor player = scene.GetFirstActor("actors");
                List<Actor> actors = new List<Actor>();
                actors = scene.GetAllActors("actors");

                foreach (Actor actor in actors)
                {
                    if (actor.Overlaps(player))
                    {
                        player.Tint(Color.Blue());
                    } 
                    else 
                    {
                        player.Tint(Color.Red());
                    }
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't check if actors collide.", exception);
            }
        }
    }
}