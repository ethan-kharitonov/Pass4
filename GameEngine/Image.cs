//Author: Trevor Lane
//File Name: Image.cs
//Project Name: CSGameEngine
//Creation Date: Nov. 15, 2020
//Modified Date: Nov. 23, 2020
//Description:  This class represents the image data to be used in various game objects

using System;
/**
* <h3>A basic object to hold visual game object data</h3>
* <b>Creation Date:</b> Nov 15, 2020<br>
* <b>Modified Date:</b> Nov 23, 2020
* <p>
* These Image objects may be reused in multiple game object variables
* 
* @author Trevor Lane
* @version 1.0
*/
public class Image
{
    public char[,] Grid { get; set; }
    public ColourSet[,] ColourGrid { get; set; }

    /**
    * <b><i>Image</b></i>
    * <p>
    * {@code public Image(char[,] grid, String[,]colourGrid)}<br>
    * <p>
    * Create an Image object to store the visuals of a game object
    * 
    * @param grid   The grid of characters representing the visuals of the game object
    * @param colourGrid  The grid of colours representing the visuals of the game object
    */
    public Image(char[,] grid, ColourSet[,] colourGrid)
    {
        this.Grid = new char[grid.GetLength(0), grid.GetLength(1)];
        this.ColourGrid = new ColourSet[colourGrid.GetLength(0), colourGrid.GetLength(1)];

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                this.Grid[i, j] = grid[i, j];
                this.ColourGrid[i, j] = colourGrid[i, j];
            }
        }
    }

    /**
    * <b><i>Image</b></i>
    * <p>
    * {@code public Image()}<br>
    * <p>
    * Create a generic Image object to store the visuals of a game object after a failed file load
    */
    public Image()
    {
        Grid = new char[,]
        {
        {'B','A','D'},
        {'I','M','G'},
        };

        ColourGrid = new ColourSet[,]
        {
        {new ColourSet(Helper.bgCol, Helper.RED),new ColourSet(Helper.bgCol, Helper.RED),new ColourSet(Helper.bgCol, Helper.RED)},
        {new ColourSet(Helper.bgCol, Helper.RED),new ColourSet(Helper.bgCol, Helper.RED),new ColourSet(Helper.bgCol, Helper.RED)}
        };
    }

    public void UpdateGrid(int row, int col, char ch, ConsoleColor textColour, ConsoleColor bgColour)
    {
        if (row < Height && col < Width)
        {
            Grid[row, col] = ch;
            ColourGrid[row, col].SetFG(textColour);
            ColourGrid[row, col].SetBG(bgColour);
        }
    }

    /**
     * <b><i>GetGrid</b></i>
     * <p>
     * {@code public char[,] GetGrid()}
     * <p>
     * Retrieve the character data of the object in a 2D grid
     * 
     * @return The character data of the object
     */

    /**
     * <b><i>GetColourGrid</b></i>
     * <p>
     * {@code public ColourSet[,] GetColourGrid()}
     * <p>
     * Retrieve the colour data of the object in a 2D grid
     * 
     * @return The colour data of the object
     */

    public int Width => Grid.GetLength(1);

    public int Height => Grid.GetLength(0);

    public ColourSet[,] GetColourGridCopy()
    {
        ColourSet[,] colGrid = new ColourSet[Height, Width];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                colGrid[i, j] = new ColourSet(ColourGrid[i, j].GetBG(), ColourGrid[i, j].GetFG());
            }
        }

        return colGrid;
    }

    public void OverlayColors(ConsoleColor bgCol, ConsoleColor fgCol, bool keepTransparencies)
    {
        for (int row = 0; row < Grid.GetLength(0); row++)
        {
            for (int col = 0; col < Grid.GetLength(1); col++)
            {
                if (!keepTransparencies || !ColourGrid[row, col].IsTransparent())
                {
                    ColourGrid[row, col].SetFG(fgCol);
                    ColourGrid[row, col].SetBG(bgCol);
                }
            }
        }
    }

    public ConsoleColor GetFGColour(int row, int col)
    {
        if (row < Height && col < Width)
        {
            return ColourGrid[row, col].GetFG();
        }
        return Helper.fgCol;
    }

    public ConsoleColor GetBGColour(int row, int col)
    {
        if (row < Height && col < Width)
        {
            return ColourGrid[row, col].GetBG();
        }
        return Helper.bgCol;
    }
}