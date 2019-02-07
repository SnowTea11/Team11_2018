using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boomerang
{
    interface ICharacterMediator
    {
        void AddCharacter(Character character);
        bool IsCharacterDead(CharacterID characterID);
        Vector2 GetCharacterPosition(CharacterID characterID);
    }
}