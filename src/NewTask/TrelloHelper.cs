using System;
using System.Linq;
using System.Text.RegularExpressions;
using NewTask.Models;
using TrelloNet;

namespace NewTask
{
    public class TrelloHelper
    {
        private readonly ITrello _trello;
        private readonly IBoardId _currentBoardId;
        private readonly string _currentProjectId;
        private const string CustomFieldsPluginId = "56d5e249a98895a9797bebb9";

        public TrelloHelper(Configuration configuration, ProjectsConfiguration projectsConfiguration)
        {
            _currentProjectId = projectsConfiguration.CurrentProjectId;
            _trello = new Trello(configuration.Trello.ApiKey);
            _trello.Authorize(configuration.Trello.OAuthToken);
            var boardPlugins = _trello.Advanced.Get($"Boards/ZOUl8taI/boardPlugins").ToString();
            _trello.Advanced.Post("Boards/ZOUl8taI/boardPlugins", new {idPlugin = CustomFieldsPluginId});
            _currentBoardId = GetBoardForProject(projectsConfiguration);
        }

        private Board GetBoardForProject(ProjectsConfiguration projectsConfiguration)
        {
            var currentProject = projectsConfiguration.Projects[projectsConfiguration.CurrentProjectId];
            var currentBoardId = currentProject.Trello.BoardId;
            return _trello.Boards.WithId(currentBoardId);
        }

        private static readonly Regex IdRegex = new Regex(@"\w+-(?<id>\d+):", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static int GetIdFromCardName(string cardName)
        {
            try
            {
                var match = IdRegex.Match(cardName);
                return int.Parse(match.Groups["id"].Value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List GetListForStatus(IBoardId boardId, TaskStatus status)
        {
            return _trello.Lists.ForBoard(boardId).FirstOrDefault(l => l.Name == status.ToString());
        }

        private int GetLastCardIdInBoard(IBoardId boardId)
        {
            var defaultCard = new Card { Name = "DEF-0:" };

            var cards = _trello.Cards.ForBoard(boardId, BoardCardFilter.All);

            var lastCard = cards.DefaultIfEmpty(defaultCard).OrderBy(c => GetIdFromCardName(c.Name)).LastOrDefault();
            var lastCardId = GetIdFromCardName(lastCard.Name);
            return lastCardId;
        }

        public Color MapTypeToColor(TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Investigation:
                    return Color.Red;
                case TaskType.Translation:
                    return Color.Sky;
                case TaskType.Preparation:
                    return Color.Lime;
                case TaskType.Implementation:
                    return Color.Blue;
                case TaskType.Debug:
                    return Color.Green;
                case TaskType.Review:
                    return Color.Purple;
                case TaskType.Testing:
                    return Color.Pink;
                case TaskType.Documentation:
                    return Color.Black;
                case TaskType.Consulting:
                    return Color.Yellow;
                case TaskType.Communication:
                    return Color.Orange;
                default:
                    return null;
            }
        }

        public Card CreateNewCard(string taskName, TaskStatus taskStatus, TaskType taskType, int priority, int estimateInHours, DateTime deadline, string description = null)
        {
            var cardId = GetLastCardIdInBoard(_currentBoardId) + 1;
            var cardName = $"{_currentProjectId}-{cardId}: {taskName}";
            var list = GetListForStatus(_currentBoardId, taskStatus);
            var card = _trello.Cards.Add(cardName, list);
            var color = MapTypeToColor(taskType);
            _trello.Cards.ChangeDescription(card, description ?? string.Empty);
            _trello.Cards.ChangePos(card, priority);
            _trello.Cards.ChangeDueDate(card, deadline);
            _trello.Cards.AddLabel(card, color);
            _trello.Cards.AddComment(card, $"ќценка: {estimateInHours} часов.");
            _trello.Cards.AddMember(card, _trello.Members.Me());
            return card;
        }
    }
}