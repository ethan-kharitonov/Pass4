//Author:
//FileName:
//Project Name:
//Creation Date:
//Modified Date:
//Description:

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGameEngine
{
    class MainClass : AbstractGame
    {
        enum GameState
        {
            Menu,
            Settings,
            Instructions,
            Gameplay,
            Pause,
            Endgame
        }

        enum Item
        {
            Wall,
            Crate,
            Goal,
            Door,
            Spikes,
            Gem,
            Key
        }

        enum GamePlayStage
        {
            Input,
            Run
        }

        private static int uiLocation = Helper.UI_BOTTOM;

        private static int uiSize = 6;

        private static int gameWidth = 80;

        private static int gameHeight = 18;

        GameState gameState = GameState.Gameplay;

        Image[] itemImgs = new Image[8];

        public static int ObjectHeight = 2;
        public static int ObjectWidth = 4;

        private UITextObject inputPrompt;
        private UITextObject input;


        private Body[,] level = new Body[gameWidth / ObjectWidth, gameHeight / ObjectHeight];
        private Player player;

        private GamePlayStage gamePlayStage = GamePlayStage.Input;
        private Queue<char> commands = new Queue<char>();

        static void Main(string[] args)
        {
            GameContainer gameContainer = new GameContainer(new MainClass(), uiLocation, uiSize, gameWidth, gameHeight);
            gameContainer.Start();


        }

        public override void LoadContent(GameContainer gc)
        {
            Body.gc = gc;
            itemImgs[(int)Item.Crate] = Helper.LoadImage("Images/Crate.txt");
            itemImgs[(int)Item.Door] = Helper.LoadImage("Images/Door.txt");
            itemImgs[(int)Item.Gem] = Helper.LoadImage("Images/Gem.txt");
            itemImgs[(int)Item.Goal] = Helper.LoadImage("Images/Goal.txt");
            itemImgs[(int)Item.Key] = Helper.LoadImage("Images/Key.txt");
            itemImgs[(int)Item.Spikes] = Helper.LoadImage("Images/Spikes.txt");

            LoadLevelFromFile(gc, "Map1.txt");

            inputPrompt = new UITextObject(gc, 1, 1, Helper.BLUE, true, "Enter: ");
            input = new UITextObject(gc, 1 + inputPrompt.Text.Length, 1, Helper.BLUE, true, "");

        }

        public override void Update(GameContainer gc, float deltaTime)
        {

            if (Input.IsKeyDown(ConsoleKey.Escape)) gc.Stop();

            switch (gameState)
            {
                case GameState.Menu:
                    break;
                case GameState.Settings:
                    break;
                case GameState.Instructions:
                    break;
                case GameState.Gameplay:
                    switch (gamePlayStage)
                    {
                        case GamePlayStage.Input:
                            GetInput();
                            break;

                        case GamePlayStage.Run:

                            for (int col = 0; col < level.GetLength(0); ++col)
                            {
                                for (int row = 0; row < level.GetLength(1); ++row)
                                {
                                    if (level[col, row] != null)
                                    {
                                        CheckCollisions(GetNeighbors(col, row), level[col, row]);
                                    }
                                }
                            }

                            player.Update(input.Text[0]);
                            break;
                    }

                    break;
                case GameState.Pause:
                    break;
                case GameState.Endgame:
                    break;
            }
        }

        private void GetInput()
        {
            if (Input.IsKeyDown(ConsoleKey.Enter))
            {
                gamePlayStage = GamePlayStage.Run;
            }

            if (Input.AnyKeysPressed)
            {
                input.UpdateText(input.Text + Input.LastKey.ToChar());
            }

            if (Input.IsKeyDown(ConsoleKey.Backspace))
            {
                if (input.Text.Length < 2)
                {
                    input.UpdateText("");
                }
                else
                {
                    input.UpdateText(input.Text.Substring(0, input.Text.Length - 2));
                }
            }
        }

        public override void Draw(GameContainer gc)
        {
            switch (gameState)
            {
                case GameState.Menu:
                    break;
                case GameState.Settings:
                    break;
                case GameState.Instructions:
                    break;
                case GameState.Gameplay:

                    foreach (GameObject gameObject in level)
                    {
                        if (gameObject != null)
                        {
                            gc.DrawToBackground(gameObject);
                        }
                    }

                    gc.DrawToUserInterface(inputPrompt);
                    gc.DrawToUserInterface(input);

                    break;
                case GameState.Pause:
                    break;
                case GameState.Endgame:
                    break;
            }
        }

        private void LoadLevelFromFile(GameContainer gc, string filePath)
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

        private IEnumerable<Body> GetNeighbors(int col, int row)
        {
            for (int c = col - 1; c <= col + 1; ++c)
            {
                for (int r = row - 1; r <= row + 1; ++r)
                {
                    if ((c == col && r == row) || !Helper.IsBetween(c, 0, level.GetLength(0) - 1) || !Helper.IsBetween(r, 0, level.GetLength(1) - 1))
                    {
                        continue;
                    }

                    yield return level[c, r];
                }
            }

        }

        private void CheckCollisions(IEnumerable<Body> neighbors, Body center)
        {
            foreach (Body neighbor in neighbors)
            {
                if (neighbor == null)
                {
                    continue;
                }

                if (Helper.FastIntersects(neighbor, center))
                {
                    center.InformCollisionTo(neighbor);
                }
            }
        }

    }
}
