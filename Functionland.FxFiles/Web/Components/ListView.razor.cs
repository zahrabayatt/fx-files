﻿using Functionland.FxFiles.App.Components.Common;
using System.ComponentModel;

namespace Functionland.FxFiles.App.Components
{
    public partial class ListView
    {
        [Parameter, EditorRequired]
        public string ListTitle { get; set; } = String.Empty;

        [Parameter, EditorRequired]
        public List<ListItemConfig> ListItems { get; set; } = new List<ListItemConfig>() { };

        public ViewModeEnum ViewMode = ViewModeEnum.list;
        public SortOrderEnum SortOrder = SortOrderEnum.asc;
        public bool IsSelectedAll = false;


        public void ToggleSortOrder()
        {
            if (SortOrder == SortOrderEnum.asc)
            {
                SortOrder = SortOrderEnum.desc;
            } else
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
    }
}