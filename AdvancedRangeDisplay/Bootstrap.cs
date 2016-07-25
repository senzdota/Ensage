﻿namespace AdvancedRangeDisplay
{
    using System;

    using Ensage;
    using Ensage.Common;

    internal class Bootstrap
    {
        #region Fields

        private readonly Ranges ranges = new Ranges();

        #endregion

        #region Public Methods and Operators

        public void Initialize()
        {
            Events.OnLoad += OnLoad;
        }

        #endregion

        #region Methods

        private void Game_OnUpdate(EventArgs args)
        {
            ranges.OnUpdate();
        }

        private void OnClose(object sender, EventArgs e)
        {
            Events.OnClose -= OnClose;
            Game.OnIngameUpdate -= Game_OnUpdate;
            ranges.OnClose();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            ranges.OnLoad();
            Events.OnClose += OnClose;
            Game.OnIngameUpdate += Game_OnUpdate;
        }

        #endregion
    }
}