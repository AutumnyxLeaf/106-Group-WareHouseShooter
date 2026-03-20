/// Tommy B, Ethan C, Ian H, Autumn S
/// 3/6/26
/// Our legendary game :)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Right_to_Return_Arms.GunClasses;

namespace Right_to_Return_Arms
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont DEBUG_FONT;
        
        private Gun _gun;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic herea
            StatModifier DAMAGE_MODIFIER = new StatModifier(GunStat.DAMAGE, 1.23f);
            StatModifier FIRERATE_MODIFIER = new StatModifier(GunStat.FIRE_RATE, 0.26f);
            StatModifier MAX_AMMO_MODIFIER = new StatModifier(GunStat.MAX_AMMO, 0.93f);
            StatModifier COOLDOWN_MODIFIER = new StatModifier(GunStat.SHOOTING_COOLDOWN, 1.6f);
            StatModifier BULLET_SPEED_MODIFIER = new StatModifier(GunStat.BULLET_SPEED, 1.27f);

            GenericGunUpgrade GGU1 = new GenericGunUpgrade("Cog", "literally just a cog", COOLDOWN_MODIFIER);
            GenericGunUpgrade GGU2 = new GenericGunUpgrade("Nail Bullets", "Fire Nail Bullets that hurt!", DAMAGE_MODIFIER);

            GunPart barrel = new GunPart("Super Long Barrel", 
                "It's barrel is 70 feet long", GunPartID.BARREL, null, DAMAGE_MODIFIER, FIRERATE_MODIFIER);
            GunPart grip = new GunPart("Grippy", 
                "It's grip is parallel to no other", GunPartID.GRIP, null, BULLET_SPEED_MODIFIER);
            GunPart stock = new GunPart("Oak Log", 
                "it's wood", GunPartID.STOCK, null, MAX_AMMO_MODIFIER);

            _gun = new Gun(barrel, grip, stock, GGU1, GGU2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            DEBUG_FONT = Content.Load<SpriteFont>("DebugFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(DEBUG_FONT, _gun.ToString(), new Vector2(30,30), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
