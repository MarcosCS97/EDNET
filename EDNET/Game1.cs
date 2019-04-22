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
        Color colFondo = Color.Black;
        Color colBordes = Color.Blue;
        public int avance = 20;
        public int separac = 4;
        Marco juego, prediccion, jugar, pausar, salir, puntuacion;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            juego = new Marco(new Point(200, 20), avance * 15, avance * 40, 10, colBordes, colFondo);
            jugar = new Marco(new Point(20, 20), 150, 40, 10, colBordes, colFondo);
            pausar = new Marco(new Point(20, 90), 150, 40, 10, colBordes, colFondo);
            salir = new Marco(new Point(20, 160), 150, 40, 10, colBordes, colFondo);
            prediccion= new Marco(new Point(20, 400), 150, 150, 10, colBordes, colFondo);
            puntuacion= new Marco(new Point(20, 730), 150, 90, 10, colBordes, colFondo);
            graphics.PreferredBackBufferHeight = juego.marco.Height+20;
            graphics.PreferredBackBufferWidth = juego.marco.Width+200;
            graphics.ApplyChanges();
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
            piezaActual = new PiezaT(new Point(juego.contenedor.Location.X+(separac/2),juego.contenedor.Location.Y+(separac/2)), separac, avance, graphics);

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
            GraphicsDevice.Clear(colFondo);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();
            DrawMarco(juego);
            DrawMarco(jugar);
            DrawMarco(pausar);
            DrawMarco(salir);
            DrawMarco(prediccion);
            DrawMarco(puntuacion);
            foreach(Rectangle rect in piezaActual.cuadrados)
            {
                
                spriteBatch.Draw(whiteRectangle, rect, piezaActual.color);
            }
            spriteBatch.End();
        }

        private void DrawMarco(Marco marco)
        {
            spriteBatch.Draw(whiteRectangle, marco.marco, marco.colBorde);
            spriteBatch.Draw(whiteRectangle, marco.contenedor, marco.colFondo);

        }
    }
}
