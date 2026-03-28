using System.Diagnostics;

class program
{
    static void Main(string[] args)
    {
        int x = 80;
        int y = 40;
        int id = 0;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        Console.CursorVisible = false;
        Console.SetWindowSize(x, y);
        Console.SetBufferSize(x, y);
        int position = 1;
        int endposition = 0;
        while (true)
        {
            switch (position)
            {
                case 1:
                    Console.Clear();
                    Console.SetCursorPosition(x/2-4, 4);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("三国杀");
                    Console.SetCursorPosition(x / 2 - 4, 8);
                    if(id == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.White;
                    }
                    Console.WriteLine("start");
                    Console.SetCursorPosition(x / 2 - 4, 10);
                    if (id == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("exit");
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            if (id == 1)
                            {
                                id--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (id == 0)
                            {
                                id++;
                            }
                            break;
                        case ConsoleKey.J:
                            if(id == 1)
                            {
                                Console.Clear();
                                Environment.Exit(0);
                            }else if (id == 0)
                            {
                                position++;
                            }
                            break;
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.ForegroundColor=ConsoleColor.Red;
                    for (int i = 0; i <= x-2 ; i = i + 2)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("■");
                        Console.SetCursorPosition(i, y - 1);
                        Console.Write("■");
                        Console.SetCursorPosition(i, y - 8);
                        Console.Write("■");
                    }        
                    for (int i = 0; i <= y - 1; i = i + 1)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.Write("■");
                        Console.SetCursorPosition(x - 2, i);
                        Console.Write("■");
                    }
                    int bossx = 24;
                    int bossy = 8;
                    Random random = new Random();
                    int bossATK=0;
                    int bossHp = 100;
                    string bossshape = "■";
                    ConsoleColor bossColor = ConsoleColor.Green;
                    #region player attributes
                    int playerx = 8;
                    int playery = 6;
                    int playerHp = 60;
                    int playerATK=0;
                    string playershape = "■";
                    ConsoleColor playerColor = ConsoleColor.Yellow;
                    #endregion
                    #region gongzhu attributes
                    int gongzhux = 16;
                    int gongzhuy = 15;
                    string gongzhushape = "■";
                    ConsoleColor gongzhuColor = ConsoleColor.Blue;
                    #endregion
                    bool battleEnd = false;
                    while (!battleEnd)
                    {
                        if (bossHp > 0)
                        {
                            Console.SetCursorPosition(bossx, bossy);
                            Console.ForegroundColor = bossColor;
                            Console.Write(bossshape);
                        }
                        else
                        {
                            Console.SetCursorPosition(gongzhux, gongzhuy);
                            Console.ForegroundColor = gongzhuColor;
                            Console.Write(gongzhushape);
                        }
                        #region player moving
                        if (playerHp > 0)
                        {
                            Console.SetCursorPosition(playerx, playery);
                            Console.ForegroundColor = playerColor;
                            Console.Write(playershape);
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            Console.SetCursorPosition(playerx, playery);
                            Console.Write(" ");
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.W:
                                    playery--;
                                    if (playery == 0)
                                    {
                                        playery = 1;
                                    }
                                    else if (bossHp > 0 && playerx == bossx && playery == bossy)
                                    {
                                        playery++;
                                    }
                                    else if(bossHp < 0 && playerx == gongzhux && playery == gongzhuy)
                                    {
                                        playery++;
                                    }
                                    break;
                                case ConsoleKey.S:
                                    playery++;
                                    if (playery >= y - 8)
                                    {
                                        playery = y - 9;
                                    }
                                    else if (bossHp > 0 && playerx == bossx && playery == bossy)
                                    {
                                        playery--;
                                    }
                                    else if (bossHp < 0 && playerx == gongzhux && playery == gongzhuy)
                                    {
                                        playery--;
                                    }
                                        break;
                                case ConsoleKey.D:
                                    playerx++;
                                    if (playerx >= x-2 )
                                    {
                                        playerx = x - 4;
                                    }
                                    else if (bossHp > 0 && playerx == bossx && playery == bossy)
                                    {
                                        playerx--;
                                    }
                                    else if (bossHp < 0 && playerx == gongzhux && playery == gongzhuy)
                                    {
                                        playerx--;
                                    }
                                    break;
                                case ConsoleKey.A:
                                    playerx--;
                                    if (playerx < 1)
                                    {
                                        playerx = 1;
                                    }
                                    else if (bossHp > 0 && playerx == bossx && playery == bossy)
                                    {
                                        playerx++;
                                    }
                                    else if (bossHp < 0 && playerx == gongzhux && playery == gongzhuy)
                                    {
                                        playerx++;
                                    }
                                    break;
                                case ConsoleKey.K:
                                    if((playerx==bossx&&playery==bossy-1||
                                       playerx==bossx&&playery==bossy+1||
                                       playery==bossy&&playerx==bossx-1||
                                       playery == bossy && playerx == bossx + 1) && bossHp > 0)
                                    {
                                        Console.SetCursorPosition(1, y - 7);
                                        Console.Write("The battle has begun.");
                                        bossATK = random.Next(8, 13);
                                        playerATK = random.Next(12, 21);
                                        bossHp = bossHp - playerATK;
                                        if (bossHp > 0)
                                        {
                                            Console.SetCursorPosition(1, y - 6);
                                            Console.Write("You dealt {0} points of damage to the Boss.The Boss still has {1} points of HP.", playerATK, bossHp);
                                            playerHp = playerHp - bossATK;
                                            if (playerHp > 0)
                                            {
                                                Console.SetCursorPosition(1, y - 5);
                                                Console.Write("BOSS dealt {0} points of damage to you.You still has {1} points of HP.", bossATK, playerHp);
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(1, y - 7);
                                                Console.Write("                                                                             ");
                                                Console.SetCursorPosition(1, y - 6);
                                                Console.Write("                                                                             ");
                                                Console.SetCursorPosition(1, y - 5);
                                                Console.Write("                                                                             ");
                                                Console.SetCursorPosition(bossx, bossy);
                                                Console.WriteLine("  ");
                                                Console.SetCursorPosition(1, y - 7);
                                                Console.Write("You are loser");
                                                position--;
                                                Console.SetCursorPosition(x/2-10, y - 25);
                                                Console.Write("Press any key to return");
                                                Console.ReadKey(true);
                                                battleEnd = true;
                                            }
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(bossx, bossy);
                                            Console.Write(' ');
                                            Console.SetCursorPosition(1, y - 7);
                                            Console.Write("                                                                             ");
                                            Console.SetCursorPosition(1, y - 6);
                                            Console.Write("                                                                             ");
                                            Console.SetCursorPosition(1, y - 5);
                                            Console.Write("                                                                             ");
                                            Console.SetCursorPosition(1, y - 7);
                                            Console.Write("You are winner");
                                        }
                                    }
                                    if((playerx == gongzhux && playery == gongzhuy - 1 ||
                                       playerx == gongzhux && playery == gongzhuy + 1 ||
                                       playery == gongzhuy && playerx == gongzhux - 1 ||
                                       playery == gongzhuy && playerx == gongzhux + 1) && bossHp < 0)
                                    {
                                        Console.SetCursorPosition(1, y - 7);
                                        Console.Write("You saved the princess.");
                                        position++;
                                        battleEnd = true;
                                    }
                                    break;
                            }
                        }
                        #endregion
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.SetCursorPosition(x / 2 - 4, 8);
                    if (endposition == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("go back to the home page");
                    Console.SetCursorPosition(x / 2 - 4, 10);
                    if (endposition == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("exit the game");
                    ConsoleKeyInfo k = Console.ReadKey(true);
                    switch (k.Key)
                    {
                        case ConsoleKey.W:
                            if (endposition == 1)
                            {
                                endposition--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (endposition == 0)
                            {
                                endposition++;
                            }
                            break;
                        case ConsoleKey.J:
                            if (endposition == 1)
                            {
                                Console.Clear();
                                Environment.Exit(0);
                            }
                            else if (endposition == 0)
                            {
                                position=1;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}