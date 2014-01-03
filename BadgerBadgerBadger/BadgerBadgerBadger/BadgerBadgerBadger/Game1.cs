using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BadgerBadgerBadger
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Badger honey;
        EnemyManager enemies;
        Background back;
        KeyboardState k;
        List<MovableObject> movables;
        Foreground fore;
        ConsumableManager consumables;
        Texture2D healthBarOutline;
        Texture2D healthBarFilling;
        Random rand;
        SpriteFont font;
        int jackalSpawn;
        int timer;
        string gameState;
        bool switchStates;
        int score;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Sets to fullscreen and sets up coordinate system boundries
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
            this.graphics.IsFullScreen = true;

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
            timer = 0;
            score = 0;
            gameState = "SavannaDay";
            rand = new Random();
            switchStates = false;
            honey = new Badger();
            enemies = new EnemyManager();
            back = new Background();
            fore = new Foreground();
            movables = new List<MovableObject>();
            consumables = new ConsumableManager();
            movables.Add(honey);
            jackalSpawn = 0;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            honey.BadgerImage = this.Content.Load<Texture2D>("Badger Sprite sheet2");
            honey.Image = this.Content.Load<Texture2D>("Badger Sprite sheet2");
            honey.BadgerSwipeImage = this.Content.Load<Texture2D>("BadgerSwipe");
            enemies.JackalImage = this.Content.Load<Texture2D>("Jackal");
            honey.Swipe.SwipeImage = this.Content.Load<Texture2D>("Temp");
            back.BackgroundImage = this.Content.Load<Texture2D>("savannaback2");
            fore.ForegroundImage = this.Content.Load<Texture2D>("savannahfront2");
            consumables.HoneyImage = this.Content.Load<Texture2D>("honeyp");
            consumables.BlueberryImage = this.Content.Load<Texture2D>("bbp");
            consumables.StrawberryImage = this.Content.Load<Texture2D>("strawberry");
            consumables.MushroomImage = this.Content.Load<Texture2D>("mushp");
            consumables.EggImage = this.Content.Load<Texture2D>("eggp");
            healthBarFilling = this.Content.Load <Texture2D>("HealthBarFilling");
            healthBarOutline = this.Content.Load<Texture2D>("HealthBarOutline");
            font = Content.Load<SpriteFont>("SpriteFont1");//Ben coded dat 1
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            timer += 1;
            //Woah, it's like on of them finite state machines
            if (switchStates)
            {

            }
            k = Keyboard.GetState();
            if (k == new KeyboardState(Keys.Escape))
            {
                this.Exit();
            }
            else if (k == new KeyboardState(Keys.Right))
            {
                honey.BadgerState = "moveright";
                
            }
            else if (k == new KeyboardState(Keys.Left))
            {
                honey.BadgerState = "moveleft";
            }
            else if (k == new KeyboardState(Keys.Up))
            {
                honey.BadgerState = "jump";
            }
            else if (k == new KeyboardState(Keys.Space))
            {
                honey.BadgerState = "attack";
            }
            else
            {
                honey.BadgerState = "stop";
            }
            //Updates units on map
            back.UpdateBackground();
            fore.UpdateForeground();
            honey.badgerActions();
            enemies.EnemyUpdate();
            movables = new List<MovableObject>();
            movables.Add(honey);
        
            foreach (Jackal j in enemies.Jacks)
            {
                movables.Add(j);
                if (honey.Swipe.IsActive && honey.Swipe.SwipeArea.Intersects(j.Loc))
                {
                    j.IsDead = true;
                    score += 100;
                }
                 else if (j.Loc.Intersects(honey.Loc))
                {
                    j.IsDead = true;
                    honey.BadgerHealth -= 200;
                    score -= 1000;

                }
            }
            foreach (MovableObject m in movables)
            {
                m.Gravity();
                m.Loc = new Rectangle(m.Loc.X - 1, m.Loc.Y, m.Loc.Width, m.Loc.Height);
            }
            foreach (Food f in consumables.FoodList)
            {
                f.Loc = new Rectangle(f.Loc.X - 1, f.Loc.Y, f.Loc.Width, f.Loc.Height);
                 if (f.Loc.Intersects(honey.Loc))
                {
                    honey.BadgerHealth += f.HealthRestore;
                    score += f.ScoreGive;
                    
                }
                else
                {
                    consumables.NotConsumed.Add(f);
                }
            }
            consumables.FoodList = consumables.NotConsumed;
            consumables.NotConsumed = new List<Food>();
            if (honey.Swipe.IsActive)
            {
                honey.Swipe.SwipeUpdate(honey.Loc, honey.Direction);
            }

            //Spawns jackals, 2 a second right now, for testing purposes
            if (jackalSpawn == 0)
            {
                enemies.SpawnJackal();
                jackalSpawn = rand.Next(360);
            }
            jackalSpawn++;
            if(jackalSpawn >= 360)
            {
                jackalSpawn = 0;
            }
            if (timer % 600 == 0)
            {
                if (timer % 1800 == 0)
                {
                    consumables.CreateHoney();
                }
                else
                {
                    consumables.CreateFood();
                }
            }
            if (honey.BadgerHealth == 0)
            {
                gameState = "Over";
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (gameState == "Over")
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(font, "Game Over #swag", new Vector2(50, 50), Color.White);
            }
            else
            {
                spriteBatch.Draw(back.BackgroundImage, back.LocationRectangle1, back.DestinationRectangle1, Color.White);
                spriteBatch.Draw(back.BackgroundImage, back.LocationRectangle2, back.DestinationRectangle2, Color.White);
                //spriteBatch.Draw(fore.ForegroundImage, fore.LocationRectangle1, fore.DestinationRectangle1, Color.White);
                //spriteBatch.Draw(fore.ForegroundImage, fore.LocationRectangle2, fore.DestinationRectangle2, Color.White);
                //spriteBatch.Draw(
                spriteBatch.Draw(healthBarOutline, new Rectangle((int)this.Window.ClientBounds.Width / 3, 30, (int)this.Window.ClientBounds.Width / 3, 44), new Rectangle(0, 0, 492, 52), Color.White);
                spriteBatch.Draw(healthBarFilling, new Rectangle((int)(this.Window.ClientBounds.Width / 3) + 2, 34, (int)(this.Window.ClientBounds.Width / 3 * (honey.BadgerHealth / 1000.0)) - 4, 36), new Rectangle(4, 4, 484, 43), Color.White);
                spriteBatch.DrawString(font, "Score: " + score, new Vector2(20, 45), Color.White);
                spriteBatch.DrawString(font, "#YOLO", new Vector2(honey.Loc.X, honey.Loc.Y - 20), Color.White);
                foreach (MovableObject m in movables)
                {
                    if (m.Direction == 0)
                    {
                        spriteBatch.Draw(m.Image, m.Loc, m.Destination, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(m.Image, m.Loc, m.Destination, Color.White, 0, new Vector2(0), SpriteEffects.FlipHorizontally, 0);
                    }
                }
                foreach (Food f in consumables.FoodList)
                {
                    spriteBatch.Draw(f.Image, f.Loc, f.Destination, Color.White);
                }
                if (honey.Swipe.IsActive)
                {
                    spriteBatch.Draw(honey.Swipe.SwipeImage, honey.Swipe.SwipeArea, Color.White);
                }
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
