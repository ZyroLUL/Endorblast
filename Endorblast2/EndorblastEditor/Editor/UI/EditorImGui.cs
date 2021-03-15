﻿using Endorblast.DB.ImGui;
using Endorblast.DB.Lib.Game.TileMap.Tilesets.Tools;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Num = System.Numerics;


namespace EndorblastEditor.Editor.UI
{
    
    public enum EditorState
    {
        Selector,
        MapEditor,
        TileEditor,
        PlayerEditor,
            
    }
    
    public class EditorImGui
    {

        private EditorState state = EditorState.Selector;
        
        private MapEditor mapEditor;
        private CharacterEditor charaEditor;
        
        

        public EditorImGui()
        {
            mapEditor = new MapEditor();
            charaEditor = new CharacterEditor();
        }
        
        public void Main()
        {
            
            
            
            
            switch (state)
            {
                case EditorState.Selector:
                    SetTile("Editor Tools");
                    if (ImGuiNET.ImGui.Button("Map Editor", new Num.Vector2(200, 20))) state = EditorState.MapEditor;
                    if (ImGuiNET.ImGui.Button("Player Editor",new Num.Vector2(200, 20))) state = EditorState.PlayerEditor;
                    break;
                case EditorState.MapEditor:
                    SetTile("Map Editor");
                    if (ImGuiNET.ImGui.Button("Go Back")) state = EditorState.Selector;
                    ImGuiNET.ImGui.NewLine();
                    mapEditor.Main();
                    break;
                case EditorState.PlayerEditor:
                    SetTile("Player Editor");
                    if (ImGuiNET.ImGui.Button("Go Back")) state = EditorState.Selector;
                    ImGuiNET.ImGui.NewLine();
                    charaEditor.Main();
                    
                    break;
            }
            
            ImGui.End();
        }

        public void Update(GameTime gt)
        {
            switch (state)
            {
                case EditorState.Selector:
                    break;
                case EditorState.MapEditor:
                    mapEditor.Update(gt);
                    break;
                case EditorState.PlayerEditor:
                    charaEditor.Update(gt);
                    break;
            }
        }

        public void Draw(SpriteBatch sb, GameTime gt)
        {
            switch (state)
            {
                case EditorState.Selector:
                    break;
                case EditorState.MapEditor:
                    mapEditor.Draw(sb, gt);
                    break;
                case EditorState.PlayerEditor:
                    charaEditor.Draw(sb, gt);
                    break;
            }
        }

        public void SetTile(string windowTitle = "Editor")
        {
            ImGui.Begin("Editor", ImGuiWindowFlags.NoResize);
            ImGui.SetWindowSize(new Num.Vector2(215, 400));
        }
    }
    
    
}