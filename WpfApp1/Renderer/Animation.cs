using ShoresOfGold.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ShoresOfGold.Renderer
{
    class AnimationManager
    {
        List<Animation> Animations;
        int last;
        class Animation
        {
            int idx;
            List<BitmapImage> imageList;
            public Animation(string FolderPath)
            {
                Reset();
                imageList = new List<BitmapImage>();
                var list = Directory.GetFiles(FolderPath);
                foreach (var item in list)
                {
                    imageList.Add(new BitmapImage(new Uri(item, UriKind.RelativeOrAbsolute)));
                }
            }
            public BitmapImage Next()
            {
                if (idx >= imageList.Count)
                {
                    Reset();
                }
                return imageList[idx++];
            }
            public void Reset()
            {
                idx = 0;
            }
        }

        public AnimationManager()
        {
            last = -1;
            Animations = new List<Animation>();
        }

        public void Append(string fp)
        {
            Animations.Add(new Animation(fp));
        }

        public BitmapImage GetNextofThis(int h)
        {
            if (last != h)
            {
                Animations[h].Reset();
                last = h;
            }
            return Animations[h].Next();
        }
    }
}
