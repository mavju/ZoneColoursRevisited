﻿using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace ZoneColorChanger {
	public class ModInfo : IUserMod {
		public const string settingsFileName = "ZoneColorChanger";
		public static readonly SavedInputKey ToggleUIShortcut = new SavedInputKey("toggleUIShortcut", settingsFileName, SavedInputKey.Encode(KeyCode.K, true, false, false), true);

		public static bool _settingsFailed = false;

		public ModInfo() {
			try {
				// Creating setting file - from SamsamTS
				// only the toggle ui keybind is stored in his file. color profile is in ColorProfileConfigFile
				if(GameSettings.FindSettingsFileByName(settingsFileName) == null) {
					GameSettings.AddSettingsFile(new SettingsFile[] { new SettingsFile() { fileName = settingsFileName } });
				}
			}
			catch(Exception e) {
				_settingsFailed = true;
				Debug.Log("Couldn't load/create the setting file.");
				Debug.LogException(e);
			}
		}

		public string Name {
			get { return "Zone Color Changer"; }
		}

		public string Description {
			get { return "Allows zone color modification. A continuation of the Zone Colours mod by AtheMathmo"; }
		}

		public void OnSettingsUI(UIHelperBase helper) {
			UIHelper group = helper.AddGroup(Name) as UIHelper;
			UIPanel panel = group.self as UIPanel;

			group.AddSpace(10);
			panel.gameObject.AddComponent<OptionsKeymapping>();
			group.AddSpace(10);
		}
	}
}