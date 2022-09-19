﻿using System.ComponentModel;

using Functionland.FxFiles.App.Components.Common;

namespace Functionland.FxFiles.App.Components
{
    public partial class ListView
    {
        [Parameter, EditorRequired]
        public string ListTitle { get; set; } = String.Empty;

        [Parameter, EditorRequired]
        public List<ListItemConfig>? ListItems { get; set; }

        public ViewModeEnum ViewMode = ViewModeEnum.list;
        public SortOrderEnum SortOrder = SortOrderEnum.asc;

        private bool IsSelectionMode;
        public bool IsSelectedAll = false;
        public DateTimeOffset PointerDownTime;

        public void ToggleSortOrder()
        {
            if (SortOrder == SortOrderEnum.asc)
            {
                SortOrder = SortOrderEnum.desc;
            }
            else
            {
                SortOrder = SortOrderEnum.asc;
            }

            //todo: change order of list items
        }

        public void OnSortChange()
        {
            //todo: Open sort bottom sheet
        }

        public void ToggleSelectedAll()
        {
            IsSelectedAll = !IsSelectedAll;
            //todo: select all items
        }

        public void ChangeViewMode(ViewModeEnum mode)
        {
            ViewMode = mode;
        }

        public void PointerDown()
        {
            PointerDownTime = DateTimeOffset.UtcNow;
        }

        public void PointerUp()
        {
            if (!IsSelectionMode)
            {
                var downTime = (DateTimeOffset.UtcNow.Ticks - PointerDownTime.Ticks) / TimeSpan.TicksPerMillisecond;

                IsSelectionMode = downTime > 400;
            }
        }
    }
}