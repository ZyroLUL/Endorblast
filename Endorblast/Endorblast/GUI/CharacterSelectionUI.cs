﻿using Microsoft.Xna.Framework;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    class CharacterSelectionUI
    {

        static UICanvas canvas;
        static Table charaSelectBar;
        static Table playTable;
        static Entity dummyPlayer;

        static int currentSelectedChara;

        static List<DatabaseCharacter> charsList = new List<DatabaseCharacter>();
        static DatabaseCharacter selectedChara;

        static int[] characterID;
        static int[] charaName;
        static int[] hairID;

        public static void LoadCharacterUI(List<DatabaseCharacter> chars)
        {
            // Setup table right 
            Entity canvasEntity = new Entity("CharaSel-UI");
            canvas = canvasEntity.AddComponent(new UICanvas());
            canvas.SetRenderLayer(-1);

            charaSelectBar = canvas.Stage.AddElement(new Table());
            playTable = canvas.Stage.AddElement(new Table());

            charaSelectBar.SetFillParent(true);
            playTable.SetFillParent(true);


            charsList = new List<DatabaseCharacter>();

            for (int i = 0; i < chars.Count; i++)
            {
                charsList.Add(chars[i]);
            }


            Stack playerLabel = new Stack();
            Label charaNameTest = new Label("Characters");
            Label charaNameTest2 = new Label("2/2");



            TextButton playButton = new TextButton($"Play", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));



            charaNameTest.SetFontScale(2, 2);
            charaNameTest2.SetFontScale(2, 2);
            playButton.GetLabel().SetFontScale(2, 2);

            charaSelectBar.Top().Right();

            playerLabel.Add(charaNameTest).SetAlignment(Align.BottomLeft);
            playerLabel.Add(charaNameTest2).SetAlignment(Align.BottomRight);
            charaSelectBar.Add(playerLabel).Width(300).Height(40);
            charaSelectBar.Row();

            if (chars.Count == 0)
            {
                TextButton selectButton = new TextButton($"+", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));
                selectButton.GetLabel().SetFontScale(2, 2);
                charaSelectBar.Add(selectButton).Width(300).Height(40);
                charaSelectBar.Row();
                selectButton.OnClicked += button => LoadCharacterCreation();
            }
            else
            {
                
                for (int i = 0; i < chars.Count; i++)
                {
                    TextButton selectButton = new TextButton($"{chars[i].Name}", TextButtonStyle.Create(Color.Black, Color.Gray, Color.DarkGray));
                    selectButton.GetLabel().SetFontScale(2, 2);
                    selectButton.OnClicked += button => LoadCharaID(i);
                    charaSelectBar.Add(selectButton).Width(300).Height(40);
                    charaSelectBar.Row();
                    
                }
            }



            playTable.Right().Bottom();
            playTable.Add(playButton).Width(300).Height(50);

            playButton.OnClicked += button => JoinGame(currentSelectedChara);

            Core.Scene.AddEntity(canvasEntity);

        }

        private static void LoadCharaID(int id)
        {
            var chara = charsList[id - 1];

            if (dummyPlayer == null)
            {
                int offset = 140;
                dummyPlayer = new Entity("DummyCharaSelect");
                dummyPlayer.AddComponent(new PlayerAnimations());
                dummyPlayer.SetScale(new Vector2(6, 6));
                dummyPlayer.SetPosition(Screen.Width / 2 - offset, Screen.Height / 2);
                Core.Scene.AddEntity(dummyPlayer);
            }
            Console.WriteLine($"ID:{chara.Name}");
            dummyPlayer.GetComponent<PlayerAnimations>().LoadSet(chara.hairStyle);
            dummyPlayer.GetComponent<PlayerAnimations>().LoadHair(1);


        }

        private static void JoinGame(int charaID)
        {
            // Send to network
            // For now just join
            GameState.SetGameState(CurrentGameState.PlayingState);
        }

        private static void LoadCharacterCreation()
        {
            GameState.SetGameState(CurrentGameState.CharacterCreation);
        }

    }
}