﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//=========================================================
//
//  developer : MasyoLab
//  github    : https://github.com/MasyoLab/UnityTools-FavoritesAsset
//
//=========================================================

namespace MasyoLab.Editor.FavoritesAsset
{
    class HelpWindow : BaseWindow
    {
        private Vector2 m_scrollVec = Vector2.zero;

        private PtrLinker<GUIStyle> m_headerStyle = new PtrLinker<GUIStyle>(() =>
        {
            return new GUIStyle(EditorStyles.label)
            {
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                fontSize = 20
            };
        });

        private PtrLinker<GUIStyle> m_h1 = new PtrLinker<GUIStyle>(() =>
        {
            return new GUIStyle(EditorStyles.label)
            {
                fontStyle = FontStyle.Bold,
                fontSize = 18
            };
        });

        private PtrLinker<GUIStyle> m_linkLabel = new PtrLinker<GUIStyle>(() =>
        {
            return new GUIStyle(EditorStyles.linkLabel)
            {
                fontStyle = FontStyle.Bold,
                fontSize = 15
            };
        });

        public override void OnGUI()
        {
            m_scrollVec = GUILayout.BeginScrollView(m_scrollVec);

            GUILayout.Label(CONST.EDITOR_WINDOW_NAME, m_headerStyle.Inst, GUILayout.ExpandWidth(true));
            GUILayout.Label(CONST.VERSION, m_headerStyle.Inst, GUILayout.ExpandWidth(true));
            Utils.GUILine();

            GUILayout.Label(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.Link), m_h1.Inst, GUILayout.ExpandWidth(true));

            if (GUILayout.Button("Readme", m_linkLabel.Inst, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
            {
                Utils.OpenURL("https://github.com/MasyoLab/UnityTools-FavoritesAsset/blob/master/README.md");
            }
            Utils.MouseCursorLink();

            if (GUILayout.Button(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.License), m_linkLabel.Inst, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
            {
                Utils.OpenURL("https://github.com/MasyoLab/UnityTools-FavoritesAsset/blob/master/LICENSE.md");
            }
            Utils.MouseCursorLink();

            if (GUILayout.Button(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.LatestRelease), m_linkLabel.Inst, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
            {
                Utils.OpenURL("https://github.com/MasyoLab/UnityTools-FavoritesAsset/releases");
            }
            Utils.MouseCursorLink();

            if (GUILayout.Button(LanguageData.GetText(m_pipeline.Setting.Language, TextEnum.SourceCode), m_linkLabel.Inst, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
            {
                Utils.OpenURL("https://github.com/MasyoLab/UnityTools-FavoritesAsset");
            }
            Utils.MouseCursorLink();

            GUILayout.EndScrollView();
        }
    }
}
#endif
