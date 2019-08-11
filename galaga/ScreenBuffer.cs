using System;
using System.Collections.Generic;
using System.Text;
using static Gallag.Program;

namespace Gallag
{
    public class ScreenBuffer
    {
        //initiate important variables
        public static char[,] screenBufferArray = new char[roomWidth, roomHeight]; //main buffer array
        public static string screenBuffer; //buffer as string (used when drawing)
        public static Char[] arr; //temporary array for drawing string
        public static int i = 0; //keeps track of the place in the array to draw to

        //this method takes a string, and a pair of coordinates and writes it to the buffer
        public static void Draw(string text, int x, int y)
        {
            //split text into array
            arr = text.ToCharArray(0, text.Length);
            //iterate through the array, adding values to buffer 
            i = 0;
            foreach (char c in arr)
            {
                screenBufferArray[x + i, y] = c;
                i++;
            }
        }

        public static void DrawScreen()
        {
            screenBuffer = "";
            //iterate through buffer, adding each value to screenBuffer
            for (int iy = 0; iy < roomHeight - 1; iy++)
            {
                for (int ix = 0; ix < roomWidth; ix++)
                {
                    screenBuffer += screenBufferArray[ix, iy];
                }
            }
            //set cursor position to top left and draw the string
            Console.SetCursorPosition(0, 0);
            Console.Write(screenBuffer);
            screenBufferArray = new char[roomWidth, roomHeight];
            //note that the screen is NOT cleared at any point as this will simply overwrite the existing values on screen. Clearing will cause flickering again.
        }

    }
}
