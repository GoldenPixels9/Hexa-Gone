using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace HexaGone
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawActorAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                List<Actor> actors = new List<Actor>();
                actors = scene.GetAllActors("actors");
                
                // draw the actors on the screen using the video service
                _videoService.ClearBuffer();
                foreach (Actor actor in actors)
                {
                    _videoService.Draw(actor);
                }
/*                 _videoService.Draw(actor);
                _videoService.Draw(attacker); */
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }
    }
}