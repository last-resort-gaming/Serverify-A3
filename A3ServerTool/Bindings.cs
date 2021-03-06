﻿using A3ServerTool.Helpers;
using A3ServerTool.Models;
using A3ServerTool.Models.Config;
using A3ServerTool.Helpers.ServerLauncher;
using A3ServerTool.Storage;
using GalaSoft.MvvmLight.Ioc;
using A3ServerTool.ViewModels;
using A3ServerTool.ViewModels.ServerSubViewModels;
using MahApps.Metro.Controls.Dialogs;
using CommonServiceLocator;

namespace A3ServerTool
{
    /// <summary>
    /// Represents non-VM bindings in SimpleIoc container.
    /// </summary>
    public class Bindings
    {
        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();
        public ServerViewModel Server => SimpleIoc.Default.GetInstance<ServerViewModel>();
        public AboutViewModel About => SimpleIoc.Default.GetInstance<AboutViewModel>();
        public ProfilesViewModel Profiles => SimpleIoc.Default.GetInstance<ProfilesViewModel>();
        public SettingsViewModel Settings => SimpleIoc.Default.GetInstance<SettingsViewModel>();
        public ProfileDialogViewModel ProfileDialog => SimpleIoc.Default.GetInstance<ProfileDialogViewModel>();
        public GeneralViewModel General => SimpleIoc.Default.GetInstance<GeneralViewModel>();
        public NetworkViewModel Network => SimpleIoc.Default.GetInstance<NetworkViewModel>();
        public SecurityViewModel Security => SimpleIoc.Default.GetInstance<SecurityViewModel>();
        public LoggingViewModel Logging => SimpleIoc.Default.GetInstance<LoggingViewModel>();
        public PerfromanceViewModel Performance => SimpleIoc.Default.GetInstance<PerfromanceViewModel>();
        public ModificationsViewModel Modifications => SimpleIoc.Default.GetInstance<ModificationsViewModel>();
        public MissionsViewModel Missions => SimpleIoc.Default.GetInstance<MissionsViewModel>();
        public DifficultyViewModel Difficulty => SimpleIoc.Default.GetInstance<DifficultyViewModel>();

        /// <summary>
        /// Registers types.
        /// </summary>
        public static void Register()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ProfilesViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<ServerViewModel>();
            SimpleIoc.Default.Register<GeneralViewModel>();
            SimpleIoc.Default.Register<IDialogCoordinator, DialogCoordinator>();
            SimpleIoc.Default.Register<ProfileDialogViewModel>();
            SimpleIoc.Default.Register<NetworkViewModel>();
            SimpleIoc.Default.Register<SecurityViewModel>();
            SimpleIoc.Default.Register<LoggingViewModel>();
            SimpleIoc.Default.Register<PerfromanceViewModel>();
            SimpleIoc.Default.Register<ModificationsViewModel>();
            SimpleIoc.Default.Register<MissionsViewModel>();
            SimpleIoc.Default.Register<DifficultyViewModel>();

            SimpleIoc.Default.Register<IDao<Profile>, JsonProfileDao>();
            SimpleIoc.Default.Register<IDao<Mission>, MissionDao>();
            SimpleIoc.Default.Register<IDao<Modification>, ModificationDao>();
            SimpleIoc.Default.Register<IConfigDao<BasicConfig>,BasicConfigDao>();
            SimpleIoc.Default.Register<IConfigDao<ServerConfig>, ServerConfigDao>();
            SimpleIoc.Default.Register<IConfigDao<ArmaProfile>, ArmaProfileDao>();
            SimpleIoc.Default.Register<IProfileDirector, ProfileDirector>();
            SimpleIoc.Default.Register<IServerLauncher, ServerLauncher>();
            SimpleIoc.Default.Register<IMissionDirector, MissionDirector>();
            SimpleIoc.Default.Register<IServerStringBuilder, ServerStringBuilder>();
            SimpleIoc.Default.Register<IUniversalParser, UniversalParser>();
            SimpleIoc.Default.Register<GameLocationFinder>();
        }
    }
}
