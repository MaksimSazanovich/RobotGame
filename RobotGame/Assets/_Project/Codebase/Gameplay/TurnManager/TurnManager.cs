using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_one_love.RobotGame
{
    public class TurnManager : MonoBehaviour
    {

        private List<Command> turns = new();

        public void AddTurn(Command command)
        {
            turns.Add(command);
        }

        public void Play()
        {
            StartCoroutine(PlayTurnsCoroutine());
        }

        private IEnumerator PlayTurnsCoroutine()
        {
            foreach (var command in turns)
            {
                command.Execute();
                yield return new WaitUntil(command.GetPlayerCommander().IsFinished);
            }
        }
    }
}