using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public sealed class CoinsQuestModel : IQuestModel
    {
        private const string TargetTag = "QuestCoin";
        
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }
    }
}

