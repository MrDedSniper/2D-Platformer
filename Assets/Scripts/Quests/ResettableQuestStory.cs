
using System;

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlatformerMVC
{
    public sealed class ResettableQuestStory : IQuestStoryModel
    {
        private GhostPlatformModel _ghostPlatformModel;
        private readonly List<IQuest> _questsCollection;
        private int _currentIndex;
       
        public ResettableQuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection ?? throw new ArgumentNullException(nameof(questsCollection));
            _ghostPlatformModel = GameObject.FindObjectOfType<GhostPlatformModel>();
            Subscribe();
            ResetQuests();
        }
       
        private void Subscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }
        private void Unsubscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }
        private void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);
            if (_currentIndex == index)
            {
                _currentIndex++;
                
                if (IsDone)
                {
                    _ghostPlatformModel.GhostDeactivate();
                }
            }
            else
            {
                ResetQuests();
            }
        }
        private void ResetQuests()
        {
            _currentIndex = 0;
            foreach (var quest in _questsCollection)
            {
                quest.Reset();
            }
        }

        
        public bool IsDone => _questsCollection.All(value => value.IsCompleted);
        public void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _questsCollection)
            {
                quest.Dispose();
            }
        }
        
    }
}

