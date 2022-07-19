using System;
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
        private static int NUM_TRIANGLES = 6;

        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();
            Scene scene = new Scene();

            Actor screen = new Actor();
            screen.SizeTo(800, 800);
            scene.AddActor("screen", screen);
            
            // Create hexagon actor
            Actor hexagon = new Actor();
            hexagon.SizeTo(100, 100);
            hexagon.MoveTo(270, 190);
            hexagon.Tint(Color.Blue());
            scene.AddActor("actors", hexagon);

            // Create attacking squares
            for (int i=0; i <= NUM_TRIANGLES; i++)
            {
                Random rand = new Random();
                int randx = rand.Next(-5, 5);
                int randy = rand.Next(-5, 5);

                Actor attacker = new Actor();
                attacker.SizeTo(25, 25);
                //randomPosition = attacker.GetRandomEdgePosition();
                //attacker.MoveTo(randomPosition);
                attacker.GetRandomEdgePosition();
                attacker.Steer(randx, randy);
                attacker.Tint(Color.Red());
                scene.AddActor("actors", attacker);
            }

            // Instantiate the actions that use the actors.
            SteerActorsAction steerActorsAction = new SteerActorsAction(serviceFactory);
            RotateActorAction rotateActorAction = new RotateActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);
            CollideActorsAction collideActorsAction = new CollideActorsAction(serviceFactory);
            MoveActorsAction moveActorsAction = new MoveActorsAction(serviceFactory);

            // Add them all within a new instance of Scene.
            scene.AddAction(Phase.Output, steerActorsAction);
            scene.AddAction(Phase.Input, rotateActorAction);
            scene.AddAction(Phase.Input, collideActorsAction);
            scene.AddAction(Phase.Input, moveActorsAction);
            scene.AddAction(Phase.Output, drawActorAction);
            

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
