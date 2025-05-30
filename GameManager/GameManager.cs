using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : SingletonMonobehaviour<GameManager>
{
   [SerializeField] private List<DungeonLevelSO> dungeonLevelList;
   [SerializeField] private int currentDungeonLevelListIndex = 0;
   
   [HideInInspector] public GameState gameState;


   private void Start()
   {
      gameState = GameState.gameStarted;
   }

   private void Update()
   {
      HandleGameState();
      if (Input.GetKeyDown(KeyCode.R))
      {
         gameState = GameState.playingLevel;
      }
   }

   private void HandleGameState()
   {
      switch (gameState)
      {
         case GameState.gameStarted:
            PlayDungeonLevel(currentDungeonLevelListIndex);
            gameState = GameState.playingLevel;
            break;
      }
   }

   private void PlayDungeonLevel(int dungeonLevelListIndex)
   {
      bool dungeonBuilderSuccessfully =
         DungeonBuilder.Instance.GenerateDungeon(dungeonLevelList[dungeonLevelListIndex]);

      if (!dungeonBuilderSuccessfully)
      {
         Debug.Log("构建地图失败");
      }
   }

#if UNITY_EDITOR
   private void OnValidate()
   {
      HelperUtilities.ValidateCheckEnumerableValues(this, nameof(dungeonLevelList), dungeonLevelList);
   }
#endif
}
