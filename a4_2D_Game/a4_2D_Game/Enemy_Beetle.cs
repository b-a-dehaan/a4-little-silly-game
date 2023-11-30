using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace a4_2D_Game
{
    internal class Enemy_Beetle : Enemy
    {
        public Enemy_Beetle(Vector2 pos) : base(pos)
        {
        }
        public override void LoadAnimations()
        {
            startSize.X = 873;
            startSize.Y = 1256;
            Animation idleAnim = new Animation(AnimationType.IDLE);
            idleAnim.AddTextureFrame(18, 11868, 873, 1256, 30);
            idleAnim.AddTextureFrame(987, 11868, 873, 1256, 30);
            idleAnim.AddTextureFrame(1961, 11868, 874, 1256, 30);
            idleAnim.AddTextureFrame(2934, 11927, 873,1197, 30);
            idleAnim.AddTextureFrame(3908,11868, 874, 1256, 30);
            idleAnim.AddTextureFrame(4883,11868,873,1256, 30);
            animComponent?.AddAnimation(AnimationType.IDLE, idleAnim);

            animComponent?.SwitchAnimation(AnimationType.IDLE);
            base.LoadAnimations();
        }
    }
}