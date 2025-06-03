using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Fields
{
    public class SpriteField : InputField<Texture>
    {
        [SerializeField]
        private Image _spriteDisplay;

        public override void Populate(Texture field)
        {
            var sprite = Sprite.Create((Texture2D)field, new Rect(0.0f, 0.0f, field.width, field.height), new Vector2(0.5f, 0.5f));
            _spriteDisplay.sprite = sprite;
        }
    }
}
