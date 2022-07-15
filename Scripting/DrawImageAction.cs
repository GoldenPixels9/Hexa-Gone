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
    public class DrawImageAction : Byui.Games.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawImageAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                List<Image> triangles = scene.GetAllActors<Image>("triangles");

                // draw the actors on the screen using the video service
                _videoService.ClearBuffer();
                _videoService.Draw(triangles);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw triangles.", exception);
            }
        }
    }
}