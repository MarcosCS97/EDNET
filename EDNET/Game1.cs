﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;
using System.Collections.Generic;

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
        Pieza piezaMuestra;
        KeyboardState previousState;
        Color colFondo = Color.Black;
        Color colBordes = Color.Blue;
        public int avance = 20;
        public int separac = 4;
        Marco juego, prediccion, jugar, pausar, salir, puntuacion;
        readonly Point posActual;
        readonly Point posMuestra;
        Random rnd=new Random();
        List<Rectangle> posados=new List<Rectangle>();
        readonly int colAncho=15;
        readonly int colAlto=40;




        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            juego = new Marco(new Point(200, 20), avance * colAncho, avance * colAlto, 10, colBordes, colFondo);
            jugar = new Marco(new Point(20, 20), 150, 40, 10, colBordes, colFondo);
            pausar = new Marco(new Point(20, 90), 150, 40, 10, colBordes, colFondo);
            salir = new Marco(new Point(20, 160), 150, 40, 10, colBordes, colFondo);
            prediccion= new Marco(new Point(20, 400), 150, 150, 10, colBordes, colFondo);
            puntuacion= new Marco(new Point(20, 730), 150, 90, 10, colBordes, colFondo);
            graphics.PreferredBackBufferHeight = juego.marco.Height+20;
            graphics.PreferredBackBufferWidth = juego.marco.Width+200;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            posActual=new Point(juego.contenedor.Location.X+(separac/2),juego.contenedor.Location.Y+(separac/2));
            posMuestra=new Point(prediccion.contenedor.Center.X-(avance*2),prediccion.contenedor.Center.Y-avance);
            
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
            piezaMuestra= randomPiece(posMuestra);
            piezaActual =randomPiece(posActual);
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

            if (keyboardState.IsKeyDown(Keys.Space)&& !previousState.IsKeyDown(Keys.Space)){
                piezaActual.rotaPieza();

                if(comprSal()){
                    piezaActual.restauraRotac();
                }
            }

            if (keyboardState.IsKeyDown(Keys.Left)&& !previousState.IsKeyDown(Keys.Left)){
                 piezaActual.mueveRect(Direccion.izq);

                if(comprSal()){
                    piezaActual.mueveRect(Direccion.der);
                }
            }
            if (keyboardState.IsKeyDown(Keys.Right)&& !previousState.IsKeyDown(Keys.Right)){
                 piezaActual.mueveRect(Direccion.der);

                if(comprSal()){
                    piezaActual.mueveRect(Direccion.izq);
                }
            }

            if (keyboardState.IsKeyDown(Keys.Down)){

                piezaActual.mueveRect();

                if(comprSal()){
                    piezaActual.mueveRect(Direccion.arriba);
                    fijarPieza();
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
            previousState = keyboardState;

        }


        private bool comprSal(){
            foreach(Rectangle rect in piezaActual.cuadrados){
                if(!juego.contenedor.Contains(rect)){
                    return true;
                }
                foreach(Rectangle rectangle in posados){
                    if(rect.Intersects(rectangle)){
                        return true;
                    }
                }
            }
            return false;
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
            /*foreach(Rectangle rect in piezaActual.cuadrados)
            {
                
                spriteBatch.Draw(whiteRectangle, rect, piezaActual.color);
            }*/
            drawPiece(piezaActual,spriteBatch);
            drawPiece(piezaMuestra,spriteBatch);
            foreach(Rectangle rect in posados){
                spriteBatch.Draw(whiteRectangle,rect, Color.Gray);
            }
            spriteBatch.End();
        }

        private void DrawMarco(Marco marco)
        {
            spriteBatch.Draw(whiteRectangle, marco.marco, marco.colBorde);
            spriteBatch.Draw(whiteRectangle, marco.contenedor, marco.colFondo);

        }

        private void drawPiece(Pieza pieza, SpriteBatch sp){
            foreach(Rectangle rect in pieza.cuadrados){
                sp.Draw(whiteRectangle,rect, pieza.color);
            }
        }

        private void fijarPieza(){
            foreach(Rectangle rect in piezaActual.cuadrados){
                posados.Add(rect);
            }
            filasLlenas();
            piezaActual=piezaMuestra;
            piezaActual.posic=posActual;
            piezaActual.rotac=1;
            piezaActual.creaPieza();
            piezaMuestra=randomPiece(posMuestra);
        }

        private void filasLlenas(){
            List<int> alturas=new List<int>();
            List<Rectangle> listaElim;
            int cont;

            foreach(Rectangle rect in posados){
                if(!alturas.Contains(rect.Y)) alturas.Add(rect.Y);
            }
            for(int i=alturas.Count-1; i>=0; i--){
                cont=0;
                foreach(Rectangle rect in posados){
                    if(rect.Y==alturas[i]) cont++;
                }
                if(cont>=colAncho){
                    listaElim=new List<Rectangle>();
                    for(int j=0; j<posados.Count; j++){
                        if(posados[j].Y==alturas[i]){
                            listaElim.Add(posados[j]);
                        }
                        if(posados[j].Y<alturas[i]) {
                            Rectangle placeholder=posados[j];
                            placeholder.Y +=avance;
                            posados[j]=placeholder;
                        }
                    }
                    foreach(Rectangle rect in listaElim){
                        posados.Remove(rect);
                    }
                    
                }
            }
        }

        private Pieza randomPiece(Point pos){
            Pieza[] piezas= new Pieza[7]{new PiezaI(pos,separac,avance,graphics),
                                            new PiezaJ(pos,separac,avance,graphics),
                                            new PiezaL(pos,separac,avance,graphics),
                                            new PiezaO(pos,separac,avance,graphics),
                                            new PiezaS(pos,separac,avance,graphics),
                                            new PiezaT(pos,separac,avance,graphics),
                                            new PiezaZ(pos,separac,avance,graphics)};
           return piezas[rnd.Next(7)];
        }
    }
}
