﻿using Functionland.FxFiles.Client.Shared.Components.Modal;

namespace Functionland.FxFiles.Client.Shared.Pages
{
    public partial class MyDevice
    {
        private ArtifactSelectionModal _artifactSelectionModalRef = default!;

        [AutoInject] private ILocalDeviceFileService _fileService { get; set; } = default!;

        [AutoInject] private ILocalDevicePinService _pinService { get; set; } = default!;
    }
}
