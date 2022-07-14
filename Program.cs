using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace HexaGone
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to rotate an actor on the screen.
    /// </remarks>
    internal class Program
    {
        private static int NUM_TRIANGLES = 3;

        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();
            
            // Create hexagon actor
            Actor hexagon = new Actor();
            hexagon.SizeTo(100, 100);
            hexagon.MoveTo(270, 190);
            hexagon.Tint(Color.Blue());

            // Create triangles
            for (int i = 0; i < NUM_TRIANGLES; i++) {
                Triangle triangle = new Triangle();
                triangle.SizeTo(25, 25);
                triangle.Tint(Color.Red());
                triangle.SetRandomEdgePosition();
            }


            // Instantiate the actions that use the actors.
            RotateActorAction rotateActorAction = new RotateActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);

            // Add them all within a new instance of Scene.
            Scene scene = new Scene();
            scene.AddActor("actors", hexagon);
            scene.AddAction(Phase.Input, rotateActorAction);
            scene.AddAction(Phase.Output, drawActorAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
