using System;
using System.Linq;
using System.Text;
 
public class Test
{
	public static void Main()
	{
		//http://www.geeksforgeeks.org/validity-of-a-given-tic-tac-toe-board-configuration/
		var board =  new Board();
		board.InitBoard();
 
        Console.WriteLine($"{board.ToString()}");
        Console.WriteLine($"Is given board valid: {board.IsValid().ToString()}");
	}
}
 
public class Board
{
	char[] boardArray;
 
	int xCount;
	int oCount;
 
	int[,] winingPos;
 
	public void InitBoard()
	{
		boardArray = new char[]{ 
								   'X', 'X', 'O',
				                   'O', 'O', 'X',
				                   'X', 'O', 'X'
				                };
		// Count number of 'X' and 'O' in the given board		                
		xCount = boardArray.ToList().Where(x => x.Equals('X')).Count();
		oCount = boardArray.ToList().Where(x => x.Equals('O')).Count();
 
		// This matrix is used to find indexes to check all
		// possible wining triplets in board[0..8]
		winingPos = new int[,] {
									{0,1,2},
									{3,4,5},
									{6,7,8},
									{0,3,6},
									{1,4,7},
									{2,5,8},
									{0,4,8},
									{2,4,6}
								};						
		}
 
	// Returns true if character ch wins. ch can be either 'X' or 'O'
	private bool IsWon(char ch)
	{
		for(int i=0;i < 8;i++)
		{
			if(boardArray[winingPos[i,0]] == ch &&
			boardArray[winingPos[i,1]] == ch &&
			boardArray[winingPos[i,2]] == ch)
				return true;
			else
				return false;
		}
		return false;
	}
	public bool IsValid()
	{
		//NOTE:  The game starts with X
 
		// Board can be valid only if either xCount and oCount
    	// is same or xount is one more than oCount
		if(xCount == oCount || xCount == oCount + 1)
		{
			// Check if 'O' is winner
			if(IsWon('O'))
			{
				// Check if 'X' is also winner, then
            	// return false
				if(IsWon('X')) return false;
 
				  // Else return true xCount and oCount are same
				return xCount == oCount;
			}
			// If 'X' wins, then count of X must be greater
			else if(IsWon('X') && xCount == oCount + 1)
			{
				return true;
			}
 
			return true;
		}
 
		return false;
	}
 
	public override string ToString()
	{
		var str = new StringBuilder(); 
		for(int i=0;i<boardArray.Length;i++)
		{
			if(i> 0 && i%3==0)
				str.AppendLine();
			str.AppendFormat($" {boardArray[i]} ");
		}
		return str.ToString();
	}
}