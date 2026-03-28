using System;
using System.Security.Principal;

namespace Myproject
{
    enum GameState
    {
        Start,
        Gaming,
        End
    }

    struct Grid
    {
        public Grid_Type Type;
        public Position position;

        public Grid(Grid_Type type,int x,int y)
        {
            this.Type = type;
            position.x = x;
            position.y = y;
        }

        public void Draw_Grid()
        {
            Console.SetCursorPosition(position.x,position.y);
            switch (Type)
            {
                case Grid_Type.Normal:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("□");
                    break;
                case Grid_Type.boom:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("●");
                    break;
                case Grid_Type.pause:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("‖");
                    break;
                case Grid_Type.tunnel:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("¤");
                    break;
            }
        }
    }

    enum Grid_Type
    {
        Normal,
        boom,
        pause,
        tunnel
    }

    struct Position
    {
        public int x;
        public int y;

        public Position(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    enum Identity
    {
        participant,
        computer
    }

    struct Player
    {
        public Identity identity;
        public int index;

        public Player(Identity identity, int index)
        {
            this.identity = identity;
            this.index = index;
        }

        public void Draw(Map map)
        {
            Console.SetCursorPosition(map.grids[index].position.x, map.grids[index].position.y);
            switch(identity)
            {
                case Identity.participant:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("★");
                    break ;
                case Identity.computer:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("▲");
                    break ;
            }
        }
    }

    struct Map
    {
        public Grid[] grids;

        public Map(int x, int y,int num)
        {
            grids = new Grid[num];
            Random r= new Random();
            int randomnum;
            int row=0;
            int column=0;
            int sumx=0;
            int sumy = 1;
            for(int i = 0; i < num; i++)
            {
                randomnum = r.Next(0,101);
                if (randomnum <= 85 || i == 0 || i == num - 1)
                {
                    grids[i] = new Grid(Grid_Type.Normal, x, y);
                }else if(randomnum <= 90 && randomnum > 85)
                {
                    grids[i] = new Grid(Grid_Type.boom, x, y);
                }else if(randomnum <= 95 && randomnum > 90)
                {
                    grids[i] = new Grid(Grid_Type.pause, x, y);
                }
                else if (randomnum <= 100 && randomnum > 95)
                {
                    grids[i] = new Grid(Grid_Type.tunnel, x, y);
                }
                if (row%2 == 0 && column%2 == 0)
                {
                    if (sumx == 18)
                    {
                        row++;
                        column++;
                        y++;
                    }
                    else
                    {
                        x = x + 2;
                        sumx += 2;
                    }
                }else if(column % 2 == 1&&row % 2 == 1)
                {
                    if (sumy % 4 == 0)
                    {
                        column++;
                        x=x - 2;
                        sumy = 1;
                    }
                    else
                    {
                        y++;
                        sumy++;
                    }
                }
                else if(row % 2 == 1 && column % 2 == 0)
                {
                    if (sumx == 0)
                    {
                        row++;
                        column++;
                        y++;
                    }
                    else
                    {
                        x = x - 2;
                        sumx -= 2;
                    }
                }
                else if (column % 2 == 1 && row % 2 == 0)
                {
                    if (sumy % 4 == 0)
                    {
                        column++;
                        x = x + 2;
                        sumy = 1;
                    }
                    else
                    {
                        y++;
                        sumy++;
                    }
                }
            }
        }
        public void draw()
        {
            for (int i = 0;i<grids.Length;i++)
            {
                grids[i].Draw_Grid();
            }
        }
    }
    class program
    {
        static void StartMenu(int length, int position)
        {
            int start = 0;
            int end = 1;
            Console.Clear();
            Console.SetCursorPosition(length / 2-4, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flying chess");
            Console.SetCursorPosition(length / 2-4, 14);
            Console.ForegroundColor=(position==start) ? ConsoleColor.Yellow: ConsoleColor.White;
            Console.WriteLine("Start game");
            Console.SetCursorPosition(length / 2 - 4, 18);
            Console.ForegroundColor = (position == end) ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.WriteLine("Game over");
        }
        static void HandleStartInput(ref int position, ref GameState scenario)
        {
            int start = 0;
            int end = 1;
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.W:
                    if (position == end)
                    {
                        position--;
                    }
                    break;
                case ConsoleKey.S:
                    if (position == start)
                    {
                        position++;
                    }
                    break;
                case ConsoleKey.K:
                    if (position == start)
                    {
                        scenario=GameState.Gaming;
                    }
                    else if (position == end)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    break;
            }
        }
        static void runs_background(int length,int width)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            for (int i = 0; i < length-1; i++)
            {
                Console.SetCursorPosition(i,0);
                Console.Write("■");
                Console.SetCursorPosition(i, width / 2+  3);
                Console.Write("■");
                Console.SetCursorPosition(i, width / 2 + 8);
                Console.Write("■");
                Console.SetCursorPosition(i, width - 2);
                Console.Write("■");
            }
            for (int i = 0;i < width-1; i++)
            {
                Console.SetCursorPosition(0,i);
                Console.Write("■");
                Console.SetCursorPosition(length-1, i);
                Console.Write("■");
            }
            //文字信息
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, width / 2 + 4);
            Console.Write("□:普通格子");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(2, width / 2 + 5);
            Console.Write("‖:暂停，一回合不动");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(26, width / 2 + 5);
            Console.Write("●:炸弹，倒退5格");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(2, width / 2 + 6);
            Console.Write("¤:时空隧道，随机倒退，暂停，换位置");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(2, width / 2 + 7);
            Console.Write("★:玩家");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(12, width / 2 + 7);
            Console.Write("▲:电脑");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(22, width / 2 + 7);
            Console.Write("◎:玩家和电脑重合");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, width / 2 + 9);
            Console.WriteLine("Please press a key to start");
        }

