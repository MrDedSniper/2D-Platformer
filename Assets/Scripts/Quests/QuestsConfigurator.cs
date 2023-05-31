using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PlanformeMVC;
using UnityEngine;

namespace PlatformerMVC
{
    public class QuestsConfigurator : MonoBehaviour
    {
        //[SerializeField] private QuestObjectView _singleQuestView;
        [SerializeField] private InteractiveObjectView _playerView;
        [SerializeField] private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField] private QuestObjectView[] _questObjects;


        private List<IQuestStoryModel> _questStories;
        private Quest _singleQuest;

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories =
            new Dictionary<QuestType, Func<IQuestModel>>
            {
                {QuestType.Coins, () => new CoinsQuestModel()},
                {QuestType.Buttons, () => new ButtonsQuestModel()},
            };

        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStoryModel>> _questStoryFactories =
            new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStoryModel>>
            {
                {QuestStoryType.Common, questCollection => new QuestStory(questCollection)},
                //
                {QuestStoryType.Resettable, questCollection => new ResettableQuestStory(questCollection)},
                //
            };



        private void Start()

        {
            //_singleQuest = new Quest(_playerView, _singleQuestView, new ButtonsQuestModel());
            //_singleQuest.Reset();
            _questStories = new List<IQuestStoryModel>();
            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }

        }

        private void OnDestroy()
        {
            foreach (var questStory in _questStories)
            {
                questStory.Dispose();
            }

            _questStories.Clear();

            //_singleQuest.Dispose();
        }

        private IQuestStoryModel CreateQuestStory(QuestStoryConfig config)
        {
            var quests = new List<IQuest>();
            foreach (var questConfig in config.quests)
            {
                var quest = CreateQuest(questConfig);
                if (quest == null) continue;
                quests.Add(quest);
            }

            return _questStoryFactories[config.questStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            var questId = config.id;
            var questView = _questObjects.FirstOrDefault(value => value.Id == config.id);
            if (questView == null)
            {
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find view of quest {questId.ToString()}");
                return null;
            }

            if (_questFactories.TryGetValue(config.questType, out var factory))
            {
                var questModel = factory.Invoke();
                return new Quest(_playerView, questView, questModel);
            }

            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest{questId.ToString()}");
            return null;
        }
    }
}

