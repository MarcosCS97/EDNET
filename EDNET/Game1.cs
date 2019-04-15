using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EDNET
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D whiteRectangle;
        Pieza piezaActual;
        KeyboardState previousState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            previousState = Keyboard.GetState();
            piezaActual = new PiezaZ(2, 10, graphics);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            spriteBatch.Dispose();

            whiteRectangle.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Space)&& !previousState.IsKeyDown(Keys.Space)) piezaActual.rotaPieza();
            if (keyboardState.IsKeyDown(Keys.Left)&& !previousState.IsKeyDown(Keys.Left)) piezaActual.mueveRect(Direccion.izq);
            if (keyboardState.IsKeyDown(Keys.Right)&& !previousState.IsKeyDown(Keys.Right)) piezaActual.mueveRect(Direccion.der);
            if (keyboardState.IsKeyDown(Keys.Down)) piezaActual.mueveRect();

            // TODO: Add your update logic here

            base.Update(gameTime);
            previousState = keyboardState;

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();
            foreach(Rectangle rect in piezaActual.cuadrados)
            {

                spriteBatch.Draw(whiteRectangle, rect, piezaActual.color);
            }
            spriteBatch.End();
        }
    }
}
