using System;
using Platformer.View;
using Platformer.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input.Touch;

namespace Platformer.Model
{
	public class Projectile
	{
		

		// Image representing the Projectile
		public Texture2D Texture;

		// Position of the Projectile relative to the upper left side of the screen
		public Vector2 Position;

		// State of the Projectile
		public bool Active;

		// The amount of damage the projectile can inflict to an enemy
		public int Damage;

		// Represents the viewable boundary of the game
		//Viewport viewport;

		// Get the width of the projectile ship
		public int Width
		{
			get { return Texture.Width; }
		}

		// Get the height of the projectile ship
		public int Height
		{
			get { return Texture.Height; }
		}

		public int gravityX;
		public int gravityY;

		private double rotation;



		// Determines how fast the projectile moves
		float projectileMoveSpeed;

		public void loadContent()
		{
			
		}

		public void Initialize(Texture2D texture , Vector2 position)
		{
			Texture = texture;
			Position = position;
			//this.viewport = viewport;


			Active = true;

			Damage = 2;

			projectileMoveSpeed = 20f;
		}


		public void Update()
		{

			fire(Position.X , Position.Y , projectileMoveSpeed , gravityX , gravityY , rotation);

			// Deactivate the bullet if it goes out of screen
			if(Position.X + Texture.Width / 2 > 800)
			{
				Active = false;
			}
		}

		public void fire(float x , float y , float speed , int gx , int gy , double angle)
		{
			Position.X = x;
			Position.Y = y;

			projectileMoveSpeed = speed;

			gravityX = gx;
			gravityY = gy;

			Position.X += speed;
			Position.Y = (float)((0.5) * gy * Math.Pow(((gy)) , 2)) + y;

			rotation = angle;

			if(Position.X + Texture.Width / 2 > 800)
			{
				Active = false;
			}

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture , Position , null , Color.White , (float)rotation , Vector2.Zero , 1f , SpriteEffects.None , 0f);

		}

		public Projectile(float x , float y , float speed , int gx , int gy , double angleRot)
		{
			this.gravityX = gx;
			this.gravityY = gy;
			this.Position.X = x;
			this.Position.Y = y;
			this.projectileMoveSpeed = speed;
			this.rotation = angleRot;

		}



	}
}