        static void DrawPlayer(Map map,Player paticipant, Player computer)
        {
            if (paticipant.index == computer.index)
            {
                Grid grid = map.grids[paticipant.index];
                Console.SetCursorPosition(grid.position.x, grid.position.y);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("◎");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                paticipant.Draw(map);
                Console.ForegroundColor = ConsoleColor.Magenta;
                computer.Draw(map);
            }
        }

        static void GameRuns(Player paticipant, Player computer,Map map,int width, ref GameState scenario)
        {
            Random random = new Random();
            bool participantSkip = false;
            bool computerSkip = false;
            while (paticipant.index < map.grids.Length - 1&&computer.index< map.grids.Length - 1)
            {
                if (!participantSkip)
                {
                    Console.ReadKey(true);
                    int r = random.Next(1, 7);
                    map.grids[paticipant.index].Draw_Grid();
                    paticipant.index += r;
                    if (paticipant.index >= map.grids.Length - 1)
                    {
                        paticipant.index = map.grids.Length - 1;
                        Console.SetCursorPosition(2, width / 2 + 11);
                        Console.WriteLine("The participant wins the game       ");
                    }
                    if (map.grids[paticipant.index].Type == Grid_Type.boom)
                    {
                        boom(ref paticipant, map, width);
                    }
                    else if (map.grids[paticipant.index].Type == Grid_Type.pause)
                    {
                        participant_pause(ref participantSkip);
                    }else if (map.grids[paticipant.index].Type == Grid_Type.tunnel)
                    {
                        tunnel(ref paticipant, map, width);
                    }
                    DrawPlayer(map, paticipant, computer);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(2, width / 2 + 9);
                    Console.WriteLine("The paticipant moves {0}            ", r);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(40, width / 2 +11);
                    Console.WriteLine("Participant skips this round");
                    participantSkip = false;
                }
                if (!computerSkip)
                {
                    Console.ReadKey(true);
                    int r1 = random.Next(1, 7);
                    map.grids[computer.index].Draw_Grid();
                    computer.index += r1;
                    if (computer.index >= map.grids.Length - 1)
                    {
                        computer.index = map.grids.Length - 1;
                        Console.SetCursorPosition(3, width / 2 + 11);
                        Console.WriteLine("The computer wins the game         ");
                    }
                    if (map.grids[computer.index].Type == Grid_Type.boom)
                    {
                        boom(ref computer, map, width);
                    }
                    else if (map.grids[computer.index].Type == Grid_Type.pause)
                    {
                        computer_pause(ref computerSkip);
                    }
                    else if (map.grids[computer.index].Type == Grid_Type.tunnel)
                    {
                        tunnel(ref computer, map, width);
                    }
                    DrawPlayer(map, paticipant, computer);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(2, width / 2 + 10);
                    Console.WriteLine("The computer moves {0}", r1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(40, width / 2 + 12);
                    Console.WriteLine("Computer skips this round");
                    computerSkip = false;
                }
            }
            scenario = GameState.End;
        }

        static void participant_pause(ref bool participantSkip)
        {
            participantSkip = true;
        }

        static void computer_pause(ref bool computerSkip)
        {
            computerSkip = true;
        }

        static void boom(ref Player player, Map map,int width)
        {
            player.index -= 5;
            if (player.index < 0)
            {
                player.index = 0;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, width / 2 + 9);
            Console.WriteLine("The {0} touch the boom  ",player.identity);
        }

        static void tunnel(ref Player player,Map map, int width)
        {
            int tunnelCount = 0;
            for (int i = 0; i < map.grids.Length; i++)
            {
                if (map.grids[i].Type == Grid_Type.tunnel)
                {
                    tunnelCount++; 
                }
            }
            int[] ints = new int[tunnelCount];
            int num = 0;
            for(int i = 0; i < map.grids.Length; i++)
            {
                if (map.grids[i].Type == Grid_Type.tunnel)
                {
                    ints[num] = i;
                    num++;  
                }
            }
            for(int i = 0;i < ints.Length;i++)
            {
                if (player.index == ints[i]&&i!= ints.Length-1)
                {
                    player.index = ints[i+1];
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(2, width / 2 + 13);
                    Console.WriteLine("The {0} touch the tunnel{1} and is transfered to tunnel{2}", player.identity, ints[i], ints[i + 1]);
                    break;
                }
            }
        }

        static void HandleEndInput(ref int position, ref GameState scenario)
        {
            int start = 0;
            int end = 1;
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.W:
                    if (position == end)
                    {
                        position--;
                    }
                    break;
                case ConsoleKey.S:
                    if (position == start)
                    {
                        position++;
                    }
                    break;
                case ConsoleKey.K:
                    if (position == start)
                    {
                        scenario = GameState.Start;
                    }
                    else if (position == end)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    break;
            }
        }
        static void EndMenu(int length, int position)
        {
            int start = 0;
            int end = 1;
            Console.SetCursorPosition(length / 2 - 4, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game Over");
            Console.SetCursorPosition(length / 2 - 4, 14);
            Console.ForegroundColor = (position == start) ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.WriteLine("Return to the StartMenu");
            Console.SetCursorPosition(length / 2 - 4, 18);
            Console.ForegroundColor = (position == end) ? ConsoleColor.Yellow : ConsoleColor.White;
            Console.WriteLine("Exit the game");
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameState scenario = GameState.Start;
            bool IsGameOver = false;
            int length = 80;
            int width = 40;
            Console.SetWindowSize(length, width);
            Console.SetBufferSize(length, width);
            int begin_position = 0;
            int end_position = 0;
            while (!IsGameOver)
            {
                switch (scenario)
                {
                    case GameState.Start:
                        StartMenu(length, begin_position);
                        HandleStartInput(ref begin_position, ref scenario);
                        break;
                    case GameState.Gaming:
                        Console.Clear();
                        runs_background(length,width);
                        Map map = new Map(20,5,65);
                        map.draw();
                        Player paticipant = new Player(Identity.participant,0);
                        Player computer = new Player(Identity.computer, 0);
                        DrawPlayer(map, paticipant, computer);
                        GameRuns(paticipant, computer,map,width,ref scenario);
                        break;
                    case GameState.End:
                        Console.Clear();
                        EndMenu(length, end_position);
                        HandleEndInput(ref end_position, ref scenario);
                        break;
                }
            }
        }
    }
}
