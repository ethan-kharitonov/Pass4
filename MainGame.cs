using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pass4
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static int Width = 900;
        public static int Height = 500;

        TextInputEventArgs input = new TextInputEventArgs();
        enum GamePlayStage
        {
            Input,
            Run
        }

        GamePlayStage gamePlayStage = GamePlayStage.Input;
        string inputString = "";

        GameObject[,] level = new GameObject[20, 9];

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;   
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            base.Draw(gameTime);
        }

        private void GetInput()
        {
            
            if (input.Key == Keys.Enter)
            {
                gamePlayStage = GamePlayStage.Run;
            }


            if (input.Key != Keys.None)
            {
                inputString += input.Character;
            }

            if (input.Key == Keys.Back)
            {
                if (inputString.Length < 2)
                {
                    inputString = "";
                }
                else
                {
                    inputString = inputString.Substring(0, inputString.Length - 1);
                }
            }
        }

        private void LoadLevelFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int col = 0; col < level.GetLength(0); ++col)
            {
                for (int row = 0; row < level.GetLength(1); ++row)
                {
                    switch (lines[row][col])
                    {
                        case '0':
                            player = new Player(col * ObjectWidth, row * ObjectHeight);
                            level[col, row] = player;
                            break;
                        case '1':
                            level[col, row] = new Wall(col * ObjectWidth, row * ObjectHeight);
                            break;
                        case '2':
                            //level[col, row] = new Crate(col * ObjectWidth, row * ObjectHeight);
                            break;
                    }
                }
            }

        }

    }
}
