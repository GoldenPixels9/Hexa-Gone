using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using System.Collections.Generic;

namespace HexaGone
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
                List<Actor> actors = new List<Actor>();
                actors = scene.GetAllActors("actors");
                Actor player = scene.GetFirstActor("actors");

                
                foreach (Actor actor in actors)
                {
                    double ax = actor.GetCenterX();
                    double ay = actor.GetCenterY();
                    double px = player.GetCenterX();
                    double py = player.GetCenterY();

                    double xDifference = Math.Abs(px - ax);
                    double yDifference = Math.Abs(py - ay);

                    if (xDifference < 100 && yDifference < 100 && player != actor)
                    {
                        player.Tint(Color.White());
                        break;
                        
                    } 
                    else 
                    {
                        player.Tint(Color.Blue());
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