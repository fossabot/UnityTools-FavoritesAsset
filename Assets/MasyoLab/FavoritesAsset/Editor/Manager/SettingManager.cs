﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=========================================================
//
//  developer : MasyoLab
//  github    : https://github.com/MasyoLab/UnityTools-FavoritesAsset
//
//=========================================================

namespace MasyoLab.Editor.FavoritesAsset
{
    class SettingManager : BaseManager
    {
        private PtrLinker<SettingData> m_settingData = new PtrLinker<SettingData>(LoadSettingData);
        public SettingData Data => m_settingData.Inst;

        public LanguageEnum Language
        {
            get => Data.Language;
            set
            {
                if (Data.Language != value)
                {
                    Data.Language = value;
                    SaveSettingData();
                }
            }
        }

        public string IOTarget
        {
            get => Data.IOTarget;
            set
            {
                if (Data.IOTarget != value)
                {
                    Data.IOTarget = value;
                    SaveSettingData();
                }
            }
        }

        public string IOFileName
        {
            get => Data.IOFileName;
            set
            {
                if (Data.IOFileName != value)
                {
                    Data.IOFileName = value;
                    SaveSettingData();
                }
            }
        }

        public SettingManager(IPipeline pipeline) : base(pipeline) { }

        public void SaveSettingData()
        {
            SaveLoad.Save(JsonUtility.ToJson(Data), SaveLoad.GetSaveDataPath(CONST.SETTING_DATA));
        }

        private static SettingData LoadSettingData()
        {
            string jsonData = SaveLoad.Load(SaveLoad.GetSaveDataPath(CONST.SETTING_DATA));

            // json から読み込む
            var assets = JsonUtility.FromJson<SettingData>(jsonData);
            if (assets == null)
            {
                return new SettingData();
            }
            return assets;
        }
    }
}
#endif
