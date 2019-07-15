﻿using A3ServerTool.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Interchangeable.IO;
using A3ServerTool.Models.Config;
using A3ServerTool.Helpers;

namespace A3ServerTool.Storage
{
    /// <inheritdoc/>
    public class ServerConfigDao : IConfigDao<ServerConfig>
    {
        private const string ConfigFileExtension = ".cfg";
        private const string ConfigFileName = "server";

        private readonly IMissionDirector _missionDirector;
        private readonly GameLocationFinder _locationFinder;

        public ServerConfigDao(IMissionDirector missionDirector, GameLocationFinder locationFinder)
        {
            _missionDirector = missionDirector;
            _locationFinder = locationFinder;
        }

        /// <inheritdoc/>
        public ServerConfig Get(Profile profile)
        {
            var file = FileHelper.GetFile(Path.Combine(Constants.RootFolder, Constants.ServerProfileFolder, profile.Id.ToString(),
                  ConfigFileName) + ConfigFileExtension);
            if (file == null) return null;

            var properties = TextManager.ReadFileLineByLine(file);
            if (!properties.Any()) return null;

            var result = UniversalParser.Parse<ServerConfig>(properties);
            if (result == null) return null;

            result.FileLocation = file.FullName;
            GetAndMarkUsedMissions(profile, properties, result);

            return result;
        }

        /// <inheritdoc/>
        public void Save(Profile profile)
        {
            var configDto = new SaveDataDto
            {
                Content = string.Join("\r\n", UniversalParser.ConvertToText(profile.ServerConfig)),
                FileExtension = ConfigFileExtension,
                FileName = ConfigFileName,
                Folders = new List<string>
                    {
                        Constants.RootFolder,
                        Constants.ServerProfileFolder,
                        profile.Id.ToString()
                    }
            };

            configDto.Content = _missionDirector.SaveMissions(profile.ServerConfig.Missions, configDto.Content);

            profile.ServerConfig.FileLocation = Path.Combine(Constants.RootFolder, configDto.GetFullPath());
            FileHelper.Save(configDto);
        }

        /// <summary>
        /// Gets the stored missions and marks them with IsWhitelisted property.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="result">The result.</param>
        private void GetAndMarkUsedMissions(Profile profile, List<string> properties, ServerConfig result)
        {
            result.Missions = _missionDirector.GetMissions(properties, _locationFinder.GetGameInstallationPath(profile))
                .ToList();

            foreach (var mission in result.Missions)
            {
                if (result.MissionWhitelist?.Any(m => m == mission.Name) == true)
                {
                    mission.IsWhitelisted = true;
                }
            }
        }
    }
}
