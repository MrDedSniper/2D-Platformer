using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public sealed class ButtonsQuestModel : IQuestModel
    {
        private const string TargetTag = "QuestButtons";
        
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }
    }
}

