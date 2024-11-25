using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Unity_one_love.RobotGame
{
    public class TurnButtonsPanel : MonoBehaviour
    {
        [SerializeField] private Button singleMoveButton;
        [SerializeField] private Button doubleMoveButton;
        [SerializeField] private Button waitButton;
        [SerializeField] private Button rightRotateButton;
        [SerializeField] private Button leftRotateButton;
        [SerializeField] private Button shootButton;

        [SerializeField] private Button playButton;
        
        
        private TurnManager turnManager;
        private CommandFactory commandFactory;

        [Inject]
        private void Constructor(TurnManager turnManager, CommandFactory commandFactory)
        {
            this.turnManager = turnManager;
            this.commandFactory = commandFactory;
        }

        private void Awake()
        {
            singleMoveButton.onClick.AddListener(() => turnManager.AddTurn(commandFactory.CreateSingleMoveCommand()));
            doubleMoveButton.onClick.AddListener(() => turnManager.AddTurn(commandFactory.CreateDoubleMoveCommand()));
            waitButton.onClick.AddListener(() => turnManager.AddTurn(commandFactory.CreateWaitCommand()));
            rightRotateButton.onClick.AddListener(() => turnManager.AddTurn(commandFactory.CreateRightRotateCommand()));
            leftRotateButton.onClick.AddListener(() => turnManager.AddTurn(commandFactory.CreateLeftRotateCommand()));
            shootButton.onClick.AddListener(() => turnManager.AddTurn(commandFactory.CreateShootCommand()));

            playButton.onClick.AddListener(() => turnManager.Play());
        }
    }
}