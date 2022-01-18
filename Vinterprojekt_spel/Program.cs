using System;
using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "BEST GAME");
Raylib.SetTargetFPS(60);

int points = 0;
bool pointTaken = false;    
float speed = 3f;

Texture2D playerImage = Raylib.LoadTexture("bobo.png");

Rectangle playerRect = new Rectangle(30, 10, playerImage.width, playerImage.height);
Rectangle pointRect = new Rectangle(200, 500, 16, 16);


string level = "start";

    while(!Raylib.WindowShouldClose())
    {
        if(level == "start")
        {
            Vector2 movement = ReadMovement(speed);

            playerRect.x += movement.X;
            playerRect.y += movement.Y;

            if(playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
            {
                playerRect.x -= movement.X;
            }
            if(playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
            {
                 playerRect.y -= movement.Y;
            }
        }

        if(level == "start")
        {
            if(Raylib.CheckCollisionRecs(playerRect, pointRect) && pointTaken == false)
            {
                points = +1;
                pointTaken = true;
            }
        }

        Raylib.BeginDrawing();

        if(level == "start")
        {
            Raylib.ClearBackground(Color.WHITE);
            if(pointTaken == false)
            {
            Raylib.DrawRectangleRec(pointRect, Color.GOLD);
            }
        }

        else if(level == "end")
        {
            Raylib.ClearBackground(Color.BLACK);
        }

        if(level == "start")
        {
            Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
            Raylib.DrawText(points.ToString(), 10, 10, 20, Color.BLACK);
        }

        Raylib.EndDrawing();

        static Vector2 ReadMovement(float speed)
        {
            Vector2 movement = new Vector2();
            if(Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
            if(Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
            if(Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
            if(Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;

            return movement;
        }
    }